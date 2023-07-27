// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="CanvasData.cs" company="App1_0">
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
    /// Class CanvasData.
    /// </summary>
    public class CanvasData
    {
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
        /// Gets or sets the sit fee.
        /// </summary>
        /// <value>The sit fee.</value>
        public int? SitFee { get; set; }
        /// <summary>
        /// Gets or sets the commission fee percent.
        /// </summary>
        /// <value>The commission fee percent.</value>
        public int? CommissionFeePercent { get; set; }
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
        /// Gets or sets a value indicating whether [action needed].
        /// </summary>
        /// <value><c>null</c> if [action needed] contains no value, <c>true</c> if [action needed]; otherwise, <c>false</c>.</value>
        public bool? ActionNeeded { get; set; } = false; //Not mapped
    }
}
