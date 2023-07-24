using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class TradeData
    {
        public string? Id { get; set; }
        public string? CompletedById { get; set; }
        public string? CompletedByName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public int? Accepted { get; set; }
        public string? AcceptedUserId { get; set; }
        public string? LeadTradesmanId { get; set; }
        public int? Complete { get; set; }
        public int? Success { get; set; }
        public string? AdminNotes { get; set; }
        public string? TradeNotes { get; set; }
        public string? Reason { get; set; }
        public int? Attended { get; set; }
    }
}
