using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models.PostData
{
    public class JobPostData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? JobType { get; set; }
        public string? Status { get; set; }
        public string? DeclineJobReason { get; set; } = string.Empty;

        public int CompleteStageAvailable { get; set; }
        public virtual List<string>? RemoveDeclinedUsers { get; set; } = new List<string>();
        public virtual List<string>? AddUsers { get; set; } = new List<string>();
        public virtual List<string>? RemoveUsers { get; set; } = new List<string>();
        public virtual List<string>? AddDeclinedUsers { get; set; } = new List<string>();

    }
}
