using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Year_2.Models.EF
{

        [Table("Bill")]
        public class Bill
        {
            [Key]
            [Column(Order = 1)]
            public long ID_Bill { get; set; }

            [Key]
            [Column(Order = 2)]
            public long ID_Menu { get; set; }
            public virtual Bill_Infor Bill_Infor { get; set; }
            public virtual Menu Menu { get; set; }

        }
    
}