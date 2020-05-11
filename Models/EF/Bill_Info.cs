namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Info
    {
        public int ID { get; set; }

        public int? ID_Bill { get; set; }

        public int? ID_Food { get; set; }

        public int? Count { get; set; }
    }
}
