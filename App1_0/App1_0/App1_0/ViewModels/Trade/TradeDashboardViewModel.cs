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

namespace App1_0.ViewModels.Trade
{
    public class TradeDashboardViewModel : BaseViewModel
    {
        public APIReturn APIReturn { get; set; }
        public Command ItemTappedCommand { get; set; }
        public string Welcome { get; set; } = "Welcome Back ";
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> FilteredClients { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientsWeek { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientsTwoWeeks { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Client> ClientsUpcoming { get; set; } = new ObservableCollection<Client>();
        public ICommand Expander { set; get; }
        public JsonSerializerSettings JsonSettings { get; set; }
        public Command RefreshDataButtonCommand { get; set; }
        public TradeDashboardViewModel tradeDashboardViewModel { get; set; }
        public TradeDashboardViewModel()
        {
            ItemTappedCommand = new Command(ItemTapped);
            //RefreshDataButtonCommand = new Command(RefreshDataButton);
            Welcome += App.APIUser.FirstName;
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            tradeDashboardViewModel = this;
            NotifyPropertyChanged("tradeDashboardViewModel");

            MessagingCenter.Subscribe<object, string[]>(this, "RefreshWithTradeData", (sender, arg) => {
                RefreshWithTradeData();
            });

        }

        public async void RefreshWithTradeData()
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
                                if (job.TradeData.LeadTradesmanId == App.APIUser.Id || job.TradeData.Accepted == 1)
                                {

                                    DateTime appDate = (DateTime)(job.TradeData.AppointmentDate ?? DateTime.MinValue);

                                    if (!FilteredClients.Contains(client)) { 
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

                await Shell.Current.GoToAsync("TradeJobPage");

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
        public ICommand OpenWebCommand { get; }
    }
}