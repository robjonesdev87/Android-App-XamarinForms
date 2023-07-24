using App1_0.Models;
using App1_0.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleMessagePopup : PopupPage
    {
        public SingleMessagePopup(object viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

      
    }
}