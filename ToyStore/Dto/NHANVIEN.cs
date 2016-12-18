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
            NHAPKHOes = new HashSet<NHAPKHO>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MANV { get; set; }

        [Required]
        [StringLength(50)]
        public string TENNV { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(60)]
        public string QUEQUAN { get; set; }

        [StringLength(4)]
        public string PHAI { get; set; }

        [StringLength(9)]
        public string CMT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYSINH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYVAOLAM { get; set; }

        [Required]
        [StringLength(4)]
        public string MACV { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAPKHO> NHAPKHOes { get; set; }
    }
}
