// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 06-27-2023
// ***********************************************************************
// <copyright file="LoginViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1_0.API;
using App1_0.Models;
using Newtonsoft.Json;
using App1_0.Views.Surveyor;
using App1_0.Views.Canvas;
using App1_0.Views.Sales;
using App1_0.Views.Canvas.Tabs;
using App1_0.ViewModels.Trade;
using App1_0.Views.Trade;
using App1_0.Views.Telesales;
using Plugin.FirebasePushNotification;

namespace App1_0.ViewModels
{
    /// <summary>
    /// Class LoginViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the login command.
        /// </summary>
        /// <value>The login command.</value>
        public Command LoginCommand { get; }
        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        /// <value>The user login.</value>
        public UserLogin UserLogin { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            UserLogin = new UserLogin();
            LoginCommand = new Command(OnLoginClicked);
            AutoLogin();

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                var refreshToken = p.Token;
                try
                {
                    App.APIConnect.UpdateFirebaseToken(refreshToken);
                }
                catch (Exception ex)
                {

                }
            };

        }

        /// <summary>
        /// Automatics the login.
        /// </summary>
        public async void AutoLogin()
        {
            try
            {
                var AppShell = Shell.Current as AppShell;
                ShellSection shellSection = new ShellSection
                {
                    Title = "Dashboard"
                };

                if (Settings.AccessToken != null && Settings.AccessToken != "")
                {
                    var loggedInUser = App.APIConnect.GetLoggedInUser();

                    if (loggedInUser.Status == 200)
                    {
                        App.APIUser.Id = loggedInUser.User.Id;
                        App.APIUser.FirstName = loggedInUser.User.FirstName;
                        App.APIUser.LastName = loggedInUser.User.LastName;
                        App.APIUser.RoleName = loggedInUser.User.RoleName;
                        App.APIUser.SitFeeAmount = loggedInUser.User.SitFeeAmount;
                        App.APIUser.CommissionFeePercent = loggedInUser.User.CommissionFeePercent;
                        App.APIUser.FirebaseToken = loggedInUser.User.FirebaseToken;

                        if (App.APIUser.RoleName == "Canvaser")
                        {
                            shellSection.Items.Add(new ShellContent() { Route = "CanvasDashboardPage", IsVisible = true, Content = new CanvasDashboardPage() });
                            shellSection.Items.Add(new ShellContent() { Route = "CanvasAddLeadPage", IsVisible = false, Content = new CanvasAddLeadPage() });
                            shellSection.Items.Add(new ShellContent() { Route = "CanvasSinglePage", IsVisible = false, Content = new CanvasSinglePage() });
                            AppShell.CurrentItem = shellSection;
                        }

                        if (App.APIUser.RoleName == "Salesman")
                        {
                            shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new SalesDashboardPage() });
                            shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SalesJobPage() });
                            shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SalesSinglePage() });
                            AppShell.CurrentItem = shellSection;
                        }

                        if (App.APIUser.RoleName == "Surveyor")
                        {
                            shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new SurveyorDashboardPage() });
                            shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SurveyorJobPage() });
                            shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SurveyorSinglePage() });
                            AppShell.CurrentItem = shellSection;
                        }

                        if (App.APIUser.RoleName == "Tradesman")
                        {
                            shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new TradeDashboardPage() });
                            AppShell.CurrentItem = shellSection;
                        }

                        if (App.APIUser.RoleName == "Telesales")
                        {
                            shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new TelesalesPage() });
                            AppShell.CurrentItem = shellSection;
                        }

                        GetLocationAsync();

                        var token = CrossFirebasePushNotification.Current.Token;

                        if (token != "")
                        {
                            try
                            {
                                App.APIConnect.UpdateFirebaseToken(token);
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        await Application.Current.MainPage.DisplayAlert("Success", "You have logged in successfully", "Ok");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Warning", "Auto Login Failed", "Ok");
                        await Shell.Current.GoToAsync("//LoginPage");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "Auto Login Failed", "Ok");
                    await Shell.Current.GoToAsync("//LoginPage");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                await Application.Current.MainPage.DisplayAlert("Warning", "Auto Login Failed " + ex.Message, "Ok");
            }
        }

        /// <summary>
        /// Called when [login clicked].
        /// </summary>
        /// <param name="obj">The object.</param>
        private async void OnLoginClicked(object obj)
        {

            //var test = (Shell.Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage; GET CURRENT PAGE

            var AppShell = Shell.Current as AppShell;
            ShellSection shellSection = new ShellSection
            {
                Title = "Dashboard"
            };

            try
            {
                
                var response = App.APIConnect.Login(UserLogin.Username, UserLogin.Password);

                if (response.Status == 200)
                {
                    var loggedInUser = App.APIConnect.GetLoggedInUser();
                    App.APIUser.Id = loggedInUser.User.Id;
                    App.APIUser.FirstName = loggedInUser.User.FirstName;
                    App.APIUser.LastName = loggedInUser.User.LastName;
                    App.APIUser.RoleName = loggedInUser.User.RoleName;
                    App.APIUser.SitFeeAmount = loggedInUser.User.SitFeeAmount;
                    App.APIUser.CommissionFeePercent = loggedInUser.User.CommissionFeePercent;
                    App.APIUser.FirebaseToken = loggedInUser.User.FirebaseToken;

                    if (App.APIUser.RoleName == "Canvaser")
                    {
                        shellSection.Items.Add(new ShellContent() { Route = "CanvasDashboardPage", IsVisible = true, Content = new CanvasDashboardPage() });
                        shellSection.Items.Add(new ShellContent() { Route = "CanvasAddLeadPage", IsVisible = false, Content = new CanvasAddLeadPage() });
                        shellSection.Items.Add(new ShellContent() { Route = "CanvasSinglePage", IsVisible = false, Content = new CanvasSinglePage() });
                        AppShell.CurrentItem = shellSection;
                    }

                    if (App.APIUser.RoleName == "Salesman")
                    {
                        shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new SalesDashboardPage() });
                        shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SalesJobPage() });
                        shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SalesSinglePage() });
                        AppShell.CurrentItem = shellSection;
                    }

                    if (App.APIUser.RoleName == "Surveyor")
                    {
                        shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new SurveyorDashboardPage()});
                        shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SurveyorJobPage() });
                        shellSection.Items.Add(new ShellContent() { IsVisible = false, Content = new SurveyorSinglePage() });
                        AppShell.CurrentItem = shellSection;
                    }

                    if (App.APIUser.RoleName == "Tradesman")
                    {
                        shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new TradeDashboardPage() });
                        AppShell.CurrentItem = shellSection;
                    }

                    if (App.APIUser.RoleName == "Telesales")
                    {
                        shellSection.Items.Add(new ShellContent() { IsVisible = true, Content = new TelesalesPage() });
                        AppShell.CurrentItem = shellSection;
                    }

                    GetLocationAsync();

                    var token = CrossFirebasePushNotification.Current.Token;

                    if (token != "")
                    {
                        try
                        {
                            App.APIConnect.UpdateFirebaseToken(token);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    await Application.Current.MainPage.DisplayAlert("Success", "You have logged in successfully", "Ok");

                }
                else
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                    await Application.Current.MainPage.DisplayAlert("Error", "Your password or username does not match our records", "Ok");
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                await Application.Current.MainPage.DisplayAlert("Warning", "Login Failure " + ex.Message + ex.InnerException, "Ok");
            }
        }
    }
}
