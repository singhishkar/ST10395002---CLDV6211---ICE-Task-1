using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcParts.Models
{
    public class Parts
    {
        public int Id { get; set; }

        [Display(Name = "Part Code")]
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The code must be 6 digits long.")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "The code must consist of 6 digits.")]
        public string? Code { get; set; }


        [Display(Name = "Part Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Part Manufacturer")]
        [Required]
        public string? partManufacturer { get; set; }

        [Display(Name = "Car Manufacturer")]
        [Required]
        public string? carManufacturer { get; set; }

        [Display(Name = "Car Model")]
        [Required]
        public string? carModel { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string? Location { get; set; }
    }
}
