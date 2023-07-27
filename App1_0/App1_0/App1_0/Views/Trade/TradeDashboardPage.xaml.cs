﻿// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 02-17-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 02-17-2023
// ***********************************************************************
// <copyright file="TradeDashboardPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels.Trade;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Trade
{
    /// <summary>
    /// Class TradeDashboardPage.
    /// Implements the <see cref="TabbedPage" />
    /// </summary>
    /// <seealso cref="TabbedPage" />
    public partial class TradeDashboardPage : TabbedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeDashboardPage"/> class.
        /// </summary>
        public TradeDashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        /// <summary>
        /// The last cell
        /// </summary>
        ViewCell lastCell;
        /// <summary>
        /// Handles the Tapped event of the ViewCell control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        protected override void OnAppearing()
        {
           
        }
    }
}