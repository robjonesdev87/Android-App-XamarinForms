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
    public partial class App : Application
    {
        public static JobUsers APIUser { get; set; } = new JobUsers();
        public static Settings Settings { get; set; } = new Settings();
        public static APIConnect APIConnect { get; set; } = new APIConnect();
        public static JsonSerializerSettings JsonSettings { get; set; }
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



        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
