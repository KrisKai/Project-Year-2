namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Manager")]
    public partial class Manager
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
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

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public bool Status { get; set; }
        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
    }
}
