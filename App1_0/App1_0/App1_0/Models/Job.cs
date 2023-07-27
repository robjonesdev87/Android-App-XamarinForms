// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-03-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-29-2023
// ***********************************************************************
// <copyright file="Job.cs" company="App1_0">
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
    /// Class Job.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the job created by identifier.
        /// </summary>
        /// <value>The job created by identifier.</value>
        public string JobCreatedById { get; set; }
        /// <summary>
        /// Gets or sets the name of the job created by.
        /// </summary>
        /// <value>The name of the job created by.</value>
        public string JobCreatedByName { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the type of the job.
        /// </summary>
        /// <value>The type of the job.</value>
        public string JobType { get; set; }
        /// <summary>
        /// Gets or sets the complete stage available.
        /// </summary>
        /// <value>The complete stage available.</value>
        public int CompleteStageAvailable { get; set; }
        /// <summary>
        /// Gets or sets the job users.
        /// </summary>
        /// <value>The job users.</value>
        public virtual List<JobUsers> JobUsers { get; set; } = new List<JobUsers>();
        /// <summary>
        /// Gets or sets the declined users.
        /// </summary>
        /// <value>The declined users.</value>
        public virtual List<JobUsers> DeclinedUsers { get; set; } = new List<JobUsers>();
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// Gets or sets the last updated.
        /// </summary>
        /// <value>The last updated.</value>
        public DateTime? LastUpdated { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }
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
        /// <summary>
        /// Gets or sets the trade data.
        /// </summary>
        /// <value>The trade data.</value>
        public TradeData TradeData { get; set; }
    }
}
