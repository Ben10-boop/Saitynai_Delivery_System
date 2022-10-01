using System.ComponentModel.DataAnnotations;

namespace Saitynai_Delivery_System1.DTOs
{
    public class PackageDto : IValidatableObject
    {
        public string Size { get; set; } = string.Empty;
        [Range(0, 999999)]
        public double Weight { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public int RecipientId { get; set; } = 0;
        public int AssignedToDeliveryId { get; set; } = 0;
        //In warehouse; Being delivered; Delivered;
        public string State { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Size.ToLower() != "small" && Size.ToLower() != "medium" &&
                Size.ToLower() != "large" && Size.ToLower() != "very large" && 
                Size != String.Empty)
            {
                yield return new ValidationResult("Wrong Size value"); 
            }

            if (State.ToLower() != "in warehouse" && State.ToLower() != "being delivered" && 
                State.ToLower() != "delivered" && State != String.Empty)
            {
                yield return new ValidationResult("Wrong State value");
            }
        }
    }
}
