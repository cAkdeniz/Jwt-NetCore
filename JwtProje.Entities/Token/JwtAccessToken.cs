using JwtProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProje.Entities.Token
{
    public class JwtAccessToken: IToken
    {
        public string Token { get; set; }
    }
}
