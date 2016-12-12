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
        public CHUCVU()
        {

        }
        [Key]
        [StringLength(4)]
        [Required]
        public string MACV { get; set; }
        [StringLength(30)]
        [Required]
        public string TENCV { get; set; }


    }
}
