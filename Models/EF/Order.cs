namespace Project_Year_2.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public long ID_Table { get; set; }

        [StringLength(100)]

        [Display(Name = "Tên họ")]
        public string FirstName { get; set; }

        [StringLength(100)]

        [Display(Name = "Tên khách hàng")]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [Display(Name = "Số người")]
        public int? PeopleCount { get; set; }

        [StringLength(10)]

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]

        [Display(Name = "Ngày")]
        public string Date { get; set; }

        [StringLength(50)]

        [Display(Name = "Thời gian")]
        public string Time { get; set; }

        [StringLength(200)]

        [Display(Name = "Lời nhắn")]
        public string Message { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }
    }
}
