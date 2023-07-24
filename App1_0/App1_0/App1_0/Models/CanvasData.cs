using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class CanvasData
    {
        public string? CompletedById { get; set; }
        public string? CompletedByName { get; set; }
        public int? SitFee { get; set; }
        public int? CommissionFeePercent { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public bool? ActionNeeded { get; set; } = false; //Not mapped
    }
}
