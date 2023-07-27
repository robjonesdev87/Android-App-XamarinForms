// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-08-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-13-2023
// ***********************************************************************
// <copyright file="CanvasSingleViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using App1_0.Views.Surveyor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1_0.ViewModels.Canvas
{
    /// <summary>
    /// Class CanvasSingleViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class CanvasSingleViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the update command.
        /// </summary>
        /// <value>The update command.</value>
        public Command UpdateCommand { get; set; }
        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        /// <value>The cancel command.</value>
        public Command CancelCommand { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [canvas complete].
        /// </summary>
        /// <value><c>true</c> if [canvas complete]; otherwise, <c>false</c>.</value>
        public bool CanvasComplete { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [sales data not set].
        /// </summary>
        /// <value><c>true</c> if [sales data not set]; otherwise, <c>false</c>.</value>
        public bool SalesDataNotSet { get; set; } = false;
        /// <summary>
        /// Gets or sets the get client with identifier.
        /// </summary>
        /// <value>The get client with identifier.</value>
        public Client GetClientWithId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasSingleViewModel"/> class.
        /// </summary>
        public CanvasSingleViewModel()
        {
            UpdateCommand = new Command(UpdateClient);
            CancelCommand = new Command(OnCancel);

            bool hasClient = Preferences.ContainsKey("ClientId");
            if (hasClient)
            {
                var ClientId = Preferences.Get("ClientId", string.Empty);
                GetClientWithId = App.APIConnect.GetClientWithId(ClientId);
            }

            if (GetClientWithId != null)
            {
                //if (GetClientWithId.SalesData.AppointmentDate == null)
                    //SalesDataNotSet = true;

                if (GetClientWithId.Information.EstAge != "" && GetClientWithId.Information.EstAge != null)
                {
                    CanvasComplete = true;
                }
            }

        }

        /// <summary>
        /// Called when [cancel].
        /// </summary>
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//CanvasDashboardPage");
        }

        /// <summary>
        /// Updates the client.
        /// </summary>
        private async void UpdateClient()
        {
            try
            {
                Client client = new Client
                {
                    Id = Preferences.Get("ClientId", string.Empty)
                };

                client.Information = new Information
                {
                    FirstName = GetClientWithId.Information.FirstName,
                    EstAge = GetClientWithId.Information.EstAge,
                    EstOccupation = GetClientWithId.Information.EstOccupation,
                    EstServicesRequired = GetClientWithId.Information.EstServicesRequired,
                    Notes = GetClientWithId.Information.Notes
                };

                if (TakenImages.Count > 0)
                {
                    foreach(var takenImage in TakenImages)
                    {
                        takenImage.ClientId = client.Id;
                        takenImage.FileName = Path.GetFileName(takenImage.Path);
                        takenImage.Type = "Canvas";
                    }
                    var response = App.APIConnect.UploadImages(client.Id,TakenImages);
                }

                App.APIConnect.UpdateClient(client);
                MessagingCenter.Send<object, string[]>(this, "RefreshWithCanvasData", new string[] { });
                await Shell.Current.GoToAsync("//CanvasDashboardPage");
                await Application.Current.MainPage.DisplayAlert("Success", "Client Updated", "Ok");

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
