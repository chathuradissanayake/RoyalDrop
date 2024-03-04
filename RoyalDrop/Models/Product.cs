using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoyalDrop.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		[NotMapped]
        [Display(Name = "View")]
        public IFormFile? ProductImage { get; set; }

		[StringLength(500)]
		public string? ImageUrl { get; set; }

		[Required]
        [Display(Name = "Product")]
        public string? Productname { get; set; }

		[Required]
		public string? Brand { get; set; }
		public string? Description { get; set; }

		[Required]
        [Display(Name = "Price")]
        public decimal Purchase { get; set; }


		[Required]
        [Display(Name = "Remain")]
        public int Quantity { get; set; }
	}
}
