namespace Project_Year_2.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyNhaHangDBContext : DbContext
    {
        public QuanLyNhaHangDBContext()
            : base("name=QuanLyNhaHangDBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Bill_Info> Bill_Info { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodTable> FoodTables { get; set; }
        public virtual DbSet<MenuCategory> MenuCategories { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.IdentityID)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTable>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTable>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<FoodTable>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTable>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<MenuCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<MenuCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.IdentityID)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
