// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 01-24-2023
// ***********************************************************************
// <copyright file="Information.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App1_0.Models
{
    /// <summary>
    /// Class Information.
    /// Implements the <see cref="ObservableObject" />
    /// </summary>
    /// <seealso cref="ObservableObject" />
    public class Information : ObservableObject
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the landline number.
        /// </summary>
        /// <value>The landline number.</value>
        public string LandlineNumber { get; set; }
        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number.</value>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the service required.
        /// </summary>
        /// <value>The service required.</value>
        public string ServiceRequired { get; set; }
        /// <summary>
        /// Gets or sets the pbo reason.
        /// </summary>
        /// <value>The pbo reason.</value>
        public string PboReason { get; set; }
        /// <summary>
        /// Gets or sets the tweak time.
        /// </summary>
        /// <value>The tweak time.</value>
        public string TweakTime { get; set; }
        /// <summary>
        /// Gets or sets the employment status.
        /// </summary>
        /// <value>The employment status.</value>
        public string EmploymentStatus { get; set; }
        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        /// <value>The house number.</value>
        public string HouseNumber { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        public string Postcode { get; set; }
        /// <summary>
        /// Gets or sets the type of house.
        /// </summary>
        /// <value>The type of house.</value>
        public string TypeOfHouse { get; set; }
        /// <summary>
        /// Gets or sets the number of windows.
        /// </summary>
        /// <value>The number of windows.</value>
        public string NumberOfWindows { get; set; }
        /// <summary>
        /// Gets or sets the number of doors.
        /// </summary>
        /// <value>The number of doors.</value>
        public string NumberOfDoors { get; set; }
        /// <summary>
        /// Gets or sets the number of french doors.
        /// </summary>
        /// <value>The number of french doors.</value>
        public string NumberOfFrenchDoors { get; set; }
        /// <summary>
        /// Gets or sets the type of the window.
        /// </summary>
        /// <value>The type of the window.</value>
        public string WindowType { get; set; }
        /// <summary>
        /// Gets or sets the est age.
        /// </summary>
        /// <value>The est age.</value>
        public string EstAge { get; set; }
        /// <summary>
        /// Gets or sets the est occupation.
        /// </summary>
        /// <value>The est occupation.</value>
        public string EstOccupation { get; set; }
        /// <summary>
        /// Gets or sets the est services required.
        /// </summary>
        /// <value>The est services required.</value>
        public string EstServicesRequired { get; set; }
        /// <summary>
        /// Gets or sets the confirm with.
        /// </summary>
        /// <value>The confirm with.</value>
        public string ConfirmWith { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// Gets or sets the titles collection.
        /// </summary>
        /// <value>The titles collection.</value>
        public ObservableCollection<string> TitlesCollection { get; set; }
        /// <summary>
        /// Gets or sets the employment collection.
        /// </summary>
        /// <value>The employment collection.</value>
        public ObservableCollection<string> EmploymentCollection { get; set; }
        /// <summary>
        /// Gets or sets the type of house collection.
        /// </summary>
        /// <value>The type of house collection.</value>
        public ObservableCollection<string> TypeOfHouseCollection { get; set; }
        /// <summary>
        /// Gets or sets the window type collection.
        /// </summary>
        /// <value>The window type collection.</value>
        public ObservableCollection<string> WindowTypeCollection { get; set; }
        /// <summary>
        /// Gets or sets the service required collection.
        /// </summary>
        /// <value>The service required collection.</value>
        public ObservableCollection<string> ServiceRequiredCollection { get; set; }


    }

}
