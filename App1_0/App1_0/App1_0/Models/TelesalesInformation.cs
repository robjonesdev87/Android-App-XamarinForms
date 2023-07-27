// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 03-13-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 03-29-2023
// ***********************************************************************
// <copyright file="TelesalesInformation.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace WindowShine_API.Models
{
    /// <summary>
    /// Class TelesalesInformation.
    /// </summary>
    public class TelesalesInformation
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string? Title { get; set; } = string.Empty;
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
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number.</value>
        public string? MobileNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        /// <value>The house number.</value>
        public string? HouseNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string? Address { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        public string? Postcode { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string? Status { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public string? Price { get; set; } = string.Empty;
    }
}
