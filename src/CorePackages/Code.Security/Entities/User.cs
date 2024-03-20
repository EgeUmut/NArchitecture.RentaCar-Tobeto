using Core.Persistence.Repositories;
using Core.Security.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Security.Entities;

public class User : BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Status { get; set; }
    public AuthenticatorType authenticatorType { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    public User()
    {
        RefreshTokens = new HashSet<RefreshToken>();
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }


}
