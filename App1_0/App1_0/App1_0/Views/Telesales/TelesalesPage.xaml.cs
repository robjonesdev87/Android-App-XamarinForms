using App1_0.Models;
using App1_0.ViewModels;
using App1_0.ViewModels.Sales;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Telesales
{
    public partial class TelesalesPage : ContentPage
    {
        public TelesalesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override void OnAppearing()
        {
           
        }
    }
}