namespace RosBets
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RosBetsModel : DbContext
    {
        public RosBetsModel()
            : base("name=RosBetsModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
