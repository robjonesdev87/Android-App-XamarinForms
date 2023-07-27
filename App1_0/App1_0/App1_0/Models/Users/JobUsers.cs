// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-03-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 06-27-2023
// ***********************************************************************
// <copyright file="JobUsers.cs" company="App1_0">
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
    /// Class JobUsers.
    /// </summary>
    public class JobUsers
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string? Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string? FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string? LastName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        public string? RoleName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string? Reason { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string? Location { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the firebase token.
        /// </summary>
        /// <value>The firebase token.</value>
        public string? FirebaseToken { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the sit fee amount.
        /// </summary>
        /// <value>The sit fee amount.</value>
        public int? SitFeeAmount { get; set; } = -1;
        /// <summary>
        /// Gets or sets the commission fee percent.
        /// </summary>
        /// <value>The commission fee percent.</value>
        public int? CommissionFeePercent { get; set; } = -1;
        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>The jobs.</value>
        public virtual List<Job>? Jobs { get; set; } = new List<Job>();
        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        public virtual Job? Job { get; set; }
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// Gets or sets the last login.
        /// </summary>
        /// <value>The last login.</value>
        public DateTime? LastLogin { get; set; }


    }
}
