// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 02-17-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 04-24-2023
// ***********************************************************************
// <copyright file="TradeData.cs" company="App1_0">
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
    /// Class TradeData.
    /// </summary>
    public class TradeData
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
        /// Gets or sets the lead tradesman identifier.
        /// </summary>
        /// <value>The lead tradesman identifier.</value>
        public string? LeadTradesmanId { get; set; }
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
        /// Gets or sets the trade notes.
        /// </summary>
        /// <value>The trade notes.</value>
        public string? TradeNotes { get; set; }
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
    }
}
