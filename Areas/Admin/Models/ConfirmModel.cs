using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Year_2.Areas.Admin.Models
{
    public class ConfirmModel
    {
        [Required(ErrorMessage = "Cần nhập tài khoản.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Cần nhập mật khẩu.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Cần nhập lại mật khẩu.")]
        public string ConfirmPassword { get; set; }
        [StringLength(150)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Số điện thoại")]
        public int? PhoneNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(30)]
        [Display(Name = "CMND")]
        public string IdentityID { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? BirthDay { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}