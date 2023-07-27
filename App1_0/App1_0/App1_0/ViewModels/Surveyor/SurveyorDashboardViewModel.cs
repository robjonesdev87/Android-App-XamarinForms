// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-08-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-27-2023
// ***********************************************************************
// <copyright file="SurveyorDashboardViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1_0.ViewModels.Surveyor
{
    /// <summary>
    /// Class SurveyorDashboardViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class SurveyorDashboardViewModel : BaseViewModel
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
        /// Gets or sets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        /// <summary>
        /// Gets or sets the filtered clients.
        /// </summary>
        /// <value>The filtered clients.</value>
        public ObservableCollection<Client> FilteredClients { get; set; } = new ObservableCollection<Client>();
        /// <summary>
        /// Gets or sets the clients week.
        /// </summary>
        /// <value>The clients week.</value>
        public ObservableCollection<Client> ClientsWeek { get; set; } = new ObservableCollection<Client>();
        /// <summary>
        /// Gets or sets the clients two weeks.
        /// </summary>
        /// <value>The clients two weeks.</value>
        public ObservableCollection<Client> ClientsTwoWeeks { get; set; } = new ObservableCollection<Client>();
        /// <summary>
        /// Gets or sets the clients upcoming.
        /// </summary>
        /// <value>The clients upcoming.</value>
        public ObservableCollection<Client> ClientsUpcoming { get; set; } = new ObservableCollection<Client>();
        /// <summary>
        /// Gets or sets the expander.
        /// </summary>
        /// <value>The expander.</value>
        public ICommand Expander { set; get; }
        /// <summary>
        /// Gets or sets the json settings.
        /// </summary>
        /// <value>The json settings.</value>
        public JsonSerializerSettings JsonSettings { get; set; }
        /// <summary>
        /// Gets or sets the refresh data button command.
        /// </summary>
        /// <value>The refresh data button command.</value>
        public Command RefreshDataButtonCommand { get; set; }
        /// <summary>
        /// Gets or sets the surveyor dashboard view model.
        /// </summary>
        /// <value>The surveyor dashboard view model.</value>
        public SurveyorDashboardViewModel surveyorDashboardViewModel { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyorDashboardViewModel"/> class.
        /// </summary>
        public SurveyorDashboardViewModel()
        {
            ItemTappedCommand = new Command(ItemTapped);
            //RefreshDataButtonCommand = new Command(RefreshDataButton);
            Welcome += App.APIUser.FirstName;
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            surveyorDashboardViewModel = this;
            NotifyPropertyChanged("surveyorDashboardViewModel");

            MessagingCenter.Subscribe<object, string[]>(this, "RefreshWithSurveyData", (sender, arg) => {
                RefreshWithSurveyData();
            });

        }

        /// <summary>
        /// Refreshes the with survey data.
        /// </summary>
        public async void RefreshWithSurveyData()
        {
            Clients.Clear();
            ClientsUpcoming.Clear();
            ClientsWeek.Clear();
            ClientsTwoWeeks.Clear();
            FilteredClients.Clear();

            try
            {
                Clients = App.APIConnect.GetClientsWithJobUser(Settings.AccessToken);
            }
            catch (Exception ex)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                await Application.Current.MainPage.DisplayAlert("Warning", ex.Message + ex.InnerException, "Ok");
            }
            try
            {
                DateTime weekStartDate = DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek);
                DateTime weekEndDate = DateTime.Now.AddDays(DayOfWeek.Sunday - DateTime.Now.DayOfWeek + 7);

                DateTime twoWeeksStartDate = DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek - 7);
                DateTime twoWeeksEndDate = DateTime.Now.AddDays(DayOfWeek.Sunday - DateTime.Now.DayOfWeek);

                DateTime today = DateTime.Now;

                if (Clients != null)
                {
                    foreach (var client in Clients)
                    {
                        if (client.Active == 1)
                        {
                            foreach (var job in client.Jobs)
                            {
                                DateTime appDate = (DateTime)(job.SurveyData.AppointmentDate ?? DateTime.MinValue);

                                if (!FilteredClients.Contains(client))
                                {
                                    FilteredClients.Add(client);
                                }

                                if (appDate >= today)
                                {
                                    if (!ClientsUpcoming.Contains(client))
                                    {
                                        ClientsUpcoming.Add(client);
                                    }
                                }

                                if (appDate >= weekStartDate && appDate < weekEndDate)
                                {
                                    if (!ClientsUpcoming.Contains(client))
                                    {
                                        ClientsWeek.Add(client);
                                    }
                                }
                                if (appDate >= twoWeeksStartDate && appDate < twoWeeksEndDate)
                                {
                                    if (!ClientsTwoWeeks.Contains(client))
                                    {
                                        ClientsTwoWeeks.Add(client);
                                    }
                                }
                            }
                        }
                    }
                }

                NotifyPropertyChanged("FilteredClients");
                NotifyPropertyChanged("ClientsWeek");
                NotifyPropertyChanged("ClientsTwoWeeks");
                NotifyPropertyChanged("ClientsUpcoming");
            }
            catch (Exception ex)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                await Application.Current.MainPage.DisplayAlert("Warning", "Error Retrieving Clients: " + ex.Message + ex.InnerException, "Ok");
            }

        }
        /// <summary>
        /// Items the tapped.
        /// </summary>
        /// <param name="selectedItem">The selected item.</param>
        public async void ItemTapped(object selectedItem)
        {

            if (isExecuting)
                return;
            try
            {
                isExecuting = true;

                var selected = selectedItem as ItemTappedEventArgs;
                var client = selected.Item as Client;
                string jsonClient = JsonConvert.SerializeObject(client);
                Preferences.Set("Client", jsonClient);

                await Shell.Current.GoToAsync("SurveyorJobPage");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", ex.Message, "Ok");
            }
            finally
            {
                isExecuting = false;
            }
        }
        /// <summary>
        /// Gets the open web command.
        /// </summary>
        /// <value>The open web command.</value>
        public ICommand OpenWebCommand { get; }
    }
}