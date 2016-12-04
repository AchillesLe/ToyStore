namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("ACCOUNT")]
    public partial class  ACCOUNT
    {
        public ACCOUNT()
        {

        }
        [Key]
        public int ID { get; set; }
        [StringLength(20)]
        [Required]
        public string USERNAME { get; set; }
        [StringLength(20)]
        [Required]
        public string PASS { get; set; }
    }
}
