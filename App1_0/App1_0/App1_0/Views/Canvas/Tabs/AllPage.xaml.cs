// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-15-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 12-15-2022
// ***********************************************************************
// <copyright file="AllPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.ViewModels.Canvas;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Canvas.Tabs
{
    /// <summary>
    /// Class AllPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class AllPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllPage"/> class.
        /// </summary>
        public AllPage()
        {
            InitializeComponent();
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