using App1_0.API;
using App1_0.Models;
using App1_0.Views.Surveyor;
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

namespace App1_0.ViewModels.Surveyor
{
    public class SurveyorJobViewModel : BaseViewModel
    {
        public Command JobTappedCommand { get; set; }
        public Client Client { get; set; }
        public string SingleJobsTitle { get; set; }
        public SurveyorJobViewModel()
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

                await Shell.Current.GoToAsync("SurveyorSinglePage");

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
