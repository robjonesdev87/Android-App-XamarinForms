using App1_0.ViewModels.Canvas;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas.Tabs
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Send<object, string[]>(this, "RefreshWithCanvasData", new string[] { });
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}