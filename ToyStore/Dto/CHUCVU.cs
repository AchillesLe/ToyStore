namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUCVU")]
    public partial class CHUCVU
    {
        [Key]
        [StringLength(4)]
        public string MACV { get; set; }

        [Required]
        [StringLength(30)]
        public string TENCV { get; set; }
    }
}
