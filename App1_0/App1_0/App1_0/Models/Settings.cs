using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Essentials;

namespace App1_0.Models
{
    public class Settings
    {

            public Settings() {

            }
            private static ISettings AppSettings
            {
                get { return CrossSettings.Current; }
            }

            public static string AccessToken
            {
                get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty);
                set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
            }


    }
}
