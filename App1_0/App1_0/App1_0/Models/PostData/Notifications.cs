// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-20-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 01-20-2023
// ***********************************************************************
// <copyright file="Notifications.cs" company="App1_0">
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
    /// Class Notifications.
    /// </summary>
    public class Notifications
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string? Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string? Reason { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string? Type { get; set; } = string.Empty;

    }
}
