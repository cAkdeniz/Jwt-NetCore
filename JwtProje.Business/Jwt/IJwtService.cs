using JwtProje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Business.Jwt
{
    public interface IJwtService
    {
        string CreateToken(AppUser user, List<AppRole> roles);
    }
}
