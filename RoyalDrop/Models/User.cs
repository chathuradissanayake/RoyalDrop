using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace RoyalDrop.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(12)]
        public string? NIC { get; set; }
        [Display(Name = "First Name")]
        public string? Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string? Lastname { get; set; }
        [Display(Name = "User Name")]
        public string? Username { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(4)]
        public String? Password { get; set; }
        public string? Address { get; set; }
        [Phone]
        [Display(Name = "Contact No.")]
        public string? ContactNo { get; set; }
        public string? Role { get; set; }
        public List<Product>? Purchases { get; set; }

        public string FullName
        {
            get
            {
                return $"{Firstname}{Lastname}";
            }
        }
    }
}
