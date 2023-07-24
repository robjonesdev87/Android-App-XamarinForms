using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class JobUsers
    {
        public string? Id { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? RoleName { get; set; } = string.Empty;
        public string? Reason { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? FirebaseToken { get; set; } = string.Empty;
        public int? SitFeeAmount { get; set; } = -1;
        public int? CommissionFeePercent { get; set; } = -1;
        public virtual List<Job>? Jobs { get; set; } = new List<Job>();
        public virtual Job? Job { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastLogin { get; set; }


    }
}
