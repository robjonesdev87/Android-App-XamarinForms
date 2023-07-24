using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class SalesData
    {
        public string? Id { get; set; }
        public string? CompletedById { get; set; }
        public string? CompletedByName { get; set; }
        public DateTime? AppointmentDate { get; set; } 
        public TimeSpan? AppointmentTime { get; set; } 
        public DateTime? PrefCompletiontDate { get; set; } 
        public int? MinimumQuote { get; set; }
        public DateTime? PaymentDate { get; set; } 
        public int? Accepted { get; set; }
        public string? AcceptedUserId { get; set; }
        public int? Complete { get; set; }
        public int? Success { get; set; }
        public string? AdminNotes { get; set; }
        public string? SalesNotes { get; set; }
        public string? Reason { get; set; }
        public int? Attended { get; set; }
        public float? TotalToPay { get; set; }
        public float? DepositTotal { get; set; }
        public int? DepositPercentage { get; set; }  //Is this needed? 0 uses currently
        public int? DepositPaidBool { get; set; } 
        public int? PaidInFullBool { get; set; }
        public string? PaymentType { get; set; }

    }
}
