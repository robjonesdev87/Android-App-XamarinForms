// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 11-26-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 12-08-2022
// ***********************************************************************
// <copyright file="CanvasAddLeadPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels;
using App1_0.ViewModels.Canvas;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas
{
    /// <summary>
    /// Class CanvasAddLeadPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class CanvasAddLeadPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasAddLeadPage"/> class.
        /// </summary>
        public CanvasAddLeadPage()
        {
            InitializeComponent();
            BindingContext = new CanvasAddLeadViewModel();
        }

        /// <summary>
        /// Handles the <see cref="E:Clicked" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnClicked(object sender, EventArgs e)
        {

        }
    }
}