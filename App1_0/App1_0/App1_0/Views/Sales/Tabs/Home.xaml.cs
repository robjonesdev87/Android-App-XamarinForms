// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-20-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-08-2023
// ***********************************************************************
// <copyright file="Home.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.ViewModels.Sales;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Sales.Tabs
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
        /// Called when [appearing].
        /// </summary>
        protected override void OnAppearing()
        {
            MessagingCenter.Send<object, string[]>(this, "RefreshWithNewData", new string[] { });
        }

    }
}