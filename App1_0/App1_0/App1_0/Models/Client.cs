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
    public class Client : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id { get; set; }
        public virtual int Active { get; set; }
        public virtual string Source { get; set; }
        public virtual Information Information { get; set; }
        public virtual List<Job> Jobs { get; set; } = new List<Job>();
        public virtual CanvasData CanvasData { get; set; }
        public virtual SalesData SalesData { get; set; }
        public virtual SurveyData SurveyData { get; set; }
        public virtual TradeData TradeData { get; set; }
        public virtual JobPostData JobPostData { get; set; }
        public virtual List<Notifications> AddNotification { get; set; } = new List<Notifications>();
    }

}
