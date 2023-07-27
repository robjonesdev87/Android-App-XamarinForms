// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 11-03-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-28-2023
// ***********************************************************************
// <copyright file="SalesData.cs" company="App1_0">
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
    /// Class SalesData.
    /// </summary>
    public class SalesData
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
        /// Gets or sets the preference completiont date.
        /// </summary>
        /// <value>The preference completiont date.</value>
        public DateTime? PrefCompletiontDate { get; set; }
        /// <summary>
        /// Gets or sets the minimum quote.
        /// </summary>
        /// <value>The minimum quote.</value>
        public int? MinimumQuote { get; set; }
        /// <summary>
        /// Gets or sets the payment date.
        /// </summary>
        /// <value>The payment date.</value>
        public DateTime? PaymentDate { get; set; }
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
        /// Gets or sets the sales notes.
        /// </summary>
        /// <value>The sales notes.</value>
        public string? SalesNotes { get; set; }
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
        /// Gets or sets the total to pay.
        /// </summary>
        /// <value>The total to pay.</value>
        public float? TotalToPay { get; set; }
        /// <summary>
        /// Gets or sets the deposit total.
        /// </summary>
        /// <value>The deposit total.</value>
        public float? DepositTotal { get; set; }
        /// <summary>
        /// Gets or sets the deposit percentage.
        /// </summary>
        /// <value>The deposit percentage.</value>
        public int? DepositPercentage { get; set; }  //Is this needed? 0 uses currently
        /// <summary>
        /// Gets or sets the deposit paid bool.
        /// </summary>
        /// <value>The deposit paid bool.</value>
        public int? DepositPaidBool { get; set; }
        /// <summary>
        /// Gets or sets the paid in full bool.
        /// </summary>
        /// <value>The paid in full bool.</value>
        public int? PaidInFullBool { get; set; }
        /// <summary>
        /// Gets or sets the type of the payment.
        /// </summary>
        /// <value>The type of the payment.</value>
        public string? PaymentType { get; set; }

    }
}
