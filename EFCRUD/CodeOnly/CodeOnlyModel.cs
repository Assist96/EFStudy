namespace CodeOnly
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeOnlyModel : DbContext
    {
        public CodeOnlyModel()
            : base("name=CodeOnlyModel1")
        {
        }

        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                .Property(e => e.UserInfoName)
                .IsFixedLength();

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.OrderInfo)
                .WithRequired(e => e.UserInfo)
                .WillCascadeOnDelete(false);
        }
    }
}
