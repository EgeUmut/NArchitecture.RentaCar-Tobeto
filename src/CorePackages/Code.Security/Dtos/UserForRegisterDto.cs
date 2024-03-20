using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Dtos;

public class UserForRegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }

    public UserForRegisterDto()
    {

    }

    public UserForRegisterDto(string email, string password, string? authenticatorCode)
    {
        Email = email;
        Password = password;
        AuthenticatorCode = authenticatorCode;
    }
}
