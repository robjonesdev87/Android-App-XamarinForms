// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 03-13-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-21-2023
// ***********************************************************************
// <copyright file="TelesalesClient.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using WindowShine_API.Models;

namespace App1_0.Models
{
    /// <summary>
    /// Class TelesalesClient.
    /// </summary>
    public class TelesalesClient
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string? Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the telesales information.
        /// </summary>
        /// <value>The telesales information.</value>
        public virtual TelesalesInformation? TelesalesInformation { get; set; }
        /// <summary>
        /// Gets or sets the service required.
        /// </summary>
        /// <value>The service required.</value>
        public string? ServiceRequired { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the expected start.
        /// </summary>
        /// <value>The expected start.</value>
        public string? ExpectedStart { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the name valid.
        /// </summary>
        /// <value>The name valid.</value>
        public int? NameValid { get; set; } = 1;
        /// <summary>
        /// Gets or sets the phone number valid.
        /// </summary>
        /// <value>The phone number valid.</value>
        public int? PhoneNumberValid { get; set; } = 1;
        /// <summary>
        /// Gets or sets the address valid.
        /// </summary>
        /// <value>The address valid.</value>
        public int? AddressValid { get; set; } = 1;
        /// <summary>
        /// Gets or sets the interested.
        /// </summary>
        /// <value>The interested.</value>
        public int? Interested { get; set; } = 0;
        /// <summary>
        /// Gets or sets the not interested.
        /// </summary>
        /// <value>The not interested.</value>
        public int? NotInterested { get; set; } = 0;
        /// <summary>
        /// Gets or sets the no answer.
        /// </summary>
        /// <value>The no answer.</value>
        public int? NoAnswer { get; set; } = 0;
        /// <summary>
        /// Gets or sets the remove from list.
        /// </summary>
        /// <value>The remove from list.</value>
        public int? RemoveFromList { get; set; } = 0;
        /// <summary>
        /// Gets or sets the last length of the call.
        /// </summary>
        /// <value>The last length of the call.</value>
        public int? LastCallLength { get; set; } = 0;
        /// <summary>
        /// Gets or sets the contacted times.
        /// </summary>
        /// <value>The contacted times.</value>
        public int? ContactedTimes { get; set; } = 0;
        /// <summary>
        /// Gets or sets the interested level.
        /// </summary>
        /// <value>The interested level.</value>
        public string? InterestedLevel { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string? Status { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the budget.
        /// </summary>
        /// <value>The budget.</value>
        public int? Budget { get; set; } = 0;
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string? Notes { get; set; } = string.Empty;
    }
}
