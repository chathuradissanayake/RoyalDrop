using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoyalDrop.Models
{
    public class Purchase
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [NotMapped]
        public DateOnly PurchaseDate {  get; set; }
        //[NotMapped]
        //public DateOnly EndDate { get; set;}
    }
}
