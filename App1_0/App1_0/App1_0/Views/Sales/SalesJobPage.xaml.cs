// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-04-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 01-04-2023
// ***********************************************************************
// <copyright file="SalesJobPage.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_0.Views.Sales
{
    /// <summary>
    /// Class SalesJobPage.
    /// Implements the <see cref="ContentPage" />
    /// </summary>
    /// <seealso cref="ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesJobPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesJobPage"/> class.
        /// </summary>
        public SalesJobPage()
        {
            InitializeComponent();
        }
    }
}