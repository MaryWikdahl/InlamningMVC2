using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlamning2Mvc.Models.Entity
{
    public class ProfileEntity
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; } = "";

        [Column(TypeName = "char(6)")]
        public string ZipCode { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; } = "";


        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
