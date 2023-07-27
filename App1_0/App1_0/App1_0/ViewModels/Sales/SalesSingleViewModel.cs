// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-06-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 04-28-2023
// ***********************************************************************
// <copyright file="SalesSingleViewModel.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.API;
using App1_0.Models;
using App1_0.Models.PostData;
using App1_0.Views.Surveyor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1_0.ViewModels.Sales
{
    /// <summary>
    /// Class SalesSingleViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class SalesSingleViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the modal popup command.
        /// </summary>
        /// <value>The modal popup command.</value>
        public Command ModalPopupCommand { get; set; }
        /// <summary>
        /// Gets or sets the modal cancel command.
        /// </summary>
        /// <value>The modal cancel command.</value>
        public Command ModalCancelCommand { get; set; }
        /// <summary>
        /// Gets or sets the client validation.
        /// </summary>
        /// <value>The client validation.</value>
        public ClientValidation ClientValidation { get; set; }
        /// <summary>
        /// Gets or sets the job accept command.
        /// </summary>
        /// <value>The job accept command.</value>
        public Command JobAcceptCommand { get; set; }
        /// <summary>
        /// Gets or sets the job decline command.
        /// </summary>
        /// <value>The job decline command.</value>
        public Command JobDeclineCommand { get; set; }
        /// <summary>
        /// Gets or sets the job complete command.
        /// </summary>
        /// <value>The job complete command.</value>
        public Command JobCompleteCommand { get; set; }
        /// <summary>
        /// Gets or sets the job failure command.
        /// </summary>
        /// <value>The job failure command.</value>
        public Command JobFailureCommand { get; set; }
        /// <summary>
        /// Gets or sets the error count.
        /// </summary>
        /// <value>The error count.</value>
        public int ErrorCount { get; set; } = 0;
        /// <summary>
        /// Gets or sets a value indicating whether [job decline section visible].
        /// </summary>
        /// <value><c>true</c> if [job decline section visible]; otherwise, <c>false</c>.</value>
        public bool JobDeclineSectionVisible { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [job failure section visible].
        /// </summary>
        /// <value><c>true</c> if [job failure section visible]; otherwise, <c>false</c>.</value>
        public bool JobFailureSectionVisible { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [hide all].
        /// </summary>
        /// <value><c>true</c> if [hide all]; otherwise, <c>false</c>.</value>
        public bool HideAll { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [hide accept buttons].
        /// </summary>
        /// <value><c>true</c> if [hide accept buttons]; otherwise, <c>false</c>.</value>
        public bool HideAcceptButtons { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [hide second stage].
        /// </summary>
        /// <value><c>true</c> if [hide second stage]; otherwise, <c>false</c>.</value>
        public bool HideSecondStage { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show success fields].
        /// </summary>
        /// <value><c>true</c> if [show success fields]; otherwise, <c>false</c>.</value>
        public bool ShowSuccessFields { get; set; } = false;
        /// <summary>
        /// Gets or sets the deposit.
        /// </summary>
        /// <value>The deposit.</value>
        public string Deposit { get; set; }
        /// <summary>
        /// Gets or sets the income.
        /// </summary>
        /// <value>The income.</value>
        public string Income { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [paid in full].
        /// </summary>
        /// <value><c>true</c> if [paid in full]; otherwise, <c>false</c>.</value>
        public bool PaidInFull { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [other salesman accepted].
        /// </summary>
        /// <value><c>true</c> if [other salesman accepted]; otherwise, <c>false</c>.</value>
        public bool OtherSalesmanAccepted { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether [declined client].
        /// </summary>
        /// <value><c>true</c> if [declined client]; otherwise, <c>false</c>.</value>
        public bool DeclinedClient { get; set; } = false;
        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        public string StatusMessage { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether [job accepted].
        /// </summary>
        /// <value><c>true</c> if [job accepted]; otherwise, <c>false</c>.</value>
        public bool JobAccepted { get; set; } = false;
        /// <summary>
        /// Gets or sets the has errors.
        /// </summary>
        /// <value>The has errors.</value>
        public static List<string> HasErrors { get; set; }
        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        public Job Job { get; set; }
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>The client.</value>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the payment options.
        /// </summary>
        /// <value>The payment options.</value>
        public ObservableCollection<string> PaymentOptions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesSingleViewModel"/> class.
        /// </summary>
        public SalesSingleViewModel()
        {
            bool hasClient = Preferences.ContainsKey("Client");
            bool hasJob = Preferences.ContainsKey("Job");

            if (hasClient)
            {
                var getClient = Preferences.Get("Client", string.Empty);
                Client = JsonConvert.DeserializeObject<Client>(getClient, JsonSettings);
            }

            if (hasJob)
            {
                var jobVal = Preferences.Get("Job", string.Empty);
                var job = JsonConvert.DeserializeObject<Job>(jobVal, JsonSettings);
                Job = App.APIConnect.GetJobWithId(job.ClientId, job.Id);

                if (Job != null)
                {
                    ClientValidation = new ClientValidation();
                    HasErrors = new List<string>();

                    ModalPopupCommand = new Command(ModalPopup);
                    ModalCancelCommand = new Command(ModalCancel);
                    JobAcceptCommand = new Command(JobAccept);
                    JobDeclineCommand = new Command(JobDecline);
                    JobCompleteCommand = new Command(JobComplete);
                    JobFailureCommand = new Command(JobFailure);

                    if (Job.SalesData.Accepted == 0)
                    {
                        StatusMessage = "Accept/Reject";
                        HideAcceptButtons = false;
                        HideSecondStage = true;
                    }
                    else
                    {
                        StatusMessage = "Completion";
                        HideAcceptButtons = true;
                        HideSecondStage = false;
                    }

                    var declinedUsers = Job.DeclinedUsers;
                    if (declinedUsers.Where(x => x.Id == App.APIUser.Id).Count() > 0)
                    {
                        HideAll = true;
                        StatusMessage = "Appointment Declined";
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }

                    if (Job.SalesData.Accepted == 1 && Job.SalesData.AcceptedUserId != App.APIUser.Id)
                    {
                        HideAll = true;
                        StatusMessage = "Another Salesman accepted this client";
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }

                    if (Job.SalesData.Attended == 1 && Job.SalesData.Success == 1)
                    {
                        if (Job.SalesData.Accepted == 1 && Job.SalesData.AcceptedUserId == App.APIUser.Id)
                        {
                            ShowSuccessFields = true;
                            StatusMessage = "Sale Successful";
                        }
                        else
                        {
                            StatusMessage = "Another Salesman accepted this Appointment";
                        }

                        HideAll = true;
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }

                    if (Job.SalesData.Attended == 1 && Job.SalesData.Success == 0)
                    {
                        HideAll = true;
                        StatusMessage = "Sale Unsuccessful";
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }

                    PaymentOptions = new ObservableCollection<string>
                    { 
                        "Cash",
                        "Card",
                        "Cheque",
                        "Bank Transfer"
                    };

                }
            }
        }
        /// <summary>
        /// Modals the popup.
        /// </summary>
        private async void ModalPopup()
        {
            if (isExecuting)
                return;
            try
            {
                isExecuting = true;

                if (JobAccepted || Job.SalesData.Accepted == 1)
                {
                    JobFailureSectionVisible = true;
                    JobDeclineSectionVisible = false;
                }
                else
                {
                    JobDeclineSectionVisible = true;
                    JobFailureSectionVisible = false;
                }

                HideAll = true;

                NotifyPropertyChanged("JobDeclineSectionVisible");
                NotifyPropertyChanged("JobFailureSectionVisible");
                NotifyPropertyChanged("HideAll");

                await Application.Current.MainPage.DisplayAlert("Information", "Enter the reason for rejection", "Ok");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                isExecuting = false;
            }
        }
        /// <summary>
        /// Jobs the accept.
        /// </summary>
        private async void JobAccept()
        {

            if (isExecuting)
                return;
            try
            {
                isExecuting = true;

                Client client = new Client
                {
                    Id = Job.ClientId,
                    JobPostData = new JobPostData {
                        Id = Job.Id,
                        Status = "A Salesman accepted and will be attending" 
                    },
                    SalesData = new SalesData { 
                        AcceptedUserId = App.APIUser.Id,
                        Accepted = 1
                    }
                };

                client.AddNotification.Add(
                   new Notifications
                   {
                       Title = "Salesman Accepted",
                       Reason = App.APIUser.FirstName + " " + App.APIUser.LastName + " [" + App.APIUser.RoleName + "] accepted the Job [" + Job.Name + "]",
                       Type = "Sales"
                   });


               var response = App.APIConnect.UpdateClient(client);

                await Application.Current.MainPage.DisplayAlert("Success", response.Content, "Ok");

                HideAcceptButtons = true;
                HideSecondStage = false;
                JobAccepted = true;
                StatusMessage = "Completion";
                NotifyPropertyChanged("JobAccepted");
                NotifyPropertyChanged("HideAcceptButtons");
                NotifyPropertyChanged("HideSecondStage");
                NotifyPropertyChanged("StatusMessage");

            }
            catch (Exception ex)
            {
            }
            finally
            {
                isExecuting = false;
            }

        }
        /// <summary>
        /// Jobs the decline.
        /// </summary>
        private async void JobDecline()
        {
            if (isExecuting)
                return;
            try
            {
                isExecuting = true;

                Client client = new Client
                {
                    Id = Job.ClientId,
                    JobPostData = new JobPostData { 
                        Id = Job.Id,
                        DeclineJobReason = Job.SalesData.Reason
                    }
                };

                client.JobPostData.AddDeclinedUsers.Add(App.APIUser.Id);

                var response = App.APIConnect.UpdateClient(client);
                await Application.Current.MainPage.DisplayAlert("Success", response.Content, "Ok");

                HideAll = true;
                StatusMessage = "Appointment Declined";
                HideAcceptButtons = true;
                HideSecondStage = true;
                JobDeclineSectionVisible = false;

                NotifyPropertyChanged("HideAll");
                NotifyPropertyChanged("StatusMessage");
                NotifyPropertyChanged("HideAcceptButtons");
                NotifyPropertyChanged("HideSecondStage");
                NotifyPropertyChanged("JobDeclineSectionVisible");

            }
            catch (Exception ex)
            {
            }
            finally
            {
                isExecuting = false;
            }
        }
        /// <summary>
        /// Jobs the failure.
        /// </summary>
        private async void JobFailure()
        {
            if (isExecuting)
                return;
            try
            {
                isExecuting = true;

                Client client = new Client
                {
                    Id = Job.ClientId,
                    JobPostData = new JobPostData { Id = Job.Id, Status = "Sale was Unsuccessful", DeclineJobReason = Job.SalesData.Reason },
                    SalesData = new SalesData { Attended = 1, Success = 0, Reason = Job.SalesData.Reason },
                };


                client.AddNotification.Add(
                   new Notifications
                   {
                       Title = "Sale Unsuccessful",
                       Reason = App.APIUser.FirstName + " " + App.APIUser.LastName + " [" + App.APIUser.RoleName + "] failed to sell [" + Job.Name + "]",
                       Type = "Sales"
                   });

                var response = App.APIConnect.UpdateClient(client);
                await Application.Current.MainPage.DisplayAlert("Success", response.Content, "Ok");

                HideAll = true;
                StatusMessage = "Sale Unsuccessful";
                HideAcceptButtons = true;
                HideSecondStage = true;
                JobFailureSectionVisible = false;

                NotifyPropertyChanged("HideAll");
                NotifyPropertyChanged("StatusMessage");
                NotifyPropertyChanged("HideAcceptButtons");
                NotifyPropertyChanged("HideSecondStage");
                NotifyPropertyChanged("JobFailureSectionVisible");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                isExecuting = false;
            }
        }
        /// <summary>
        /// Jobs the complete.
        /// </summary>
        private async void JobComplete()
        {

            HasErrors.Clear();

            if (string.IsNullOrEmpty(Income))
            {
                HasErrors.Add("Total Cannot be empty");
            }

            if (string.IsNullOrEmpty(Deposit))
            {
                HasErrors.Add("Deposit Cannot be empty");
            }

            if (HasErrors.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (string str in HasErrors)
                {
                    stringBuilder.Append(str.ToString()).AppendLine();
                }

                await Application.Current.MainPage.DisplayAlert("Issues Detected", stringBuilder.ToString(), "Ok");
            }
            else
            {

                if (isExecuting)
                    return;
                try
                {
                    isExecuting = true;

                    Client client = new Client
                    {
                        Id = Job.ClientId,
                        JobPostData = new JobPostData { Id = Job.Id, Status = "Sale Complete", CompleteStageAvailable = 1 },
                        SalesData = new SalesData
                        {
                            CompletedById = App.APIUser.Id,
                            CompletedByName = App.APIUser.FirstName + " " + App.APIUser.LastName,
                            Success = 1,
                            Attended = 1,
                            PrefCompletiontDate = Job.SalesData.PrefCompletiontDate,
                            SalesNotes = Job.SalesData.SalesNotes,
                            PaymentType = Job.SalesData.PaymentType,
                        }
                    };

                    var salesData = client.SalesData;

                    if (PaidInFull)
                    {
                        salesData.TotalToPay = float.Parse(Income);
                        salesData.DepositTotal = float.Parse(Deposit);
                        salesData.PaidInFullBool = 1;
                        salesData.DepositPaidBool = 0;

                    } else
                    {
                        salesData.TotalToPay = float.Parse(Income);
                        salesData.DepositTotal = float.Parse(Deposit);
                        salesData.PaidInFullBool = 0;
                        salesData.DepositPaidBool = 1;
                    }

                    client.AddNotification.Add(
                       new Notifications
                       {
                           Title = "Sale Successful",
                           Reason = App.APIUser.FirstName + " " + App.APIUser.LastName + " [" + App.APIUser.RoleName + "] successfully sold [" + Job.Name + "]",
                           Type = "Sales"
                       });

                    if (TakenImages.Count > 0)
                    {
                        foreach (var takenImage in TakenImages)
                        {
                            takenImage.ClientId = client.Id;
                            takenImage.JobId = Job.Id;
                            takenImage.FileName = Path.GetFileName(takenImage.Path);
                            takenImage.Type = "Sales";
                        }
                        App.APIConnect.UploadImages(client.Id, TakenImages);
                    }

                    var response = App.APIConnect.UpdateClient(client);
                    await Application.Current.MainPage.DisplayAlert("Success", response.Content, "Ok");

                    ShowSuccessFields = true;
                    StatusMessage = "Sale Successful";
                    HideAll = true;
                    HideAcceptButtons = true;
                    HideSecondStage = true;

                    NotifyPropertyChanged("ShowSuccessFields");
                    NotifyPropertyChanged("StatusMessage");
                    NotifyPropertyChanged("HideAll");
                    NotifyPropertyChanged("HideAcceptButtons");
                    NotifyPropertyChanged("HideSecondStage");

                }
                catch (Exception ex)
                {
                }
                finally
                {
                    isExecuting = false;
                }


            }

        }
        /// <summary>
        /// Modals the cancel.
        /// </summary>
        private async void ModalCancel()
        {
            if (isExecuting)
                return;
            try
            {
                isExecuting = true;
                JobDeclineSectionVisible = false;
                JobFailureSectionVisible = false;
                HideAll = false;

                NotifyPropertyChanged("JobDeclineSectionVisible");
                NotifyPropertyChanged("JobFailureSectionVisible");
                NotifyPropertyChanged("HideAll");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                isExecuting = false;
            }
        }
    }
}
