using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Model
{
    public class MaterialDistribution
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Unit { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int Note { get; set; }
        public DateTime DistributionDate { get; set; }
        public DateTime LastUpdatedOn => DateTime.Today;
    }

    public class UserMaterialForm
    {
        public int UserId { get; set; }
        public List<MaterialDistribution> UserMaterial { get; set; }
    }
}
