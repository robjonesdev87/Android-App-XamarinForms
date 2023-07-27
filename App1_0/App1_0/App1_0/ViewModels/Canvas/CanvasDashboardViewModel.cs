// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-20-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 07-18-2023
// ***********************************************************************
// <copyright file="CanvasDashboardViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using App1_0.Views.Popups;
using Microsoft.AppCenter.Distribute;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1_0.ViewModels.Canvas
{
    /// <summary>
    /// Class CanvasDashboardViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class CanvasDashboardViewModel : BaseViewModel
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
        /// Gets or sets the add new lead command.
        /// </summary>
        /// <value>The add new lead command.</value>
        public Command AddNewLeadCommand { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [action required].
        /// </summary>
        /// <value><c>true</c> if [action required]; otherwise, <c>false</c>.</value>
        public bool ActionRequired { get; set; }
        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
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
        /// Gets or sets the welcome.
        /// </summary>
        /// <value>The welcome.</value>
        public string Welcome { get; set; } = "Welcome Back ";
        /// <summary>
        /// Gets or sets the index of the selected tab.
        /// </summary>
        /// <value>The index of the selected tab.</value>
        public int SelectedTabIndex { get; set; }
        /// <summary>
        /// Gets the show selected tab.
        /// </summary>
        /// <value>The show selected tab.</value>
        public string ShowSelectedTab { get { return $"Index: {SelectedTabIndex}"; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasDashboardViewModel"/> class.
        /// </summary>
        public CanvasDashboardViewModel()
        {
            ItemTappedCommand = new Command(ItemTapped);
            AddNewLeadCommand = new Command(AddNewLead);
            Welcome += App.APIUser.FirstName;
            MessagingCenter.Subscribe<object, string[]>(this, "RefreshWithCanvasData", (sender, arg) => {
                RefreshWithCanvasData();
            }); 

        }

        /// <summary>
        /// Refreshes the with canvas data.
        /// </summary>
        public async void RefreshWithCanvasData()
        {
            Clients.Clear();
            ClientsUpcoming.Clear();
            ClientsWeek.Clear();
            ClientsTwoWeeks.Clear();

            try
            {
                Clients = App.APIConnect.GetAssociatedClients(Settings.AccessToken);
            } catch (Exception ex)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                await Application.Current.MainPage.DisplayAlert("Warning", "API Connection Issue " + ex.Message + ex.InnerException, "Ok");
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
                        DateTime appDate = (DateTime)(client.CanvasData.AppointmentDate ?? DateTime.MinValue);

                        //Action required checks, based off age filled in

                        if (client.Information.EstAge == null)
                        {
                            client.CanvasData.ActionNeeded = true;
                        }

                        if (client.Information.EstAge == "")
                        {
                            client.CanvasData.ActionNeeded = true;
                        }

                        if (appDate >= today)
                        {
                            ClientsUpcoming.Add(client);
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

                NotifyPropertyChanged("Clients");
                NotifyPropertyChanged("ClientsWeek");
                NotifyPropertyChanged("ClientsTwoWeeks");
                NotifyPropertyChanged("ClientsUpcoming");

            } catch (Exception ex)
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
                var clientId = client.Id;
                Preferences.Set("ClientId", clientId);
                await Shell.Current.GoToAsync("//CanvasDashboardPage/CanvasSinglePage");

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
        /// Adds the new lead.
        /// </summary>
        /// <param name="selectedItem">The selected item.</param>
        public async void AddNewLead(object selectedItem)
        {
            await Shell.Current.GoToAsync("CanvasAddLeadPage");
        }
        /// <summary>
        /// Gets the open web command.
        /// </summary>
        /// <value>The open web command.</value>
        public ICommand OpenWebCommand { get; }


    }
}