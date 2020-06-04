namespace Project_Year_2.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Project_Year_2.Models.EF;

    public partial class QuanLyNhaHangDBContext : DbContext
    {
        public QuanLyNhaHangDBContext()
            : base("name=QuanLyNhaHangDBContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Bill_Infor> Bill_Infor { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Manager>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.IdentityID)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.IdentityID)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);
        }
    }
}
