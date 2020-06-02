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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            Bill_Infor = new HashSet<Bill_Infor>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Infor> Bill_Infor { get; set; }
    }
}
