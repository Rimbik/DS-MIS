using Accounts.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository
{
    public class AccountsContext : DbContext
    {

        public AccountsContext() : base("name=MISConnectionString")
        {
        }

        public DbSet<RawMaterials> Cars { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserCar> UserCar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Database.SetInitializer<InventoryContext>(null);
            //base.OnModelCreating(modelBuilder);
        }
    }
}
