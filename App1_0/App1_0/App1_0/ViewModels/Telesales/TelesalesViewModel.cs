using App1_0.API;
using App1_0.Models;
using App1_0.Views.Telesales.Popups;
using Newtonsoft.Json;
using Plugin.Messaging;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1_0.ViewModels.Telesales
{
    public class TelesalesViewModel : BaseViewModel
    {
        public APIReturn APIReturn { get; set; }
        public Command ItemTappedCommand { get; set; }
        public string Welcome { get; set; } = "Welcome Back ";
        public ObservableCollection<TelesalesClient> TelesalesClients { get; set; } = new ObservableCollection<TelesalesClient>();

        public Queue<TelesalesClient> TelesalesQueue = new Queue<TelesalesClient>();
        public TelesalesClient TelesalesClient { get; set; }
        public ObservableCollection<string> Status { get; set; } 
        public ObservableCollection<string> InterestedLevel { get; set; }
        public ObservableCollection<string> ExpectedStart { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public Command CallCommand { get; set; }
        public Command NoAnswerCommand { get; set; }
        public Command AddNoteCommand { get; set; }
        public Command NextCallCommand { get; set; }
        public Command InterestedButtonCommand { get; set; }
        public Command BackButtonCommand { get; set; }
        public Command SubmitButtonCommand { get; set; }
        public Command NotInterestedButtonCommand { get; set; }
        public Command DetailsIncorrectCommand { get; set; }
        public Command RemoveFromListCommand { get; set; }
        public bool ShowClientInformation { get; set; } = true;
        public bool ShowCallButton { get; set; } = true;
        public bool ShowNoAnswerButton { get; set; } = false;
        public bool ShowNotesButton { get; set; } = false;
        public bool ShowNextCallButton { get; set; } = false;
        public bool ShowAfterCallButtons { get; set; } = false;
        public bool ShowNoClientsLeft { get; set; } = false;
        public string CurrentNumber { get; set; } = "";
        public string Notes { get; set; } = "";
        public string Budget { get; set; } = "";
        public string Action { get; set; } = "";
        public bool NameIncorrect { get; set; } = false;
        public bool AddressIncorrect { get; set; } = false;
        public bool PhoneNumberIncorrect { get; set; } = false;
        public int Index { get; set; }
        public ObservableCollection<string> HasErrors { get; set; } = new ObservableCollection<string>();
        public TelesalesViewModel telesalesViewModel { get; set; }
        public TelesalesViewModel()
        {
            //RefreshDataButtonCommand = new Command(RefreshDataButton);
            Welcome += App.APIUser.FirstName;
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            telesalesViewModel = this;
            NotifyPropertyChanged("telesalesViewModel");

            CallCommand = new Command(Call);
            NoAnswerCommand = new Command(NoAnswer);
            InterestedButtonCommand = new Command(Interested);
            NotInterestedButtonCommand = new Command(NotInterested);
            DetailsIncorrectCommand = new Command(DetailsIncorrect);
            RemoveFromListCommand = new Command(RemoveFromList);

            SubmitButtonCommand = new Command(Submit);
            BackButtonCommand = new Command(Back);

            Status = new ObservableCollection<string>
            {
                "Would Not Disclose",
                "Renting",
                "Home Owner",
                "Landlord",
            };

            InterestedLevel = new ObservableCollection<string>
            {
                "Slightly Interested",
                "Very Interested",
            };

            ExpectedStart = new ObservableCollection<string>
            {
                "Would Not Disclose",
                "1 - 3 Months",
                "3 - 6 Months",
                "6 - 9 Months",
                "9 - 12 Months",
                "1 Year+",
            };


            Stopwatch = new Stopwatch();

            try
            {
                if (Index == 0)
                {
                    var apiTelesalesClients = App.APIConnect.GetAllTelesalesClients(Settings.AccessToken);

                    //If contacted = 1 & no answer = 1 & date > 7days from now
                    var allTelesalesClients = apiTelesalesClients.Where(a => a.ContactedTimes == 0).Where(b => b.RemoveFromList == 0).ToList();
                    foreach (var telesalesClient in allTelesalesClients)
                    {
                        TelesalesClients.Add(telesalesClient);
                    }

                    GetNextClientInQueue();
                }
            }
            catch (Exception ex)
            {
                 Shell.Current.GoToAsync("//LoginPage");
                 Application.Current.MainPage.DisplayAlert("Warning", "Error Retrieving Clients: " + ex.Message + ex.InnerException, "Ok");
            }

        }
        public async void Call()
        {

            Stopwatch.Start();

            ShowCallButton = false;
            ShowAfterCallButtons = true;
            NotifyPropertyChanged("ShowCallButton");
            NotifyPropertyChanged("ShowAfterCallButtons");

            await Permissions.RequestAsync<Permissions.Phone>();

            PlacePhoneCall(TelesalesClient.TelesalesInformation.MobileNumber);
        }
        public async void Submit()
        {
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);

            Index++;
            HasErrors.Clear();

            TelesalesClient telesalesClient = new TelesalesClient();
            telesalesClient.Id = TelesalesClient.Id;

            switch (Action)
            {
                case "Interested":

                    if (TelesalesClient.Status == "")
                    {
                        HasErrors.Add("Status Required");
                    } 

                    if (TelesalesClient.InterestedLevel == "")
                    {
                        HasErrors.Add("Interest Level Required");
                    }

                    if (TelesalesClient.ExpectedStart == "")
                    {
                        HasErrors.Add("Expected Start Required");
                    } 

                    if (TelesalesClient.ServiceRequired == "")
                    {
                        HasErrors.Add("Services Required");
                    }

                    telesalesClient.Interested = 1;
                    telesalesClient.LastCallLength = ((int)Stopwatch.Elapsed.TotalSeconds);
                    telesalesClient.Status = TelesalesClient.Status;
                    telesalesClient.InterestedLevel = TelesalesClient.InterestedLevel;
                    telesalesClient.ExpectedStart = TelesalesClient.ExpectedStart;
                    telesalesClient.ServiceRequired = TelesalesClient.ServiceRequired;
                    telesalesClient.Notes = TelesalesClient.Notes;
                    telesalesClient.Budget = TelesalesClient.Budget;

                    break;

                case "NotInterested":

                    if (TelesalesClient.Status == "")
                    {
                        HasErrors.Add("Status Required");
                    }

                    telesalesClient.NotInterested = 1;
                    telesalesClient.LastCallLength = ((int)Stopwatch.Elapsed.TotalSeconds);
                    telesalesClient.Status = TelesalesClient.Status;
                    telesalesClient.InterestedLevel = "Not Interested";

                    break;

                case "DetailsIncorrect":

                    if(NameIncorrect)
                    {
                        telesalesClient.NameValid = 0;
                    }
                    if (AddressIncorrect)
                    {
                        telesalesClient.AddressValid = 0;
                    }
                    if (PhoneNumberIncorrect)
                    {
                        telesalesClient.PhoneNumberValid = 0;
                        telesalesClient.NoAnswer = 1;
                    }

                    if (!NameIncorrect && !AddressIncorrect && !PhoneNumberIncorrect)
                    {
                        HasErrors.Add("Please Select at Least 1 Option");
                    }

                    telesalesClient.LastCallLength = ((int)Stopwatch.Elapsed.TotalSeconds);

                    break;

                case "NoAnswer":
                    telesalesClient.NoAnswer = 1;
                    break;

                case "RemoveFromList":
                    telesalesClient.RemoveFromList = 1;
                    telesalesClient.LastCallLength = ((int)Stopwatch.Elapsed.TotalSeconds);
                    break;

                default:
                    break;
            }

            telesalesClient.ContactedTimes = TelesalesClient.ContactedTimes += 1;

            if (HasErrors.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (string str in HasErrors)
                {
                    stringBuilder.Append(str.ToString()).AppendLine();
                }

                await Application.Current.MainPage.DisplayAlert("Issues Detected", stringBuilder.ToString(), "Ok");
            } else
            {
                var response = App.APIConnect.UpdateTeleSalesClient(telesalesClient);
                await Application.Current.MainPage.DisplayAlert("Updated", "Client Updated", "Ok");
                Back();
                GetNextClientInQueue();
            }

        }
        public async void Back()
        {
            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");
        }
        public async void RemoveFromList()
        {
            await PopupNavigation.Instance.PushAsync(new RemoveFromListPage(telesalesViewModel));
            Action = "RemoveFromList";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        public async void Interested()
        {
            await PopupNavigation.Instance.PushAsync(new InterestedPage(telesalesViewModel));
            Action = "Interested";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        public async void NotInterested()
        {
            await PopupNavigation.Instance.PushAsync(new NotInterestedPage(telesalesViewModel));
            Action = "NotInterested";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        public async void DetailsIncorrect()
        {
            await PopupNavigation.Instance.PushAsync(new DetailsIncorrectPage(telesalesViewModel));
            Action = "DetailsIncorrect";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        public async void NoAnswer()
        {
            await PopupNavigation.Instance.PushAsync(new NoAnswerPage(telesalesViewModel));
            Action = "NoAnswer";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        public async void GetNextClientInQueue()
        {
            ShowAfterCallButtons = false;
            ShowCallButton = true;
            NotifyPropertyChanged("ShowAfterCallButtons");
            NotifyPropertyChanged("ShowCallButton");

            if (Index != TelesalesClients.Count)
            {
                TelesalesClient = TelesalesClients[Index];
                NotifyPropertyChanged("TelesalesClient");
            } else
            {
                ShowAfterCallButtons = false;
                ShowCallButton = false;
                ShowClientInformation = false;
                ShowNoClientsLeft = true;
                NotifyPropertyChanged("ShowAfterCallButtons");
                NotifyPropertyChanged("ShowCallButton");
                NotifyPropertyChanged("ShowClientInformation");
                NotifyPropertyChanged("ShowNoClientsLeft");
            }


        }
        public void PlacePhoneCall(string number)
        {

            try
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                {
                    phoneDialer.MakePhoneCall(number);
                }

            }
            catch (ArgumentNullException anEx)
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Number was null or has white space", "Ok");
            }
            catch (FeatureNotSupportedException ex)
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Phone Dialer is not supported on this device.: " + ex.Message + ex.InnerException, "Ok");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Uknown Error Occurred: " + ex.Message + ex.InnerException, "Ok");
            }
        }
    }
}