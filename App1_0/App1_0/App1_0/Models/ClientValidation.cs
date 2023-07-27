// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 10-30-2022
//
// Last Modified By : Robert Jones
// Last Modified On : 12-13-2022
// ***********************************************************************
// <copyright file="ClientValidation.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App1_0.Models 
{
    /// <summary>
    /// Class ClientValidation.
    /// Implements the <see cref="ObservableObject" />
    /// </summary>
    /// <seealso cref="ObservableObject" />
    public class ClientValidation : ObservableObject
    {
        /// <summary>
        /// The first name valid
        /// </summary>
        private bool firstNameValid;
        /// <summary>
        /// The last name valid
        /// </summary>
        private bool lastNameValid;
        /// <summary>
        /// The address valid
        /// </summary>
        private bool addressValid;
        /// <summary>
        /// The postcode valid
        /// </summary>
        private bool postcodeValid;
        /// <summary>
        /// The total to be paid valid
        /// </summary>
        private bool totalToBePaidValid;
        /// <summary>
        /// The deposit total valid
        /// </summary>
        private bool depositTotalValid;
        /// <summary>
        /// The inventory required valid
        /// </summary>
        private bool inventoryRequiredValid;
        /// <summary>
        /// The measurements valid
        /// </summary>
        private bool measurementsValid;

        /// <summary>
        /// Gets or sets a value indicating whether [first name valid].
        /// </summary>
        /// <value><c>true</c> if [first name valid]; otherwise, <c>false</c>.</value>
        public bool FirstNameValid
        {
            get => firstNameValid;
            set => SetProperty(ref firstNameValid, value);
        }
        /// <summary>
        /// Gets or sets a value indicating whether [last name valid].
        /// </summary>
        /// <value><c>true</c> if [last name valid]; otherwise, <c>false</c>.</value>
        public bool LastNameValid
        {
            get => lastNameValid;
            set => SetProperty(ref lastNameValid, value);
        }
        /// <summary>
        /// Gets or sets a value indicating whether [address valid].
        /// </summary>
        /// <value><c>true</c> if [address valid]; otherwise, <c>false</c>.</value>
        public bool AddressValid {
            get => addressValid;
            set => SetProperty(ref addressValid, value);
        }
        /// <summary>
        /// Gets or sets a value indicating whether [postcode valid].
        /// </summary>
        /// <value><c>true</c> if [postcode valid]; otherwise, <c>false</c>.</value>
        public bool PostcodeValid { 
            get => postcodeValid;
            set => SetProperty(ref postcodeValid, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [deposit total valid].
        /// </summary>
        /// <value><c>true</c> if [deposit total valid]; otherwise, <c>false</c>.</value>
        public bool DepositTotalValid
        {
            get => depositTotalValid;
            set => SetProperty(ref depositTotalValid, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [total to be paid valid].
        /// </summary>
        /// <value><c>true</c> if [total to be paid valid]; otherwise, <c>false</c>.</value>
        public bool TotalToBePaidValid
        {
            get => totalToBePaidValid;
            set => SetProperty(ref totalToBePaidValid, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [inventory required valid].
        /// </summary>
        /// <value><c>true</c> if [inventory required valid]; otherwise, <c>false</c>.</value>
        public bool InventoryRequiredValid
        {
            get => inventoryRequiredValid;
            set => SetProperty(ref inventoryRequiredValid, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [measurements valid].
        /// </summary>
        /// <value><c>true</c> if [measurements valid]; otherwise, <c>false</c>.</value>
        public bool MeasurementsValid
        {
            get => measurementsValid;
            set => SetProperty(ref measurementsValid, value);
        }

    }
}
