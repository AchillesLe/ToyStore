namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAPKHO")]
    public partial class NHAPKHO
    {
        public int MANV { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MADC { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYNHAP { get; set; }

        public int? SL { get; set; }

        public double? GIA { get; set; }

        public virtual DOCHOI DOCHOI { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
