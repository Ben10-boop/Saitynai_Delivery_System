using System.Text.Json.Serialization;

namespace Saitynai_Delivery_System1.Models
{
    public class User
    {
        //default
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; //Client; Courier; Administrator 
        public string Status { get; set; } = "Active";
        public string Password { get; set; } = string.Empty; //temp
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }

        //if Client
        [JsonIgnore]
        public List<Package>? Packages { get; set; }

        //if Courier
        public string? Phone { get; set; }
        public double? Wage { get; set; }
        [JsonIgnore]
        public Vehicle? DeliveryVehicle { get; set; }
        [JsonIgnore]
        public List<Delivery>? Deliveries { get; set; }

    }
}
