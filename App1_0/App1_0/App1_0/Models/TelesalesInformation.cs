using Newtonsoft.Json;

namespace WindowShine_API.Models
{
    public class TelesalesInformation
    {
        public string? Title { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MobileNumber { get; set; } = string.Empty;
        public string? HouseNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Postcode { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public string? Price { get; set; } = string.Empty;
    }
}
