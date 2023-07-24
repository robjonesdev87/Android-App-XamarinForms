using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using Xamarin.Forms;
using Android.Locations;
using Android;

using System.Net.Http;
using Plugin.Messaging;
using Xamarin.Essentials;
using Android.Provider;
using Uri = Android.Net.Uri;
using Plugin.FirebasePushNotification;
using Android.Gms.Common;
using Android.Util;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Android.Utils;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;

namespace App1_0.Droid
{
    [Activity(Label = "Window Shine Renovations",
        Icon = "@mipmap/wsicon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )
        ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;
        public Context Context;
        public ContentResolver ContentResolver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Instance = this;
            MessagingCenter.Subscribe<object, string[]>(this, "OpenLocationSettings", (sender, arg) => {
                OpenLocationSettings();
            });

            //MessagingCenter.Subscribe<object, string[]>(this, "StartPhoneCall", (sender, arg) => {
            //    StartPhoneCall();
            //});

            MessagingCenter.Subscribe<object, string>(this, "DeleteNumberFromCallLog", (sender, number) => {
                DeleteNumberFromCallLog(number);
            });

            MessagingCenter.Subscribe<object, string>(this, "BackButtonPressed", (sender, arg) => {
                OnBackPressed();
            });

            IsGoogleServicesAvailable();

            FirebasePushNotificationManager.ProcessIntent(this, Intent);

            CrossMessaging.Current.Settings().Phone.AutoDial = true;
            Context = Android.App.Application.Context;
            ContentResolver = Context.ContentResolver;

            Distribute.ReleaseAvailable = OnReleaseAvailable;
            Distribute.NoReleaseAvailable = OnNoReleaseAvailable;
            Distribute.SetEnabledForDebuggableBuild(true);
            Distribute.SetEnabledAsync(true);

            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
        }


        private bool OnReleaseAvailable(ReleaseDetails releaseDetails)
        {
            string versionName = releaseDetails.ShortVersion;
            string versionCodeOrBuildNumber = releaseDetails.Version;
            string releaseNotes = releaseDetails.ReleaseNotes;

            // custom dialogg
            var title = "Version " + versionName + " available!";
            Task answer;

            // On mandatory update, user can't postpone
            if (releaseDetails.MandatoryUpdate)
            {
                answer = App.Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install");
            }
            else
            {
                answer = App.Current.MainPage.DisplayAlert(title, releaseNotes, "Download and Install", "Maybe tomorrow...");
            }

            answer.ContinueWith((task) =>
            {
                // If mandatory or if answer was positive
                if (releaseDetails.MandatoryUpdate || (task as Task<bool>).Result)
                {
                    // Notify SDK that user selected update
                    Distribute.NotifyUpdateAction(UpdateAction.Update);
                }
                else
                {
                    // Notify SDK that user selected postpone (for 1 day)
                    // This method call is ignored by the SDK if the update is mandatory
                    Distribute.NotifyUpdateAction(UpdateAction.Postpone);
                }
            });

            // Return true if you're using your own dialog, false otherwise
            AppCenterLog.Info("Log", "Release available callback invoked.");
            Analytics.TrackEvent("Release available callback invoked..");
            return true;
        }

        private void OnNoReleaseAvailable()
        {
            AppCenterLog.Info("Log", "No release available callback invoked.  [BUTTON]");
            Analytics.TrackEvent("No release available callback invoked. [BUTTON]");
            
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            FirebasePushNotificationManager.ProcessIntent(this, intent);
        }

        private bool IsGoogleServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    Log.Error("MAINACTIVITY", "SDK not installed");

                }
                else
                {
                    Log.Error("MAINACTIVITY", "This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                Log.Debug("MAINACTIVITY", "Google Services are available");
                return true;
            }
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }
        private void DeleteNumberFromCallLog(String number)
        {
            Uri CALLLOG_URI = Uri.Parse("content://call_log/calls");
            ContentResolver.Delete(CALLLOG_URI, CallLog.Calls.Number + "=?", new String[] { number });
        }
        public bool IsLocationServiceEnabled()
        {
            LocationManager locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
        }
        public bool StartPhoneCall()
        {
            return true;
        }
        public bool OpenLocationSettings()
        {
            var intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
            return true;
        }

        
    }
}