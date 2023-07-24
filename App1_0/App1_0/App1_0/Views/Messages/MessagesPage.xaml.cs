using App1_0.Models;
using App1_0.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Messages
{
    public partial class MessagesPage : ContentPage
    {
        public MessagesPage(object viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

      
    }
}