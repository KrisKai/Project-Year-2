namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Admin")]
    public partial class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [StringLength(100)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
    }
}
