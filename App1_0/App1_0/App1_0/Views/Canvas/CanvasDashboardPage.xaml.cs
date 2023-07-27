// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 11-26-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="CanvasDashboardPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels.Canvas;
using App1_0.Views.Canvas.Tabs;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas
{
    /// <summary>
    /// Class CanvasDashboardPage.
    /// Implements the <see cref="TabbedPage" />
    /// </summary>
    /// <seealso cref="TabbedPage" />
    public partial class CanvasDashboardPage : TabbedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasDashboardPage"/> class.
        /// </summary>
        public CanvasDashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        protected override void OnAppearing()
        {

        }
    }
}