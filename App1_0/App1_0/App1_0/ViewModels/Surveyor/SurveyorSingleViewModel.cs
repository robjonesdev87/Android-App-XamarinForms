// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 04-10-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 04-14-2023
// ***********************************************************************
// <copyright file="SurveyorSingleViewModel.cs" company="App1_0">
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

namespace App1_0.ViewModels.Surveyor
{
    /// <summary>
    /// Class SurveyorSingleViewModel.
    /// Implements the <see cref="App1_0.ViewModels.BaseViewModel" />
    /// </summary>
    /// <seealso cref="App1_0.ViewModels.BaseViewModel" />
    public class SurveyorSingleViewModel : BaseViewModel
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
        /// Gets or sets the deposit total.
        /// </summary>
        /// <value>The deposit total.</value>
        public string DepositTotal { get; set; }
        /// <summary>
        /// Gets or sets the total to be paid.
        /// </summary>
        /// <value>The total to be paid.</value>
        public string TotalToBePaid { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [other surveysman accepted].
        /// </summary>
        /// <value><c>true</c> if [other surveysman accepted]; otherwise, <c>false</c>.</value>
        public bool OtherSurveysmanAccepted { get; set; } = false;
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
        /// Gets or sets the inventory required.
        /// </summary>
        /// <value>The inventory required.</value>
        public string InventoryRequired { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the measurements.
        /// </summary>
        /// <value>The measurements.</value>
        public string Measurements { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the estimated cost.
        /// </summary>
        /// <value>The estimated cost.</value>
        public string EstimatedCost { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the est staff required.
        /// </summary>
        /// <value>The est staff required.</value>
        public string EstStaffRequired { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the final quote.
        /// </summary>
        /// <value>The final quote.</value>
        public string FinalQuote { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the survey notes.
        /// </summary>
        /// <value>The survey notes.</value>
        public string SurveyNotes { get; set; } = string.Empty;
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
        /// Initializes a new instance of the <see cref="SurveyorSingleViewModel"/> class.
        /// </summary>
        public SurveyorSingleViewModel()
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

                    if (Job.SurveyData.Accepted == 0)
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

                    if (Job.SurveyData.Accepted == 1 && Job.SurveyData.AcceptedUserId != App.APIUser.Id)
                    {
                        HideAll = true;
                        StatusMessage = "Another Surveyor accepted this client";
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }

                    if (Job.SurveyData.Attended == 1 && Job.SurveyData.Success == 1)
                    {
                        if (Job.SurveyData.Accepted == 1 && Job.SurveyData.AcceptedUserId == App.APIUser.Id)
                        {
                            ShowSuccessFields = true;
                            StatusMessage = "Survey Successful";
                        }
                        else
                        {
                            StatusMessage = "Another Surveyor accepted this Appointment";
                        }

                        HideAll = true;
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }

                    if (Job.SurveyData.Attended == 1 && Job.SurveyData.Success == 0)
                    {
                        HideAll = true;
                        StatusMessage = "Survey Unsuccessful";
                        HideAcceptButtons = true;
                        HideSecondStage = true;
                    }
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

                if (JobAccepted || Job.SurveyData.Accepted == 1)
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
                    JobPostData = new JobPostData { Id = Job.Id, Status = "A Surveyor accepted and will be attending" },
                    SurveyData = new SurveyData { AcceptedUserId = App.APIUser.Id, Accepted = 1 }
                };

                client.AddNotification.Add(
                  new Notifications
                  {
                      Title = "Surveyor Accepted",
                      Reason = App.APIUser.FirstName + " " + App.APIUser.LastName + " [" + App.APIUser.RoleName + "] accepted the Job [" + Job.Name + "]",
                      Type = "Survey"
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
                    JobPostData = new JobPostData { Id = Job.Id, DeclineJobReason = Job.SurveyData.Reason }
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
                    JobPostData = new JobPostData { Id = Job.Id, Status = "Survey was Unsuccessful", DeclineJobReason = Job.SurveyData.Reason },
                    SurveyData = new SurveyData { Attended = 1, Success = 0, Reason = Job.SurveyData.Reason },
                };

                client.AddNotification.Add(
                new Notifications
                {
                    Title = "Survey Unsuccessful",
                    Reason = App.APIUser.FirstName + " " + App.APIUser.LastName + " [" + App.APIUser.RoleName + "] failed to complete [" + Job.Name + "]",
                    Type = "Survey"
                });

                var response = App.APIConnect.UpdateClient(client);
                await Application.Current.MainPage.DisplayAlert("Success", response.Content, "Ok");

                HideAll = true;
                StatusMessage = "Survey Unsuccessful";
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

            HasErrors.Clear(); //DEBUG
         
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
                        JobPostData = new JobPostData { Id = Job.Id, Status = "Survey Complete", CompleteStageAvailable = 1 },
                        SurveyData = new SurveyData
                        {
                            CompletedById = App.APIUser.Id,
                            CompletedByName = App.APIUser.FirstName + " " + App.APIUser.LastName,
                            Accepted = 1,
                            Success = 1,
                            Attended = 1,
                            InventoryRequired = InventoryRequired,
                            Measurements = Measurements,
                            EstStaffRequired = int.Parse(EstStaffRequired),
                            SurveyNotes = SurveyNotes,
                            EstimatedCost = int.Parse(EstimatedCost),
                        }
                    };

                    if (TakenImages.Count > 0)
                    {
                        foreach (var takenImage in TakenImages)
                        {
                            takenImage.ClientId = client.Id;
                            takenImage.JobId = Job.Id;
                            takenImage.FileName = Path.GetFileName(takenImage.Path);
                            takenImage.Type = "Survey";
                        }
                        App.APIConnect.UploadImages(client.Id, TakenImages);
                    }

                client.AddNotification.Add(
                  new Notifications
                  {
                      Title = "Survey Successful",
                      Reason = App.APIUser.FirstName + " " + App.APIUser.LastName + " [" + App.APIUser.RoleName + "] completed a survey on [" + Job.Name + "]",
                      Type = "Survey"
                  });

                    var response = App.APIConnect.UpdateClient(client);
                    await Application.Current.MainPage.DisplayAlert("Success", response.Content, "Ok");

                    ShowSuccessFields = true;
                    StatusMessage = "Survey Successful";
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
