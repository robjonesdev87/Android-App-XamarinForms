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
    public class CanvasDashboardViewModel : BaseViewModel
    {
        public APIReturn APIReturn { get; set; }
        public Command ItemTappedCommand { get; set; }
        public Command AddNewLeadCommand { get; set; }
        public bool ActionRequired { get; set; }
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientsWeek { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientsTwoWeeks { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientsUpcoming { get; set; } = new ObservableCollection<Client>();
        public string Welcome { get; set; } = "Welcome Back ";
        public int SelectedTabIndex { get; set; }
        public string ShowSelectedTab { get { return $"Index: {SelectedTabIndex}"; } }

        public CanvasDashboardViewModel()
        {
            ItemTappedCommand = new Command(ItemTapped);
            AddNewLeadCommand = new Command(AddNewLead);
            Welcome += App.APIUser.FirstName;
            MessagingCenter.Subscribe<object, string[]>(this, "RefreshWithCanvasData", (sender, arg) => {
                RefreshWithCanvasData();
            }); 

        }
        
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
        public async void AddNewLead(object selectedItem)
        {
            await Shell.Current.GoToAsync("CanvasAddLeadPage");
        }
        public ICommand OpenWebCommand { get; }


    }
}