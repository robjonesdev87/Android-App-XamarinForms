// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-24-2023
// ***********************************************************************
// <copyright file="Settings.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Essentials;

namespace App1_0.Models
{
    /// <summary>
    /// Class Settings.
    /// </summary>
    public class Settings
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings() {

            }
        /// <summary>
        /// Gets the application settings.
        /// </summary>
        /// <value>The application settings.</value>
        private static ISettings AppSettings
            {
                get { return CrossSettings.Current; }
            }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        public static string AccessToken
            {
                get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
            }


    }
}
