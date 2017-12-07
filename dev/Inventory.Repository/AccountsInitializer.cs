using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository
{
    public class AccountsInitializer: DropCreateDatabaseIfModelChanges<AccountsContext>
    {
        protected new void Seed(AccountsContext context)
        {
            
        }
    }
}
