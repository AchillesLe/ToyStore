namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUA")]
    public partial class QUA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAQUA { get; set; }

        public int? SODIEM { get; set; }

        public virtual DOCHOI DOCHOI { get; set; }
    }
}
