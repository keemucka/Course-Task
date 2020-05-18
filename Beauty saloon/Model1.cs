namespace Beauty_saloon
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Beauty_saloon")
        {
        }

        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<procedure_schedule> procedure_schedule { get; set; }
        public virtual DbSet<service> service { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
