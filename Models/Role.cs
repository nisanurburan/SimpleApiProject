using System.ComponentModel.DataAnnotations;

namespace SimpleApiProject.Models;

public class Role : BaseEntity
{
    //[Key]
    //public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
