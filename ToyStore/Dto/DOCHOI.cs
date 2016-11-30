namespace Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCHOI")]
    public partial class DOCHOI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCHOI()
        {
            CTHDs = new HashSet<CTHD>();
           // CTHDs = new List<CTHD>();
        }

        [Key]
        public int MADC { get; set; }

        [StringLength(200)]
        public string TENDC { get; set; }

        public int? SL { get; set; }

        [StringLength(15)]
        public string NUOCSX { get; set; }

        [StringLength(30)]
        public string LOAI { get; set; }

        public double? GIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       public virtual ICollection<CTHD> CTHDs { get; set; }
       // public virtual List<CTHD> CTHDs { get; set; }

        public virtual QUA QUA{ get; set; }
    }
}
