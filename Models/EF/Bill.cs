namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Stat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCheckin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCheckout { get; set; }

        public int? ID_Table { get; set; }
    }
}
