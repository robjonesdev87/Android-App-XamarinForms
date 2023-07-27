// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 03-14-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-22-2023
// ***********************************************************************
// <copyright file="TelesalesViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class TelesalesViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class TelesalesViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the API return.
        /// </summary>
        /// <value>The API return.</value>
        public APIReturn APIReturn { get; set; }
        /// <summary>
        /// Gets or sets the item tapped command.
        /// </summary>
        /// <value>The item tapped command.</value>
        public Command ItemTappedCommand { get; set; }
        /// <summary>
        /// Gets or sets the welcome.
        /// </summary>
        /// <value>The welcome.</value>
        public string Welcome { get; set; } = "Welcome Back ";
        /// <summary>
        /// Gets or sets the telesales clients.
        /// </summary>
        /// <value>The telesales clients.</value>
        public ObservableCollection<TelesalesClient> TelesalesClients { get; set; } = new ObservableCollection<TelesalesClient>();

        /// <summary>
        /// The telesales queue
        /// </summary>
        public Queue<TelesalesClient> TelesalesQueue = new Queue<TelesalesClient>();
        /// <summary>
        /// Gets or sets the telesales client.
        /// </summary>
        /// <value>The telesales client.</value>
        public TelesalesClient TelesalesClient { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public ObservableCollection<string> Status { get; set; }
        /// <summary>
        /// Gets or sets the interested level.
        /// </summary>
        /// <value>The interested level.</value>
        public ObservableCollection<string> InterestedLevel { get; set; }
        /// <summary>
        /// Gets or sets the expected start.
        /// </summary>
        /// <value>The expected start.</value>
        public ObservableCollection<string> ExpectedStart { get; set; }
        /// <summary>
        /// Gets or sets the stopwatch.
        /// </summary>
        /// <value>The stopwatch.</value>
        public Stopwatch Stopwatch { get; set; }
        /// <summary>
        /// Gets or sets the call command.
        /// </summary>
        /// <value>The call command.</value>
        public Command CallCommand { get; set; }
        /// <summary>
        /// Gets or sets the no answer command.
        /// </summary>
        /// <value>The no answer command.</value>
        public Command NoAnswerCommand { get; set; }
        /// <summary>
        /// Gets or sets the add note command.
        /// </summary>
        /// <value>The add note command.</value>
        public Command AddNoteCommand { get; set; }
        /// <summary>
        /// Gets or sets the next call command.
        /// </summary>
        /// <value>The next call command.</value>
        public Command NextCallCommand { get; set; }
        /// <summary>
        /// Gets or sets the interested button command.
        /// </summary>
        /// <value>The interested button command.</value>
        public Command InterestedButtonCommand { get; set; }
        /// <summary>
        /// Gets or sets the back button command.
        /// </summary>
        /// <value>The back button command.</value>
        public Command BackButtonCommand { get; set; }
        /// <summary>
        /// Gets or sets the submit button command.
        /// </summary>
        /// <value>The submit button command.</value>
        public Command SubmitButtonCommand { get; set; }
        /// <summary>
        /// Gets or sets the not interested button command.
        /// </summary>
        /// <value>The not interested button command.</value>
        public Command NotInterestedButtonCommand { get; set; }
        /// <summary>
        /// Gets or sets the details incorrect command.
        /// </summary>
        /// <value>The details incorrect command.</value>
        public Command DetailsIncorrectCommand { get; set; }
        /// <summary>
        /// Gets or sets the remove from list command.
        /// </summary>
        /// <value>The remove from list command.</value>
        public Command RemoveFromListCommand { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show client information].
        /// </summary>
        /// <value><c>true</c> if [show client information]; otherwise, <c>false</c>.</value>
        public bool ShowClientInformation { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [show call button].
        /// </summary>
        /// <value><c>true</c> if [show call button]; otherwise, <c>false</c>.</value>
        public bool ShowCallButton { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether [show no answer button].
        /// </summary>
        /// <value><c>true</c> if [show no answer button]; otherwise, <c>false</c>.</value>
        public bool ShowNoAnswerButton { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show notes button].
        /// </summary>
        /// <value><c>true</c> if [show notes button]; otherwise, <c>false</c>.</value>
        public bool ShowNotesButton { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show next call button].
        /// </summary>
        /// <value><c>true</c> if [show next call button]; otherwise, <c>false</c>.</value>
        public bool ShowNextCallButton { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show after call buttons].
        /// </summary>
        /// <value><c>true</c> if [show after call buttons]; otherwise, <c>false</c>.</value>
        public bool ShowAfterCallButtons { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show no clients left].
        /// </summary>
        /// <value><c>true</c> if [show no clients left]; otherwise, <c>false</c>.</value>
        public bool ShowNoClientsLeft { get; set; } = false;
        /// <summary>
        /// Gets or sets the current number.
        /// </summary>
        /// <value>The current number.</value>
        public string CurrentNumber { get; set; } = "";
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; } = "";
        /// <summary>
        /// Gets or sets the budget.
        /// </summary>
        /// <value>The budget.</value>
        public string Budget { get; set; } = "";
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; } = "";
        /// <summary>
        /// Gets or sets a value indicating whether [name incorrect].
        /// </summary>
        /// <value><c>true</c> if [name incorrect]; otherwise, <c>false</c>.</value>
        public bool NameIncorrect { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [address incorrect].
        /// </summary>
        /// <value><c>true</c> if [address incorrect]; otherwise, <c>false</c>.</value>
        public bool AddressIncorrect { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [phone number incorrect].
        /// </summary>
        /// <value><c>true</c> if [phone number incorrect]; otherwise, <c>false</c>.</value>
        public bool PhoneNumberIncorrect { get; set; } = false;
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        public int Index { get; set; }
        /// <summary>
        /// Gets or sets the has errors.
        /// </summary>
        /// <value>The has errors.</value>
        public ObservableCollection<string> HasErrors { get; set; } = new ObservableCollection<string>();
        /// <summary>
        /// Gets or sets the telesales view model.
        /// </summary>
        /// <value>The telesales view model.</value>
        public TelesalesViewModel telesalesViewModel { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TelesalesViewModel"/> class.
        /// </summary>
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
        /// <summary>
        /// Calls this instance.
        /// </summary>
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
        /// <summary>
        /// Submits this instance.
        /// </summary>
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
        /// <summary>
        /// Backs this instance.
        /// </summary>
        public async void Back()
        {
            MessagingCenter.Send<object, string>(this, "BackButtonPressed", "");
        }
        /// <summary>
        /// Removes from list.
        /// </summary>
        public async void RemoveFromList()
        {
            await PopupNavigation.Instance.PushAsync(new RemoveFromListPage(telesalesViewModel));
            Action = "RemoveFromList";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        /// <summary>
        /// Interesteds this instance.
        /// </summary>
        public async void Interested()
        {
            await PopupNavigation.Instance.PushAsync(new InterestedPage(telesalesViewModel));
            Action = "Interested";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        /// <summary>
        /// Nots the interested.
        /// </summary>
        public async void NotInterested()
        {
            await PopupNavigation.Instance.PushAsync(new NotInterestedPage(telesalesViewModel));
            Action = "NotInterested";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        /// <summary>
        /// Detailses the incorrect.
        /// </summary>
        public async void DetailsIncorrect()
        {
            await PopupNavigation.Instance.PushAsync(new DetailsIncorrectPage(telesalesViewModel));
            Action = "DetailsIncorrect";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        /// <summary>
        /// Noes the answer.
        /// </summary>
        public async void NoAnswer()
        {
            await PopupNavigation.Instance.PushAsync(new NoAnswerPage(telesalesViewModel));
            Action = "NoAnswer";
            Stopwatch.Stop();
            MessagingCenter.Send<object, string>(this, "DeleteNumberFromCallLog", TelesalesClient.TelesalesInformation.MobileNumber);
        }
        /// <summary>
        /// Gets the next client in queue.
        /// </summary>
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
        /// <summary>
        /// Places the phone call.
        /// </summary>
        /// <param name="number">The number.</param>
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