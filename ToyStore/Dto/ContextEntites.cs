namespace Dto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextEntites : DbContext
    {
        public ContextEntites()
            : base("name=ContextEntites")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<BAOCAO> BAOCAOs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DOCHOI> DOCHOIs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAPKHO> NHAPKHOes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CHUCVU>()
            //    .HasMany(e => e.NHANVIENs)
            //    .WithRequired(e => e.CHUCVU)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DOCHOI>()
            //    .HasMany(e => e.CTHDs)
            //    .WithRequired(e => e.DOCHOI)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCHOI>()
                .HasOptional(e => e.NHAPKHO)
                .WithRequired(e => e.DOCHOI);

            //modelBuilder.Entity<HOADON>()
            //    .HasMany(e => e.CTHDs)
            //    .WithRequired(e => e.HOADON)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasOptional(e => e.ACCOUNT)
                .WithRequired(e => e.NHANVIEN);

            //modelBuilder.Entity<NHANVIEN>()
            //    .HasMany(e => e.HOADONs)
            //    .WithRequired(e => e.NHANVIEN)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<NHANVIEN>()
            //    .HasMany(e => e.NHAPKHOes)
            //    .WithRequired(e => e.NHANVIEN)
            //    .WillCascadeOnDelete(false);
        }
    }
}
