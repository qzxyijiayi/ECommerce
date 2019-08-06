using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur.InputDto.Account
{
    public class LoginInputDto
    {
        public string AccountName { get; set; }

        public string Password { get; set; }

        public bool RmemberPassword { get; set; }
    }
}
