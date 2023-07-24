﻿using App1_0.ViewModels.Sales;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Surveyor.Tabs
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Send<object, string[]>(this, "RefreshWithSurveyData", new string[] { });
        }

    }
}