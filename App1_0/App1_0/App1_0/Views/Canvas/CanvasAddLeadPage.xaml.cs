using App1_0.Models;
using App1_0.ViewModels;
using App1_0.ViewModels.Canvas;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas
{
    public partial class CanvasAddLeadPage : ContentPage
    {
        public CanvasAddLeadPage()
        {
            InitializeComponent();
            BindingContext = new CanvasAddLeadViewModel();
        }

        private void OnClicked(object sender, EventArgs e)
        {

        }
    }
}