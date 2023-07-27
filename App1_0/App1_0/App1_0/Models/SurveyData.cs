// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-09-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-24-2023
// ***********************************************************************
// <copyright file="SurveyData.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    /// <summary>
    /// Class SurveyData.
    /// </summary>
    public class SurveyData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string? Id { get; set; }
        /// <summary>
        /// Gets or sets the completed by identifier.
        /// </summary>
        /// <value>The completed by identifier.</value>
        public string? CompletedById { get; set; }
        /// <summary>
        /// Gets or sets the name of the completed by.
        /// </summary>
        /// <value>The name of the completed by.</value>
        public string? CompletedByName { get; set; }
        /// <summary>
        /// Gets or sets the appointment date.
        /// </summary>
        /// <value>The appointment date.</value>
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// Gets or sets the appointment time.
        /// </summary>
        /// <value>The appointment time.</value>
        public TimeSpan? AppointmentTime { get; set; }
        /// <summary>
        /// Gets or sets the accepted.
        /// </summary>
        /// <value>The accepted.</value>
        public int? Accepted { get; set; }
        /// <summary>
        /// Gets or sets the accepted user identifier.
        /// </summary>
        /// <value>The accepted user identifier.</value>
        public string? AcceptedUserId { get; set; }
        /// <summary>
        /// Gets or sets the complete.
        /// </summary>
        /// <value>The complete.</value>
        public int? Complete { get; set; }
        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        /// <value>The success.</value>
        public int? Success { get; set; }
        /// <summary>
        /// Gets or sets the admin notes.
        /// </summary>
        /// <value>The admin notes.</value>
        public string? AdminNotes { get; set; }
        /// <summary>
        /// Gets or sets the survey notes.
        /// </summary>
        /// <value>The survey notes.</value>
        public string? SurveyNotes { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string? Reason { get; set; }
        /// <summary>
        /// Gets or sets the attended.
        /// </summary>
        /// <value>The attended.</value>
        public int? Attended { get; set; }
        /// <summary>
        /// Gets or sets the inventory required.
        /// </summary>
        /// <value>The inventory required.</value>
        public string? InventoryRequired { get; set; }
        /// <summary>
        /// Gets or sets the measurements.
        /// </summary>
        /// <value>The measurements.</value>
        public string? Measurements { get; set; }
        /// <summary>
        /// Gets or sets the estimated cost.
        /// </summary>
        /// <value>The estimated cost.</value>
        public int? EstimatedCost { get; set; }
        /// <summary>
        /// Gets or sets the est staff required.
        /// </summary>
        /// <value>The est staff required.</value>
        public int? EstStaffRequired { get; set; }

    }
}
