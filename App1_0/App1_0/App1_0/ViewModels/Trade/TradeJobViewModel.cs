// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 02-17-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 02-23-2023
// ***********************************************************************
// <copyright file="TradeJobViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using App1_0.Views.Trade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1_0.ViewModels.Trade
{
    /// <summary>
    /// Class TradeJobViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class TradeJobViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the job tapped command.
        /// </summary>
        /// <value>The job tapped command.</value>
        public Command JobTappedCommand { get; set; }
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public Client Client { get; set; }
        /// <summary>
        /// Gets or sets the single jobs title.
        /// </summary>
        /// <value>The single jobs title.</value>
        public string SingleJobsTitle { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeJobViewModel"/> class.
        /// </summary>
        public TradeJobViewModel()
        {

            JobTappedCommand = new Command(JobTapped);

            bool hasClient = Preferences.ContainsKey("Client");
            if (hasClient)
            {
                var clientVal = Preferences.Get("Client", string.Empty);
                Client = JsonConvert.DeserializeObject<Client>(clientVal, JsonSettings);
                SingleJobsTitle = "Appointments For " + Client.Information.Title + " " + Client.Information.LastName;
            }
        }
        /// <summary>
        /// Jobs the tapped.
        /// </summary>
        /// <param name="selectedItem">The selected item.</param>
        public async void JobTapped(object selectedItem)
        {

            if (isExecuting)
                return;
            try
            {
                isExecuting = true;

                var selected = selectedItem as ItemTappedEventArgs;
                var job = selected.Item as Job;

                string jsonJob = JsonConvert.SerializeObject(job);
                string jsonClient = JsonConvert.SerializeObject(Client);

                Preferences.Set("Job", jsonJob);
                Preferences.Set("Client", jsonClient);

                await Shell.Current.GoToAsync("TradeSinglePage");

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

    }
}
