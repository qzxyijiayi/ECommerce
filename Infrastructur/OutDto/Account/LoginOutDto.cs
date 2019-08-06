using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur.OutDto.Account
{
    public class LoginOutDto
    {
        public LoginOutDto(LoginType loginType, string msg)
        {
            LoginType = loginType;
            Msg = msg;
        }

        public LoginType LoginType { get; set; }

        public string Msg { get; set; }
    }
}
