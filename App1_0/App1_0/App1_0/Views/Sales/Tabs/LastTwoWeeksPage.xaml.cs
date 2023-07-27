// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-20-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-05-2023
// ***********************************************************************
// <copyright file="LastTwoWeeksPage.xaml.cs" company="App1_0">
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
    /// Class LastTwoWeeksPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class LastTwoWeeksPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LastTwoWeeksPage"/> class.
        /// </summary>
        public LastTwoWeeksPage()
        {
            InitializeComponent();
            var test = BindingContext;
            var i = 0;
        }

        /// <summary>
        /// The last cell
        /// </summary>
        ViewCell lastCell;
        /// <summary>
        /// Handles the Tapped event of the ViewCell control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.LightGray;
                lastCell = viewCell;
            }
        }

    }
}