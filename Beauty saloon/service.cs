namespace Beauty_saloon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.service")]
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            procedure_schedule = new HashSet<procedure_schedule>();
        }

        [Key]
        public int id_service { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int id_employee { get; set; }

        public int cost { get; set; }

        
        public virtual employee employee { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<procedure_schedule> procedure_schedule { get; set; }
    }
}
