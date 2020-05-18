namespace Beauty_saloon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            procedure_schedule = new HashSet<procedure_schedule>();
        }

        [Key]
        public int id_client { get; set; }

        [StringLength(100)]
        public string surname { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string lastlename { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public long? number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateofborn { get; set; }

        [StringLength(100)]
        public string login { get; set; }

        public int? password { get; set; } 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<procedure_schedule> procedure_schedule { get; set; }
       
    }
}
