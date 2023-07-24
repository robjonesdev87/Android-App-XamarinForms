using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class SurveyData
    {
        public string? Id { get; set; } 
        public string? CompletedById { get; set; }
        public string? CompletedByName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public int? Accepted { get; set; }  
        public string? AcceptedUserId { get; set; }
        public int? Complete { get; set; }
        public int? Success { get; set; } 
        public string? AdminNotes { get; set; } 
        public string? SurveyNotes { get; set; }
        public string? Reason { get; set; }
        public int? Attended { get; set; } 
        public string? InventoryRequired { get; set; } 
        public string? Measurements { get; set; } 
        public int? EstimatedCost { get; set; } 
        public int? EstStaffRequired { get; set; }

    }
}
