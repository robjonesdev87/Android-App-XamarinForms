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
    public class CanvasSingleViewModel : BaseViewModel
    {
        public Command UpdateCommand { get; set; }
        public Command CancelCommand { get; set; }
        public bool CanvasComplete { get; set; }
        public bool SalesDataNotSet { get; set; } = false;
        public Client GetClientWithId { get; set; }
   
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

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//CanvasDashboardPage");
        }

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
