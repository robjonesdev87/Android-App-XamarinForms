// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 03-13-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-13-2023
// ***********************************************************************
// <copyright file="TelesalesPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels;
using App1_0.ViewModels.Sales;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Telesales
{
    /// <summary>
    /// Class TelesalesPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class TelesalesPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelesalesPage"/> class.
        /// </summary>
        public TelesalesPage()
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