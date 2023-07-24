using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string JobCreatedById { get; set; }
        public string JobCreatedByName { get; set; }
        public string Status { get; set; }
        public string JobType { get; set; }
        public int CompleteStageAvailable { get; set; }
        public virtual List<JobUsers> JobUsers { get; set; } = new List<JobUsers>();
        public virtual List<JobUsers> DeclinedUsers { get; set; } = new List<JobUsers>();
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string ClientId { get; set; }
        public SalesData SalesData { get; set; }
        public SurveyData SurveyData { get; set; }
        public TradeData TradeData { get; set; }
    }
}
