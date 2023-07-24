﻿using App1_0.Models;
using App1_0.ViewModels.Trade;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Trade
{
    public partial class TradeDashboardPage : TabbedPage
    {
        public TradeDashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        ViewCell lastCell;
        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.LightGray;
                lastCell = viewCell;
            }
        }

        protected override void OnAppearing()
        {
           
        }
    }
}