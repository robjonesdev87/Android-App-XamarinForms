// ***********************************************************************
// Assembly         : App1_0
// Author           : Robert Jones
// Created          : 01-03-2023
//
// Last Modified By : Robert Jones
// Last Modified On : 02-28-2023
// ***********************************************************************
// <copyright file="Client.cs" company="App1_0">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App1_0.Models.PostData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit.ObjectModel;

namespace App1_0.Models
{
    /// <summary>
    /// Class Client.
    /// Implements the <see cref="INotifyPropertyChanged" />
    /// </summary>
    /// <seealso cref="INotifyPropertyChanged" />
    public class Client : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>The active.</value>
        public virtual int Active { get; set; }
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public virtual string Source { get; set; }
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        public virtual Information Information { get; set; }
        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>The jobs.</value>
        public virtual List<Job> Jobs { get; set; } = new List<Job>();
        /// <summary>
        /// Gets or sets the canvas data.
        /// </summary>
        /// <value>The canvas data.</value>
        public virtual CanvasData CanvasData { get; set; }
        /// <summary>
        /// Gets or sets the sales data.
        /// </summary>
        /// <value>The sales data.</value>
        public virtual SalesData SalesData { get; set; }
        /// <summary>
        /// Gets or sets the survey data.
        /// </summary>
        /// <value>The survey data.</value>
        public virtual SurveyData SurveyData { get; set; }
        /// <summary>
        /// Gets or sets the trade data.
        /// </summary>
        /// <value>The trade data.</value>
        public virtual TradeData TradeData { get; set; }
        /// <summary>
        /// Gets or sets the job post data.
        /// </summary>
        /// <value>The job post data.</value>
        public virtual JobPostData JobPostData { get; set; }
        /// <summary>
        /// Gets or sets the add notification.
        /// </summary>
        /// <value>The add notification.</value>
        public virtual List<Notifications> AddNotification { get; set; } = new List<Notifications>();
    }

}
