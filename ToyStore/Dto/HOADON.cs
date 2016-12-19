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
        [Key]
        public int MAHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYHD { get; set; }

        public int MANV { get; set; }

        public double? TRIGIA { get; set; }
    }
}
