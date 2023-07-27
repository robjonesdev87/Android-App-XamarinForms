// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 12-09-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 07-18-2023
// ***********************************************************************
// <copyright file="UserMessages.cs" company="App1_0">
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
    /// Class UserMessages.
    /// </summary>
    public class UserMessages
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string? Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string? Subject { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string? Text { get; set; }
        /// <summary>
        /// Gets or sets the read.
        /// </summary>
        /// <value>The read.</value>
        public int? Read { get; set; }
        /// <summary>
        /// Gets or sets the sender identifier.
        /// </summary>
        /// <value>The sender identifier.</value>
        public string? SenderId { get; set; }
        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>The name of the sender.</value>
        public string? SenderName { get; set; }
        /// <summary>
        /// Gets or sets the receiver identifier.
        /// </summary>
        /// <value>The receiver identifier.</value>
        public string? ReceiverId { get; set; }
        /// <summary>
        /// Gets or sets the name of the receiver.
        /// </summary>
        /// <value>The name of the receiver.</value>
        public string? ReceiverName { get; set; }
        /// <summary>
        /// Gets or sets the sent date.
        /// </summary>
        /// <value>The sent date.</value>
        public DateTime? SentDate { get; set; }
        /// <summary>
        /// Gets or sets the read date.
        /// </summary>
        /// <value>The read date.</value>
        public DateTime? ReadDate { get; set; }

    }
}
