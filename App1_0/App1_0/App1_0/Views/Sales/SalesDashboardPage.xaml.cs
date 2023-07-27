// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 11-04-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-08-2023
// ***********************************************************************
// <copyright file="SalesDashboardPage.xaml.cs" company="App1_0">
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

namespace App1_0.Views.Sales
{
    /// <summary>
    /// Class SalesDashboardPage.
    /// Implements the <see cref="TabbedPage" />
    /// </summary>
    /// <seealso cref="TabbedPage" />
    public partial class SalesDashboardPage : TabbedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesDashboardPage"/> class.
        /// </summary>
        public SalesDashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        protected override void OnAppearing()
        {
            //MessagingCenter.Send<object, string[]>(this, "RefreshWithNewData", new string[] { });
        }
    }
}