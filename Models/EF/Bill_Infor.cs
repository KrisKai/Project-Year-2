namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Infor
    {
        [Key]
        public long ID_Bill { get; set; }

        [StringLength(100)]
        public string BillName { get; set; }

        public int? Total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }
    }
}
