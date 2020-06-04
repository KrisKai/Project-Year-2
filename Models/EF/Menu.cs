namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public long ID_Menu { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public string ImagePath { get; set; }

        public bool Status { get; set; }

        public bool Hot { get; set; }

        [StringLength(100)]
        public string Type { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
