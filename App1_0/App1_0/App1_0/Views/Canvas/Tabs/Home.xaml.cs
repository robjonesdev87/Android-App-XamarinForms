// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-15-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-11-2023
// ***********************************************************************
// <copyright file="Home.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.ViewModels.Canvas;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas.Tabs
{
    /// <summary>
    /// Class Home.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class Home : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        public Home()
        {
            InitializeComponent();
        }
        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnAppearing()
        {
            MessagingCenter.Send<object, string[]>(this, "RefreshWithCanvasData", new string[] { });
        }

        /// <summary>
        /// Handles the SelectionChanged event of the CollectionView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}