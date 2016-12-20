namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [Key]
        public int MAPHIEU { get; set; }

        public int MANV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYNHAP { get; set; }

        public double? TONGGIA { get; set; }
    }
}
