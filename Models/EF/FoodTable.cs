namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodTable")]
    public partial class FoodTable
    {
        [Key]
        public long ID_Table { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public int? PeopleCount { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(200)]
        public string Message { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
