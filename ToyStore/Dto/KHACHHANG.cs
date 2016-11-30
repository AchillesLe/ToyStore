namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
           // HOADONs = new HashSet<HOADON>();
            HOADONs = new List<HOADON>();
        }

        [Key]
        public int MAKH { get; set; }

        [StringLength(30)]
        public string TENKH { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(10)]
        public string CMT { get; set; }

        public int? DIEMTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      //  public virtual ICollection<HOADON> HOADONs { get; set; }
        public virtual List<HOADON> HOADONs { get; set; }
    }
}
