// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 07-18-2023
// ***********************************************************************
// <copyright file="APIConnect.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using App1_0.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Net.Http;

namespace App1_0.API
{
    /// <summary>
    /// Class APIConnect.
    /// </summary>
    public class APIConnect
    {
        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public RestClientOptions Options { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="APIConnect"/> class.
        /// </summary>
        public APIConnect()
        {
            Options = new RestClientOptions("https://windowshine-server.co.uk:2053")
            //Options = new RestClientOptions("https://10.0.2.2:44309")
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
                //MaxTimeout = 10000,
                //ThrowOnAnyError = true,
            };
        }
        /// <summary>
        /// Adds the client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse AddClient(Client client)
        {

            var user = GetLoggedInUser();

            client.AddNotification.Add(
                    new Notifications { 
                        Title = "New Client",
                        Reason = user.User.FirstName + " " + user.User.LastName + " [" + user.User.RoleName + "] Added a new Client",
                        Type = "Canvas"
                    }
                );

            var json = JsonConvert.SerializeObject(client);

            var restClient = new RestClient(Options);
            restClient.Authenticator = new JwtAuthenticator(Settings.AccessToken);
            var request = new RestRequest("api/Clients/CreateClient");

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddBody(json);
            var response = restClient.Execute(request);

            return response;
        }
        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>dynamic.</returns>
        public dynamic Login(string username, string password)
        {

            var restClient = new RestClient(Options);

            var request = new RestRequest("api/Authentication/Login");
            var loginObj = new { username = username, password = password };

            request.Method = Method.Post;
            request.Timeout = 10000;
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(loginObj));

            var response = restClient.Execute(request);
            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {
                var token = JsonConvert.DeserializeObject<APIReturn.Login>(response.Content, App.JsonSettings);
                Settings.AccessToken = token.Token;
                return new { Status = statusCode, Token = token };
            }
            else
            {
                return new { Status = statusCode };
            }

        }
        /// <summary>
        /// Gets the logged in user.
        /// </summary>
        /// <returns>dynamic.</returns>
        public dynamic GetLoggedInUser()
        {
            if (Settings.AccessToken != null && Settings.AccessToken != "")
            {
                try {
                    var restClient = new RestClient(Options)
                    {
                        Authenticator = new JwtAuthenticator(Settings.AccessToken),
                        
                    };

                    var request = new RestRequest("api/users/GetLoggedInUser")
                    {
                        Method = Method.Get,
                        Timeout = 10000
                    };

                    request.AddHeader("Accept", "application/json");

                    var response = restClient.Execute(request);

                    int statusCode = (int)response.StatusCode;

                    if (statusCode == 200)
                    {
                        var user = JsonConvert.DeserializeObject<APIReturn.GetLoggedInUser>(response.Content, App.JsonSettings);
                        return new { Status = statusCode, User = user };
                    }
                    else
                    {
                        return new { Status = statusCode };
                    }
                }
                catch (Exception ex)
                {
                    Shell.Current.GoToAsync("//LoginPage");
                    Application.Current.MainPage.DisplayAlert("Warning", "Auto Login Failed " + ex.Message, "Ok");
                }


            } 

            return false;
        }

        /// <summary>
        /// Gets the user messages.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>dynamic.</returns>
        public dynamic GetUserMessages(string id)
        {
            if (Settings.AccessToken != null && Settings.AccessToken != "")
            {
                try
                {
                    var restClient = new RestClient(Options)
                    {
                        Authenticator = new JwtAuthenticator(Settings.AccessToken),

                    };

                    var request = new RestRequest("api/users/GetUserMessages")
                    {
                        Method = Method.Post,
                        Timeout = 10000
                    };

                    request.AddHeader("Accept", "application/json");
                    request.AddQueryParameter("id", id);

                    var response = restClient.Execute(request);

                    int statusCode = (int)response.StatusCode;

                    if (statusCode == 200)
                    {
                        var user = JsonConvert.DeserializeObject<APIReturn.GetUserMessages>(response.Content, App.JsonSettings);
                        return new { Status = statusCode, User = user };
                    }
                    else
                    {
                        return new { Status = statusCode };
                    }
                }
                catch (Exception ex)
                {

                }


            }

            return false;
        }
        /// <summary>
        /// Gets the user jobs.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>ObservableCollection&lt;Job&gt;.</returns>
        public ObservableCollection<Job> GetUserJobs(string accessToken)
        {

            var restClient = new RestClient(Options)
            {
                Authenticator = new JwtAuthenticator(accessToken)
            };

            var request = new RestRequest("api/users/GetUserJobs");

            request.Method = Method.Get;
            request.AddHeader("Accept", "application/json");

            var response = restClient.Execute(request);

            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Job>>(response.Content, App.JsonSettings);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Gets all telesales clients.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>ObservableCollection&lt;TelesalesClient&gt;.</returns>
        public ObservableCollection<TelesalesClient> GetAllTelesalesClients(string accessToken)
        {

            var restClient = new RestClient(Options)
            {
                Authenticator = new JwtAuthenticator(accessToken)
            };

            var request = new RestRequest("api/clients/GetAllTelesalesClients");

            request.Method = Method.Get;
            request.AddHeader("Accept", "application/json");

            var response = restClient.Execute(request);

            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {

                return JsonConvert.DeserializeObject<ObservableCollection<TelesalesClient>>(response.Content, App.JsonSettings);

            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Gets the clients with job user.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>ObservableCollection&lt;Client&gt;.</returns>
        public ObservableCollection<Client> GetClientsWithJobUser(string accessToken)
        {

            var restClient = new RestClient(Options)
            {
                Authenticator = new JwtAuthenticator(accessToken)
            };

            var request = new RestRequest("api/clients/GetClientsWithJobUser");

            request.Method = Method.Get;
            request.AddHeader("Accept", "application/json");

            var response = restClient.Execute(request);

            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {

                return JsonConvert.DeserializeObject<ObservableCollection<Client>>(response.Content, App.JsonSettings);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Gets the associated clients.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>ObservableCollection&lt;Client&gt;.</returns>
        public ObservableCollection<Client> GetAssociatedClients(string accessToken)
        {

            var restClient = new RestClient(Options)
            {
                Authenticator = new JwtAuthenticator(accessToken)
            };

            var request = new RestRequest("api/clients/GetAssociatedClients");

            request.Method = Method.Get;
            request.AddHeader("Accept", "application/json");

            var response = restClient.Execute(request);

            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {

                return JsonConvert.DeserializeObject<ObservableCollection<Client>>(response.Content, App.JsonSettings);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Gets the job with identifier.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="jobId">The job identifier.</param>
        /// <returns>Job.</returns>
        public Job GetJobWithId(string clientId, string jobId)
        {

            var restClient = new RestClient(Options)
            {
                Authenticator = new JwtAuthenticator(Settings.AccessToken)
            };

            var request = new RestRequest("api/clients/GetJobWithId")
            {
                Method = Method.Post
            };

            request.AddHeader("Accept", "application/json");
            request.AddQueryParameter("clientId", clientId);
            request.AddQueryParameter("jobId", jobId);

            var response = restClient.Execute(request);

            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {
                return JsonConvert.DeserializeObject<Job>(response.Content, App.JsonSettings);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Gets the client with identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Client.</returns>
        public Client GetClientWithId(string id)
        {
            var restClient = new RestClient(Options)
            {
                Authenticator = new JwtAuthenticator(Settings.AccessToken)
            };

            var request = new RestRequest("api/clients/GetClientWithId")
            {
                Method = Method.Post
            };

            request.AddHeader("Accept", "application/json");
            request.AddQueryParameter("id", id);

            var response = restClient.Execute(request);

            int statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {
                return JsonConvert.DeserializeObject<Client>(response.Content, App.JsonSettings);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Updates the client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse UpdateClient(Client client)
        {

            var json = JsonConvert.SerializeObject(client);

            var restClient = new RestClient(Options);
            restClient.Authenticator = new JwtAuthenticator(Settings.AccessToken);
            var request = new RestRequest("api/Clients/UpdateClient")
            {
                Method = Method.Put
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(json);
            var response = restClient.Execute(request);

            return response;

        }
        /// <summary>
        /// Updates the tele sales client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse UpdateTeleSalesClient(TelesalesClient client)
        {

            var json = JsonConvert.SerializeObject(client);

            var restClient = new RestClient(Options);
            restClient.Authenticator = new JwtAuthenticator(Settings.AccessToken);
            var request = new RestRequest("api/Clients/UpdateTeleSalesClient")
            {
                Method = Method.Put
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(json);
            var response = restClient.Execute(request);

            return response;

        }
        /// <summary>
        /// Saves the geo location.
        /// </summary>
        /// <param name="location">The location.</param>
        public void SaveGeoLocation(string location)
        {
            var i = 0;
            if (Settings.AccessToken != null && Settings.AccessToken != "")
            {
                App.APIUser.Location = location;
                var json = JsonConvert.SerializeObject(App.APIUser);

                var restClient = new RestClient(Options)
                {
                    Authenticator = new JwtAuthenticator(Settings.AccessToken)
                };

                var request = new RestRequest("api/users/UpdateUserWithId")
                {
                    Method = Method.Put
                };
                request.AddBody(json);
                request.AddQueryParameter("id", App.APIUser.Id);
                request.AddHeader("Accept", "application/json");

                var response = restClient.Execute(request);
            }
        }
        /// <summary>
        /// Updates the firebase token.
        /// </summary>
        /// <param name="token">The token.</param>
        public void UpdateFirebaseToken(string token)
        {
            var i = 0;
            if (Settings.AccessToken != null && Settings.AccessToken != "")
            {
                App.APIUser.FirebaseToken = token;
                var json = JsonConvert.SerializeObject(App.APIUser);

                var restClient = new RestClient(Options)
                {
                    Authenticator = new JwtAuthenticator(Settings.AccessToken)
                };

                var request = new RestRequest("api/users/UpdateUserWithId")
                {
                    Method = Method.Put
                };
                request.AddBody(json);
                request.AddQueryParameter("id", App.APIUser.Id);
                request.AddHeader("Accept", "application/json");

                var response = restClient.Execute(request);
            }
        }
        /// <summary>
        /// Uploads the images.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="images">The images.</param>
        /// <returns>RestResponse.</returns>
        public RestResponse UploadImages(string clientId, ObservableCollection<ImageForUpload> images)
        {
            var restClient = new RestClient(Options);
            restClient.Authenticator = new JwtAuthenticator(Settings.AccessToken);

            //var extraData = JsonConvert.SerializeObject(multipartFormDataContent);

            var request = new RestRequest("api/Files/UploadImages")
            {
                Method = Method.Post
            };

            request.AddHeader("Content-Type", "multipart/form-data");

            foreach (ImageForUpload image in images)
            {
                request.AddFile(image.Name, image.Path);
            }

            var imageData = JsonConvert.SerializeObject(images);
            request.AddParameter("ClientId", clientId);
            request.AddParameter("ImageData", imageData);

            var response = restClient.Execute(request);

            return response;

        }
    }
}
