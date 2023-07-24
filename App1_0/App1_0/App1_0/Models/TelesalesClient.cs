using System;
using System.Collections.Generic;
using System.Text;
using WindowShine_API.Models;

namespace App1_0.Models
{
    public class TelesalesClient
    {
        public string? Id { get; set; } = string.Empty;
        public virtual TelesalesInformation? TelesalesInformation { get; set; }
        public string? ServiceRequired { get; set; } = string.Empty;
        public string? ExpectedStart { get; set; } = string.Empty;
        public int? NameValid { get; set; } = 1;
        public int? PhoneNumberValid { get; set; } = 1;
        public int? AddressValid { get; set; } = 1;
        public int? Interested { get; set; } = 0;
        public int? NotInterested { get; set; } = 0;
        public int? NoAnswer { get; set; } = 0;
        public int? RemoveFromList { get; set; } = 0;
        public int? LastCallLength { get; set; } = 0;
        public int? ContactedTimes { get; set; } = 0;
        public string? InterestedLevel { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public int? Budget { get; set; } = 0;
        public string? Notes { get; set; } = string.Empty;
    }
}
