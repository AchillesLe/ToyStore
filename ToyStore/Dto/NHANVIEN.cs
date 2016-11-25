namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        public int MANV { get; set; }

        [Required]
        [StringLength(50)]
        public string TENNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYSINH { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(4)]
        public string PHAI { get; set; }

        [Required]
        [StringLength(9)]
        public string CMT { get; set; }

        [StringLength(20)]
        public string PASS { get; set; }
        public NHANVIEN(int manv,string ten,DateTime ngaysinh,string sdt, string phai,string cmt, string pass)
        {
            this.CMT = cmt;
            this.MANV = manv;
            this.NGAYSINH = ngaysinh;
            this.PHAI = phai;
            this.SDT = sdt;
            this.PASS = pass;
            this.TENNV = ten;
           
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
