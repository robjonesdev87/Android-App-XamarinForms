using System;
using System.Collections.Generic;
using System.Text;

namespace App1_0.Models
{
    public class ImageForUpload
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string ClientId { get; set; }
        public string JobId { get; set; }
    }
}
