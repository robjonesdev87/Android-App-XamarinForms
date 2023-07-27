// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 11-02-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 07-05-2023
// ***********************************************************************
// <copyright file="AppShell.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using App1_0.ViewModels;
using App1_0.Views;
using App1_0.Views.Canvas;
using App1_0.Views.Messages;
using App1_0.Views.Sales;
using App1_0.Views.Surveyor;
using App1_0.Views.Telesales;
using App1_0.Views.Trade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App1_0
{
    /// <summary>
    /// Class AppShell.
    /// Implements the <see cref="Shell" />
    /// </summary>
    /// <seealso cref="Shell" />
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Gets or sets the API connect.
        /// </summary>
        /// <value>The API connect.</value>
        public APIConnect APIConnect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            APIConnect = new APIConnect();
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            Routing.RegisterRoute(nameof(CanvasDashboardPage), typeof(CanvasDashboardPage));
            Routing.RegisterRoute(nameof(CanvasAddLeadPage), typeof(CanvasAddLeadPage));
            Routing.RegisterRoute(nameof(CanvasSinglePage), typeof(CanvasSinglePage));

            Routing.RegisterRoute(nameof(SalesDashboardPage), typeof(SalesDashboardPage));
            Routing.RegisterRoute(nameof(SalesJobPage), typeof(SalesJobPage));
            Routing.RegisterRoute(nameof(SalesSinglePage), typeof(SalesSinglePage));

            Routing.RegisterRoute(nameof(SurveyorDashboardPage), typeof(SurveyorDashboardPage));
            Routing.RegisterRoute(nameof(SurveyorJobPage), typeof(SurveyorJobPage));
            Routing.RegisterRoute(nameof(SurveyorSinglePage), typeof(SurveyorSinglePage));

            Routing.RegisterRoute(nameof(TradeDashboardPage), typeof(TradeDashboardPage));
            Routing.RegisterRoute(nameof(TradeJobPage), typeof(TradeJobPage));
            Routing.RegisterRoute(nameof(TradeSinglePage), typeof(TradeSinglePage));

            Routing.RegisterRoute(nameof(TelesalesPage), typeof(TelesalesPage));

            Routing.RegisterRoute(nameof(MessagesPage), typeof(MessagesPage));

            BindingContext = this;

        }

        /// <summary>
        /// Logouts the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        async void LogoutClicked(object sender, EventArgs args)
        {
            Settings.AccessToken = null;
            Current.FlyoutIsPresented = false;   //close the menu 

            await Current.GoToAsync("//LoginPage");

            foreach (var item in Items)
            {
                if (item.Title == "Dashboard") {
                    Items.Remove(item);
                    break;
                }
            }

        }


    }
}
