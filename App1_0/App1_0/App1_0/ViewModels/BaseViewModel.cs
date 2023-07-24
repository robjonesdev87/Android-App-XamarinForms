using App1_0.API;
using App1_0.Models;
using App1_0.Views.Messages;
using App1_0.Views.Popups;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using static Xamarin.Essentials.Permissions;
using BasePermission = Xamarin.Essentials.Permissions.BasePermission;

namespace App1_0.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Settings Settings { get; set; }
        public ObservableCollection<ImageForUpload> TakenImages { get; set; } = new ObservableCollection<ImageForUpload>();
        public ObservableCollection<UserMessages> UserMessages { get; set; } = new ObservableCollection<UserMessages>();
        public Command TakePhotoCommand { get; set; }
        public Command AddImageCommand { get; set; }
        public Command CancelImageCommand { get; set; }
        public Command ImageTappedCommand { get; set; }
        public Command UpdateImageCommand { get; set; }
        public Command DeleteImageCommand { get; set; }
        public Command OpenMessagesCommand { get; set; }
        public Command MessageTappedCommand { get; set; }
        public Command DeleteMessageCommand { get; set; }
        public Command ReplyToMessageCommand { get; set; }
        public string MessageReplyText { get; set; } = "";
        public string ImagePath { get; set; } = "";
        public string ImageName { get; set; } = "";
        public string ImageDescription { get; set; } = "";
        public ImageForUpload SelectedImage { get; set; }
        public bool ImageAddButtonVisible { get; set; } = true;
        public bool ImageEditButtonsVisible { get; set; } = false;
        public int CollectionViewHeight { get; set; } = 0;
        public UserMessages UserMessage { get; set; }

        //public User User { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public JsonSerializerSettings JsonSettings { get; set; }

        public bool isExecuting = false;
        public BaseViewModel()
        {

            //Images Commands
            TakePhotoCommand = new Command(TakePhotoAsync);
            AddImageCommand = new Command(AddImage);
            CancelImageCommand = new Command(CancelImage);
            ImageTappedCommand = new Command(ImageTapped);
            UpdateImageCommand = new Command(UpdateImage);
            DeleteImageCommand = new Command(DeleteImage);

            //Message Commands
            OpenMessagesCommand = new Command(OpenMessages);
            MessageTappedCommand = new Command(MessageTapped);
            DeleteMessageCommand = new Command(DeleteMessage);
            ReplyToMessageCommand = new Command(ReplyToMessage);

            MessagingCenter.Subscribe<object, string[]>(this, "RefreshMessages", (sender, arg) => {
                RefreshMessages();
            });

            TakenImages.Clear();

            //CheckMiddleware();
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        public async void TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
        public async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                ImagePath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            ImagePath = newFile;

            ImageAddButtonVisible = true;
            ImageEditButtonsVisible = false;
            NotifyPropertyChanged("ImageAddButtonVisible");
            NotifyPropertyChanged("ImageEditButtonsVisible");

            ResetImage();
            await PopupNavigation.Instance.PushAsync(new EditImage(this));

        }
        public async void AddImage()
        {
            try
            {

                if (ImageName == "")
                {
                    await Application.Current.MainPage.DisplayAlert("Issues Detected", "Image Name cannot be empty", "Ok");
                    return;
                }

                TakenImages.Add(
                    new ImageForUpload
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = ImageName,
                        Description = ImageDescription,
                        Path = ImagePath
                    }
                );


                if (TakenImages.Count > 0)
                {
                    CollectionViewHeight = 120;
                }
                if (TakenImages.Count > 3)
                {
                    CollectionViewHeight = 240;
                }
                if (TakenImages.Count > 6)
                {
                    CollectionViewHeight = 360;
                }
                if (TakenImages.Count > 9)
                {
                    CollectionViewHeight = 480;
                }
                if (TakenImages.Count > 12)
                {
                    CollectionViewHeight = 600;
                }

                NotifyPropertyChanged("CollectionViewHeight");

                ResetImage();
                MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateImage THREW: {ex.Message}");
            }
        }
        public async void CancelImage()
        {
            ResetImage();
            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");

        }
        public async void UpdateImage()
        {
            var selectedImage = TakenImages.Where(x => x.Id == SelectedImage.Id).FirstOrDefault();
            selectedImage.Name = ImageName;
            selectedImage.Description = ImageDescription;

            TakenImages.Remove(selectedImage); //hacky fix to update edited image
            TakenImages.Add(selectedImage);

            NotifyPropertyChanged("TakenImages");
            await Application.Current.MainPage.DisplayAlert("Notificiation", "Image Updated", "Ok");

            ResetImage();
            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");

        }
        public async void DeleteImage()
        {
            var selectedImage = TakenImages.Where(x => x.Id == SelectedImage.Id).FirstOrDefault();
            TakenImages.Remove(selectedImage);
            NotifyPropertyChanged("TakenImages");
            await Application.Current.MainPage.DisplayAlert("Notificiation", "Image Deleted", "Ok");

            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");
            ResetImage();
        }
        public async void ResetImage()
        {
            ImageName = "";
            ImageDescription = "";
            if (SelectedImage != null)
            {
                SelectedImage = null;
            }

        }
        public async void ImageTapped()
        {

            if (isExecuting)
                return;
            try
            {
                isExecuting = true;
                if (SelectedImage != null)
                {
                    ImageName = SelectedImage.Name;
                    ImageDescription = SelectedImage.Description;
                    ImagePath = SelectedImage.Path;

                    ImageAddButtonVisible = false;
                    ImageEditButtonsVisible = true;
                    NotifyPropertyChanged("ImageAddButtonVisible");
                    NotifyPropertyChanged("ImageEditButtonsVisible");
                    await PopupNavigation.Instance.PushAsync(new EditImage(this));
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                isExecuting = false;
            }


        }
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }

        public async Task GetLocationAsync()
        {

            var status = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
            if (status != PermissionStatus.Granted)
            {
                var action = await Application.Current.MainPage.DisplayAlert("Location Permissions", "Enable Location Permissions?", "Yes", "No");
                if (action)
                {
                    AppInfo.ShowSettingsUI();
                    //await CheckAndRequestLocationPermission();
                    //MessagingCenter.Send<object, string[]>(this, "OpenLocationPermissionsPage", new string[] { });
                }
                return;
            }

            try
            {
                Location location = await Geolocation.GetLocationAsync();
                App.APIConnect.SaveGeoLocation(location.ToString());
            } catch (Exception ex)
            {
                var action = await Application.Current.MainPage.DisplayAlert("Location?", "Would you like to enable Location?", "Yes", "No");
                if(action)
                {
                    MessagingCenter.Send<object, string[]>(this, "OpenLocationSettings", new string[] { });

                }
            }

        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
                    where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }

        public async void RefreshMessages()
        {
            var APIConnect = new APIConnect();
            var GetLoggedInUser = APIConnect.GetLoggedInUser();
            UserMessages = APIConnect.GetUserMessages(GetLoggedInUser.User.Id).User.Messages;
            NotifyPropertyChanged("UserMessages");
        }

        public async void OpenMessages()
        {
            try
            {
                RefreshMessages();
                App.Current.MainPage.Navigation.PushAsync(new MessagesPage(this));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Error Retrieving Messages: " + ex.Message + ex.InnerException, "Ok");
            }
        }

        public async void DeleteMessage()
        {
            try
            {
                //App.Current.MainPage.Navigation.PushAsync(new MessagesPage(this));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Error Deleting Message: " + ex.Message + ex.InnerException, "Ok");
            }
        }

        public async void ReplyToMessage()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new MessagesPage(this));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Error Deleting Message: " + ex.Message + ex.InnerException, "Ok");
            }
        }

        public async void MessageTapped(object selectedItem)
        {
            try
            {
                var selected = selectedItem as ItemTappedEventArgs;
                UserMessage = selected.Item as UserMessages;
                MessageReplyText = "";
                NotifyPropertyChanged("UserMessage");

                await PopupNavigation.Instance.PushAsync(new SingleMessagePopup(this));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Error Retrieving Message: " + ex.Message + ex.InnerException, "Ok");
            }
        }

        public async void CheckMiddleware()
        {
            if (Settings.AccessToken == "" || Settings.AccessToken == null)
            {
                await Shell.Current.GoToAsync("//LoginPage");
            } else
            {
                var APIConnect = new APIConnect();
                var GetLoggedInUser = APIConnect.GetLoggedInUser();

                if (GetLoggedInUser.Status != 200)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Your Login token has expired, please login again", "Ok");
                    await Shell.Current.GoToAsync("//LoginPage");
                }
            }

        }
    }
}
