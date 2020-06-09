namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("User_Infor")]
    public partial class User_Infor
    {
        public long ID { get; set; }

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

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime? BirthDay { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
        public virtual Account Account { get; set; }
    }
}
