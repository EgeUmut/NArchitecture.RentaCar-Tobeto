using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities;

public class RefreshToken : BaseEntity<int>
{
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime Revoked { get; set; }   //token kaldırılma tarihi
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; } //yenilenen token alanı
    public string? RevokedReason { get; set; }
    public virtual User User { get; set; }

    public RefreshToken(int userId, string token, DateTime expires, string createdByIp, DateTime revoked, string? revokedByIp, string? replacedByToken, string? revokedReason)
    {
        UserId = userId;
        Token = token;
        Expires = expires;
        CreatedByIp = createdByIp;
        Revoked = revoked;
        RevokedByIp = revokedByIp;
        ReplacedByToken = replacedByToken;
        RevokedReason = revokedReason;
    }

    public RefreshToken()
    {

    }
}
