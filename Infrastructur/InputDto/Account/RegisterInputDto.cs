using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur.InputDto.Account
{
    public class RegisterInputDto
    {
        public string AccountName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}
