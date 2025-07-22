using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApiProject.Models;

public class UserClaim
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ClaimId { get; set; }
    public Claim Claim { get; set; }
}