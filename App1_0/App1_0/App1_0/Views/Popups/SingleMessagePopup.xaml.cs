// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 07-19-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 07-19-2023
// ***********************************************************************
// <copyright file="SingleMessagePopup.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Popups
{
    /// <summary>
    /// Class SingleMessagePopup.
    /// Implements the <see cref="PopupPage" />
    /// </summary>
    /// <seealso cref="PopupPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleMessagePopup : PopupPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleMessagePopup"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public SingleMessagePopup(object viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

      
    }
}