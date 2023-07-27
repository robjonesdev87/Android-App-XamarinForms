// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-03-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 11-13-2022
// ***********************************************************************
// <copyright file="UserLogin.cs" company="App1_0">
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
    /// Class UserLogin.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; } = string.Empty;

    }
}
