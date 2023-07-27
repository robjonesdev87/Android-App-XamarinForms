// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 07-18-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 07-19-2023
// ***********************************************************************
// <copyright file="BaseViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class BaseViewModel.
    /// Implements the <see cref="INotifyPropertyChanged" />
    /// </summary>
    /// <seealso cref="INotifyPropertyChanged" />
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public Settings Settings { get; set; }
        /// <summary>
        /// Gets or sets the taken images.
        /// </summary>
        /// <value>The taken images.</value>
        public ObservableCollection<ImageForUpload> TakenImages { get; set; } = new ObservableCollection<ImageForUpload>();
        /// <summary>
        /// Gets or sets the user messages.
        /// </summary>
        /// <value>The user messages.</value>
        public ObservableCollection<UserMessages> UserMessages { get; set; } = new ObservableCollection<UserMessages>();
        /// <summary>
        /// Gets or sets the take photo command.
        /// </summary>
        /// <value>The take photo command.</value>
        public Command TakePhotoCommand { get; set; }
        /// <summary>
        /// Gets or sets the add image command.
        /// </summary>
        /// <value>The add image command.</value>
        public Command AddImageCommand { get; set; }
        /// <summary>
        /// Gets or sets the cancel image command.
        /// </summary>
        /// <value>The cancel image command.</value>
        public Command CancelImageCommand { get; set; }
        /// <summary>
        /// Gets or sets the image tapped command.
        /// </summary>
        /// <value>The image tapped command.</value>
        public Command ImageTappedCommand { get; set; }
        /// <summary>
        /// Gets or sets the update image command.
        /// </summary>
        /// <value>The update image command.</value>
        public Command UpdateImageCommand { get; set; }
        /// <summary>
        /// Gets or sets the delete image command.
        /// </summary>
        /// <value>The delete image command.</value>
        public Command DeleteImageCommand { get; set; }
        /// <summary>
        /// Gets or sets the open messages command.
        /// </summary>
        /// <value>The open messages command.</value>
        public Command OpenMessagesCommand { get; set; }
        /// <summary>
        /// Gets or sets the message tapped command.
        /// </summary>
        /// <value>The message tapped command.</value>
        public Command MessageTappedCommand { get; set; }
        /// <summary>
        /// Gets or sets the delete message command.
        /// </summary>
        /// <value>The delete message command.</value>
        public Command DeleteMessageCommand { get; set; }
        /// <summary>
        /// Gets or sets the reply to message command.
        /// </summary>
        /// <value>The reply to message command.</value>
        public Command ReplyToMessageCommand { get; set; }
        /// <summary>
        /// Gets or sets the message reply text.
        /// </summary>
        /// <value>The message reply text.</value>
        public string MessageReplyText { get; set; } = "";
        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        public string ImagePath { get; set; } = "";
        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <value>The name of the image.</value>
        public string ImageName { get; set; } = "";
        /// <summary>
        /// Gets or sets the image description.
        /// </summary>
        /// <value>The image description.</value>
        public string ImageDescription { get; set; } = "";
        /// <summary>
        /// Gets or sets the selected image.
        /// </summary>
        /// <value>The selected image.</value>
        public ImageForUpload SelectedImage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [image add button visible].
        /// </summary>
        /// <value><c>true</c> if [image add button visible]; otherwise, <c>false</c>.</value>
        public bool ImageAddButtonVisible { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [image edit buttons visible].
        /// </summary>
        /// <value><c>true</c> if [image edit buttons visible]; otherwise, <c>false</c>.</value>
        public bool ImageEditButtonsVisible { get; set; } = false;
        /// <summary>
        /// Gets or sets the height of the collection view.
        /// </summary>
        /// <value>The height of the collection view.</value>
        public int CollectionViewHeight { get; set; } = 0;
        /// <summary>
        /// Gets or sets the user message.
        /// </summary>
        /// <value>The user message.</value>
        public UserMessages UserMessage { get; set; }

        //public User User { get; set; }
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Gets or sets the json settings.
        /// </summary>
        /// <value>The json settings.</value>
        public JsonSerializerSettings JsonSettings { get; set; }

        /// <summary>
        /// The is executing
        /// </summary>
        public bool isExecuting = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
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

        /// <summary>
        /// Take photo as an asynchronous operation.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
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
        /// <summary>
        /// Load photo as an asynchronous operation.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
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
        /// <summary>
        /// Adds the image.
        /// </summary>
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
        /// <summary>
        /// Cancels the image.
        /// </summary>
        public async void CancelImage()
        {
            ResetImage();
            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");

        }
        /// <summary>
        /// Updates the image.
        /// </summary>
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
        /// <summary>
        /// Deletes the image.
        /// </summary>
        public async void DeleteImage()
        {
            var selectedImage = TakenImages.Where(x => x.Id == SelectedImage.Id).FirstOrDefault();
            TakenImages.Remove(selectedImage);
            NotifyPropertyChanged("TakenImages");
            await Application.Current.MainPage.DisplayAlert("Notificiation", "Image Deleted", "Ok");

            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");
            ResetImage();
        }
        /// <summary>
        /// Resets the image.
        /// </summary>
        public async void ResetImage()
        {
            ImageName = "";
            ImageDescription = "";
            if (SelectedImage != null)
            {
                SelectedImage = null;
            }

        }
        /// <summary>
        /// Images the tapped.
        /// </summary>
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
        /// <summary>
        /// Checks the and request location permission.
        /// </summary>
        /// <returns>PermissionStatus.</returns>
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

        /// <summary>
        /// Get location as an asynchronous operation.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Check and request permission as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="permission">The permission.</param>
        /// <returns>A Task&lt;PermissionStatus&gt; representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Refreshes the messages.
        /// </summary>
        public async void RefreshMessages()
        {
            var APIConnect = new APIConnect();
            var GetLoggedInUser = APIConnect.GetLoggedInUser();
            UserMessages = APIConnect.GetUserMessages(GetLoggedInUser.User.Id).User.Messages;
            NotifyPropertyChanged("UserMessages");
        }

        /// <summary>
        /// Opens the messages.
        /// </summary>
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

        /// <summary>
        /// Deletes the message.
        /// </summary>
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

        /// <summary>
        /// Replies to message.
        /// </summary>
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

        /// <summary>
        /// Messages the tapped.
        /// </summary>
        /// <param name="selectedItem">The selected item.</param>
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

        /// <summary>
        /// Checks the middleware.
        /// </summary>
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
