namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [Key]
        public long ID_Staff { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(30)]
        public string IdentityID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool Status { get; set; }
    }
}
