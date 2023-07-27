// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 07-18-2023
// ***********************************************************************
// <copyright file="APIReturn.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace App1_0.Models
{
    /// <summary>
    /// Class APIReturn.
    /// </summary>
    public class APIReturn
    {
        /// <summary>
        /// Class Login.
        /// </summary>
        public class Login
        {
            /// <summary>
            /// Gets or sets the token.
            /// </summary>
            /// <value>The token.</value>
            public string Token { get; set; }
        }

        /// <summary>
        /// Class GetLoggedInUser.
        /// </summary>
        public class GetLoggedInUser
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public string Id { get; set; }
            /// <summary>
            /// Gets or sets the first name.
            /// </summary>
            /// <value>The first name.</value>
            public string FirstName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the last name.
            /// </summary>
            /// <value>The last name.</value>
            public string LastName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the name of the role.
            /// </summary>
            /// <value>The name of the role.</value>
            public string RoleName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the location.
            /// </summary>
            /// <value>The location.</value>
            public string Location { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the mobile number.
            /// </summary>
            /// <value>The mobile number.</value>
            public string MobileNumber { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the phone number.
            /// </summary>
            /// <value>The phone number.</value>
            public string PhoneNumber { get; set; }
            /// <summary>
            /// Gets or sets the sit fee amount.
            /// </summary>
            /// <value>The sit fee amount.</value>
            public int SitFeeAmount { get; set; }
            /// <summary>
            /// Gets or sets the commission fee percent.
            /// </summary>
            /// <value>The commission fee percent.</value>
            public int CommissionFeePercent { get; set; }
            /// <summary>
            /// Gets or sets the firebase token.
            /// </summary>
            /// <value>The firebase token.</value>
            public string FirebaseToken { get; set; }

        }

        /// <summary>
        /// Class GetUserMessages.
        /// </summary>
        public class GetUserMessages
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public string Id { get; set; }
            /// <summary>
            /// Gets or sets the first name.
            /// </summary>
            /// <value>The first name.</value>
            public string FirstName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the last name.
            /// </summary>
            /// <value>The last name.</value>
            public string LastName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the name of the role.
            /// </summary>
            /// <value>The name of the role.</value>
            public string RoleName { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the location.
            /// </summary>
            /// <value>The location.</value>
            public string Location { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the mobile number.
            /// </summary>
            /// <value>The mobile number.</value>
            public string MobileNumber { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the phone number.
            /// </summary>
            /// <value>The phone number.</value>
            public string PhoneNumber { get; set; }
            /// <summary>
            /// Gets or sets the sit fee amount.
            /// </summary>
            /// <value>The sit fee amount.</value>
            public int SitFeeAmount { get; set; }
            /// <summary>
            /// Gets or sets the commission fee percent.
            /// </summary>
            /// <value>The commission fee percent.</value>
            public int CommissionFeePercent { get; set; }
            /// <summary>
            /// Gets or sets the firebase token.
            /// </summary>
            /// <value>The firebase token.</value>
            public string FirebaseToken { get; set; }
            /// <summary>
            /// Gets or sets the messages.
            /// </summary>
            /// <value>The messages.</value>
            public ObservableCollection<UserMessages> Messages { get; set; } = new ObservableCollection<UserMessages>();
        }

        /// <summary>
        /// Class GetUserJobs.
        /// </summary>
        public class GetUserJobs
        {
            /// <summary>
            /// Gets or sets the job.
            /// </summary>
            /// <value>The job.</value>
            public Job Job { get; set; }
        }

        /// <summary>
        /// Class GetClientWithId.
        /// </summary>
        public class GetClientWithId
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public string Id { get; set; }
            /// <summary>
            /// Gets or sets the global status.
            /// </summary>
            /// <value>The global status.</value>
            public string GlobalStatus { get; set; } = String.Empty;
            /// <summary>
            /// Gets or sets the declined users.
            /// </summary>
            /// <value>The declined users.</value>
            public List<JobUsers> DeclinedUsers { get; set; } = new List<JobUsers>();
            /// <summary>
            /// Gets or sets the canvas data.
            /// </summary>
            /// <value>The canvas data.</value>
            public CanvasData CanvasData { get; set; }
            /// <summary>
            /// Gets or sets the information.
            /// </summary>
            /// <value>The information.</value>
            public Information Information { get; set; }
            /// <summary>
            /// Gets or sets the sales data.
            /// </summary>
            /// <value>The sales data.</value>
            public SalesData SalesData { get; set; }
            /// <summary>
            /// Gets or sets the survey data.
            /// </summary>
            /// <value>The survey data.</value>
            public SurveyData SurveyData { get; set; }

        }

    }
}
