// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 07-18-2023
// ***********************************************************************
// <copyright file="App.xaml.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using App1_0.Views;
using Newtonsoft.Json;
using Plugin.FirebasePushNotification;
using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace App1_0
{
    /// <summary>
    /// Class App.
    /// Implements the <see cref="Application" />
    /// </summary>
    /// <seealso cref="Application" />
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the API user.
        /// </summary>
        /// <value>The API user.</value>
        public static JobUsers APIUser { get; set; } = new JobUsers();
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public static Settings Settings { get; set; } = new Settings();
        /// <summary>
        /// Gets or sets the API connect.
        /// </summary>
        /// <value>The API connect.</value>
        public static APIConnect APIConnect { get; set; } = new APIConnect();
        /// <summary>
        /// Gets or sets the json settings.
        /// </summary>
        /// <value>The json settings.</value>
        public static JsonSerializerSettings JsonSettings { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            Sharpnado.Tabs.Initializer.Initialize(false, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            MainPage = new AppShell();
            //User = new User();



            string accessToken = "";
            bool hasToken = Preferences.ContainsKey("AccessToken");
            if (hasToken)
            {
                accessToken = Preferences.Get("AccessToken", string.Empty);
            }

            Preferences.Clear();
            Settings.AccessToken = accessToken;
            JsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnStart()
        {
            CultureInfo englishGBCulture = new CultureInfo("en-GB");
            CultureInfo.DefaultThreadCurrentCulture = englishGBCulture;
            CultureInfo.DefaultThreadCurrentUICulture = englishGBCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = englishGBCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = englishGBCulture;

            AppCenter.Start("android=9688366d-8938-4c0f-ac92-c0b61fe54ded",
                   typeof(Analytics), typeof(Crashes), typeof(Distribute));
            bool enabled = Distribute.IsEnabledAsync().Result;
            //AppCenter.LogLevel = LogLevel.Verbose;

        }



        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// Called when [resume].
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
