using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class LoginDto
    {
        [Required]
        [StringLength(maximumLength: 16, ErrorMessage = "用户名长度不能大于16位")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 6, ErrorMessage = "密码必须大于6位小于6位")]
        [DisplayName("密码")]
        public string UserPwd { get; set; }

        [DisplayName("记住名密码")]
        [DefaultValue(false)]
        public bool RmemberPwd { get; set; }
    }
}
