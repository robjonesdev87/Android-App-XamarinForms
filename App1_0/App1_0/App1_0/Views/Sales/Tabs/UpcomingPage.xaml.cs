// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-20-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-05-2023
// ***********************************************************************
// <copyright file="UpcomingPage.xaml.cs" company="App1_0">
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
    /// Class UpcomingPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class UpcomingPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpcomingPage"/> class.
        /// </summary>
        public UpcomingPage()
        {
            InitializeComponent();
            var test = BindingContext;
            var i = 0;
        }

    
    }
}