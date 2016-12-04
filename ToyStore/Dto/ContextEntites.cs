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

        public virtual DbSet<BAOCAO> BAOCAOs { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DOCHOI> DOCHOIs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DOCHOI>()
            //    .HasMany(e => e.CTHDs)
            //    .WithRequired(e => e.DOCHOI)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<HOADON>()
            //    .HasMany(e => e.CTHDs)
            //    .WithRequired(e => e.HOADON)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<NHANVIEN>()
            //    .HasMany(e => e.HOADONs)
            //    .WithRequired(e => e.NHANVIEN)
            //    .WillCascadeOnDelete(false);
        }
    }
}
