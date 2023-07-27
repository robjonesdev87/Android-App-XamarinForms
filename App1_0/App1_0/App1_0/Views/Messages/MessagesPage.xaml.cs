// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 07-05-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 07-19-2023
// ***********************************************************************
// <copyright file="MessagesPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Messages
{
    /// <summary>
    /// Class MessagesPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class MessagesPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesPage"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public MessagesPage(object viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

      
    }
}