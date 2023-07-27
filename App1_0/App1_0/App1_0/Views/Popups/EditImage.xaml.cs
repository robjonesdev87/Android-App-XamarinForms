// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 04-11-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 04-11-2023
// ***********************************************************************
// <copyright file="EditImage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models;
using App1_0.ViewModels.Telesales;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Popups
{
    /// <summary>
    /// Class EditImage.
    /// Implements the <see cref="PopupPage" />
    /// </summary>
    /// <seealso cref="PopupPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditImage : PopupPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EditImage"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public EditImage(object viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}