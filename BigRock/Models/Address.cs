using System.ComponentModel.DataAnnotations;

namespace BigRock.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Address block")]
        [DataType(DataType.MultilineText)]
        public string Block { get; set; }

        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Display(Name = "Zip")]
        [DataType(DataType.Text)]
        [Required]
        public string ZipCode { get; set; }
    }
}