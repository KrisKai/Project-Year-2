using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Year_2.Areas.Admin.Models
{
    public class LoginModel
    {
        
        [Required(ErrorMessage = "Cần nhập tài khoản.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Cần nhập mật khẩu.")]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}