using App1_0.Models;
using App1_0.ViewModels.Canvas;
using App1_0.Views.Canvas.Tabs;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas
{
    public partial class CanvasDashboardPage : TabbedPage
    {
        public CanvasDashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        protected override void OnAppearing()
        {

        }
    }
}