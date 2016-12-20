namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAO")]
    public partial class BAOCAO
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime NGAYBAOCAO { get; set; }

        public double? TONGGIATRI { get; set; }
    }
}
