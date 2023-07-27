// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-03-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-29-2023
// ***********************************************************************
// <copyright file="JobPostData.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models.PostData
{
    /// <summary>
    /// Class JobPostData.
    /// </summary>
    public class JobPostData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string? Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string? Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string? Description { get; set; }
        /// <summary>
        /// Gets or sets the type of the job.
        /// </summary>
        /// <value>The type of the job.</value>
        public string? JobType { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string? Status { get; set; }
        /// <summary>
        /// Gets or sets the decline job reason.
        /// </summary>
        /// <value>The decline job reason.</value>
        public string? DeclineJobReason { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the complete stage available.
        /// </summary>
        /// <value>The complete stage available.</value>
        public int CompleteStageAvailable { get; set; }
        /// <summary>
        /// Gets or sets the remove declined users.
        /// </summary>
        /// <value>The remove declined users.</value>
        public virtual List<string>? RemoveDeclinedUsers { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the add users.
        /// </summary>
        /// <value>The add users.</value>
        public virtual List<string>? AddUsers { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the remove users.
        /// </summary>
        /// <value>The remove users.</value>
        public virtual List<string>? RemoveUsers { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the add declined users.
        /// </summary>
        /// <value>The add declined users.</value>
        public virtual List<string>? AddDeclinedUsers { get; set; } = new List<string>();

    }
}
