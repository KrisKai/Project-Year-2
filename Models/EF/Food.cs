namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Food")]
    public partial class Food
    {
        [Key]
        public long ID_Food { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        public double? Price { get; set; }

        public string ImagePath { get; set; }

        public bool Status { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
