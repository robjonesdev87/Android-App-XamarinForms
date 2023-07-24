using App1_0.Models;
using App1_0.ViewModels;
using App1_0.ViewModels.Sales;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Sales
{
    public partial class SalesDashboardPage : TabbedPage
    {
        public SalesDashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override void OnAppearing()
        {
            //MessagingCenter.Send<object, string[]>(this, "RefreshWithNewData", new string[] { });
        }
    }
}