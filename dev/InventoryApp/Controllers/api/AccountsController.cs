using Accounts.Model;
using Accounts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryApp.Controllers.api
{
    public class AccountsController : ApiController
    {
        [HttpGet]
        [Route("api/Accounts/RawMaterial")]
        public IEnumerable<RawMaterials> RawMaterial()
        {
            UnitOfWork uof = new UnitOfWork();
            var rm = uof.RawMaterialRepository.GetAll();

            return rm;
        }

        [HttpGet]
        [Route("api/Accounts/UserRawMaterials")]
        public IEnumerable<MaterialDistribution> UserRawMaterials()
        {
            UnitOfWork uof = new UnitOfWork();
            var rm = uof.MaterialDistribution.GetAll();

            return rm;
        }

        //
        //
        [HttpPost]
        [Route("api/Accounts/RawMaterialDistribute")]
        public int RawMaterialDistribute(UserMaterialForm userMaterialForm)
        {
            int itemsSaved = 0;
            MaterialDistribution userMatData = new MaterialDistribution();
            if(userMaterialForm != null)
            {
                UnitOfWork uof = new UnitOfWork();
                foreach (var data in userMaterialForm.UserMaterial)
                {
                    userMatData = new MaterialDistribution();

                    userMatData.UserId = userMaterialForm.UserId;
                    userMatData.ID = data.ID;
                    userMatData.Quantity = data.Quantity;
                    userMatData.Rate = data.Rate;
                    userMatData.Unit = data.Unit;
                    userMatData.DistributionDate = DateTime.Today;

                    uof.MaterialDistribution.Insert(userMatData);

                    itemsSaved = itemsSaved + 1;
                }
                uof.Save();
            }

            return itemsSaved;
        }
    }
}
