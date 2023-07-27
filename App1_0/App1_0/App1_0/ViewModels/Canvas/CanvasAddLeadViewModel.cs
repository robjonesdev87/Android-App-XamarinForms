// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-08-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="CanvasAddLeadViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using System;
using Xamarin.Forms;
using App1_0.API;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;

namespace App1_0.ViewModels.Canvas
{
    /// <summary>
    /// Class CanvasAddLeadViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class CanvasAddLeadViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>The information.</value>
        public Information Information { get; }
        /// <summary>
        /// Gets the canvas data binding.
        /// </summary>
        /// <value>The canvas data binding.</value>
        public CanvasData CanvasDataBinding { get; }
        /// <summary>
        /// Gets or sets the client validation.
        /// </summary>
        /// <value>The client validation.</value>
        public ClientValidation ClientValidation { get; set; }
        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        /// <value>The save command.</value>
        public Command SaveCommand { get; set; }
        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        /// <value>The cancel command.</value>
        public Command CancelCommand { get; set; }
        /// <summary>
        /// Gets or sets the selected date.
        /// </summary>
        /// <value>The selected date.</value>
        public DatePicker SelectedDate { get; set; }
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid { get; set; }
        /// <summary>
        /// Gets or sets the has errors.
        /// </summary>
        /// <value>The has errors.</value>
        public static List<string> HasErrors { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasAddLeadViewModel"/> class.
        /// </summary>
        public CanvasAddLeadViewModel()
        {
            Information = new Information();
            CanvasDataBinding = new CanvasData();    
            ClientValidation = new ClientValidation();
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            HasErrors = new List<string>();

            Information.TitlesCollection = new ObservableCollection<string>
            {
                "Mr",
                "Mrs",
                "Miss",
                "Mr/Mrs",
                "Mr/Miss",
                "Dr",
                "Sir",
                "Lord"
            };

            Information.EmploymentCollection = new ObservableCollection<string>
            {
                "Working",
                "Retired"
            };

            Information.TypeOfHouseCollection = new ObservableCollection<string>
            {
                "New Build",
                "Detatched",
                "Semi Detached",
                "Terraced",
                "Bungalow"
            };

            Information.WindowTypeCollection = new ObservableCollection<string>
            {
                "White UPVC",
                "Honeyoak UPVC",
                "Rosewood UPVC",
                "Grey UPVC",
                "Black UPVC"
            };

            Information.ServiceRequiredCollection = new ObservableCollection<string>
            {
                "Renovation",
                "Give me more john"
            };

        }

        /// <summary>
        /// Called when [cancel].
        /// </summary>
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//CanvasDashboardPage");
        }

        /// <summary>
        /// Called when [save].
        /// </summary>
        private async void OnSave()
        {

            HasErrors.Clear();

            if (!ClientValidation.LastNameValid || string.IsNullOrEmpty(Information.LastName))
            {
                HasErrors.Add("Last Name cannot be empty");
            }

            if (!ClientValidation.AddressValid || string.IsNullOrEmpty(Information.Address))
            {
                HasErrors.Add("Street Name cannot be empty");
            }

            if (!ClientValidation.PostcodeValid || string.IsNullOrEmpty(Information.Postcode))
            {
                HasErrors.Add("Postcode cannot be empty");
            }

            if (CanvasDataBinding.AppointmentDate == null)
            {
                HasErrors.Add("An appointment date needs to be set");
            }

            //HasErrors.Clear(); //DEBUG

            if (HasErrors.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (string str in HasErrors)
                {
                    stringBuilder.Append(str.ToString()).AppendLine();
                }

                await Application.Current.MainPage.DisplayAlert("Issues Detected", stringBuilder.ToString(), "Ok");
            } 
            else
            {

                try
                {
                    CanvasDataBinding.CompletedById = App.APIUser.Id;
                    CanvasDataBinding.CompletedByName = App.APIUser.FirstName + " " + App.APIUser.LastName;
                    CanvasDataBinding.SitFee = App.APIUser.SitFeeAmount;
                    CanvasDataBinding.CommissionFeePercent = App.APIUser.CommissionFeePercent;
                    Information.CreationDate = DateTime.Now;

                    Client client = new Client()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CanvasData = CanvasDataBinding,
                        Information = Information,
                        Source = "App"
                    };

                    App.APIConnect.AddClient(client);

                    if (TakenImages.Count > 0)
                    {
                        foreach (var takenImage in TakenImages)
                        {
                            takenImage.ClientId = client.Id;
                            takenImage.FileName = Path.GetFileName(takenImage.Path);
                            takenImage.Type = "Canvas";
                        }
                        var response = App.APIConnect.UploadImages(client.Id, TakenImages);
                    }

                    MessagingCenter.Send<object, string[]>(this, "RefreshWithCanvasData", new string[] { });

                    await Shell.Current.GoToAsync("//CanvasDashboardPage");
                    await Application.Current.MainPage.DisplayAlert("Success", "Client Successfully Added", "Ok");

                }
                catch (Exception)
                {
                    throw;
                }
                
            }

        }


    }

}
