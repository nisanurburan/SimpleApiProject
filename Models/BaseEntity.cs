using System.ComponentModel.DataAnnotations;

namespace SimpleApiProject.Models;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public enum EntityStatus
    {
        Active = 1,
        Inactive = 0,
        Deleted = -1
    }
    public EntityStatus Status { get; set; }
}

