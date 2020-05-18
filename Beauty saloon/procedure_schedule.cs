namespace Beauty_saloon
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.procedure_schedule")]
    public partial class procedure_schedule
    {
        
        [Key]
        public int id_procedure { get; set; }

        public int? id_client { get; set; }       

        public int? id_service { get; set; }

        public DateTime? date { get; set; }

        public virtual client client { get; set; }       

        public virtual service service { get; set; }
    }
}
