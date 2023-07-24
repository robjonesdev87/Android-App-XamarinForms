using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class UserMessages
    {
        public string? Id { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public string? Text { get; set; }
        public int? Read { get; set; }
        public string? SenderId { get; set; }
        public string? SenderName { get; set; }
        public string? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReadDate { get; set; }

    }
}
