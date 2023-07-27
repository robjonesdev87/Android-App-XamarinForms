﻿// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 03-15-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-19-2023
// ***********************************************************************
// <copyright file="InterestedPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.ViewModels.Telesales;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Telesales.Popups
{
    /// <summary>
    /// Class InterestedPage.
    /// Implements the <see cref="PopupPage" />
    /// </summary>
    /// <seealso cref="PopupPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterestedPage : PopupPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterestedPage"/> class.
        /// </summary>
        /// <param name="telesalesViewModel">The telesales view model.</param>
        public InterestedPage(TelesalesViewModel telesalesViewModel)
        {
            BindingContext = telesalesViewModel;
            InitializeComponent();
        }
    }
}