namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
          //  CTHDs = new HashSet<CTHD>();
        }

        [Key]
        public int MAHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYHD { get; set; }

        public int? MAKH { get; set; }

        public int MANV { get; set; }

        public double? TRIGIA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CTHD> CTHDs { get; set; }

        //public virtual KHACHHANG KHACHHANG { get; set; }

        //public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
