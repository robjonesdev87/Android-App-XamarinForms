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
    public class SurveyorSingleViewModel : BaseViewModel
    {
        public Command ModalPopupCommand { get; set; }
        public Command ModalCancelCommand { get; set; }
        public ClientValidation ClientValidation { get; set; }
        public Command JobAcceptCommand { get; set; }
        public Command JobDeclineCommand { get; set; }
        public Command JobCompleteCommand { get; set; }
        public Command JobFailureCommand { get; set; }
        public int ErrorCount { get; set; } = 0;
        public bool JobDeclineSectionVisible { get; set; } = false;
        public bool JobFailureSectionVisible { get; set; } = false;
        public bool HideAll { get; set; } = false;
        public bool HideAcceptButtons { get; set; } = false;
        public bool HideSecondStage { get; set; } = false;
        public bool ShowSuccessFields { get; set; } = false;
        public string DepositTotal { get; set; }
        public string TotalToBePaid { get; set; }
        public bool OtherSurveysmanAccepted { get; set; } = false;
        public bool DeclinedClient { get; set; } = false;
        public string StatusMessage { get; set; } = string.Empty;
        public bool JobAccepted { get; set; } = false;
        public static List<string> HasErrors { get; set; }
        public string InventoryRequired { get; set; } = string.Empty;
        public string Measurements { get; set; } = string.Empty;
        public string EstimatedCost { get; set; } = string.Empty;
        public string EstStaffRequired { get; set; } = string.Empty;
        public string FinalQuote { get; set; } = string.Empty;
        public string SurveyNotes { get; set; } = string.Empty;
        public Job Job { get; set; }
        public Client Client { get; set; }
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
