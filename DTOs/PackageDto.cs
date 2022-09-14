namespace Saitynai_Delivery_System1.DTOs
{
    public class PackageDto
    {
        public string Size { get; set; } = string.Empty;
        public double Weight { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public int RecipientId { get; set; } = 0;
        public int? DeliveryVehicleId { get; set; } = null;
        //In warehouse; Being delivered; Delivered;
        public string State { get; set; } = "In warehouse";
    }
}
