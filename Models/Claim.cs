using System.ComponentModel.DataAnnotations;

namespace SimpleApiProject.Models
{
    public class Claim
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        [MaxLength(200)]
        public string Value { get; set; }

        public ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
    }
}