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
        public string Name { get; set; }

        public string Avatar { get; set; }

        public int? PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(30)]
        public string IdentityID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
        public virtual Account Account { get; set; }
    }
}
