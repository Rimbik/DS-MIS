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
        public string RawMaterialDistribute(UserMaterialForm userMaterialForm)
        {
            int itemsSaved = 0;
            MaterialDistribution userMatData = new MaterialDistribution();
            UnitOfWork uof = new UnitOfWork();
            string allotemenrRef = "";

            if (userMaterialForm != null)
            {
                allotemenrRef = string.Format("{0}/{1}", userMaterialForm.AllotementNumber, DateTime.Today.Date.ToShortDateString());

                foreach (var data in userMaterialForm.UserMaterial)
                {
                    userMatData = new MaterialDistribution();

                    userMatData.DistributionNumber = userMaterialForm.DistributionNumber;
                    userMatData.AllotementNumber = userMaterialForm.AllotementNumber;
                    //
                    userMatData.Quantity = data.Quantity;
                    userMatData.Rate = data.Rate;
                    userMatData.Unit = data.Unit;
                    userMatData.DistributionDate = DateTime.Today;

                    uof.MaterialDistribution.Insert(userMatData);

                    itemsSaved = itemsSaved + 1;
                }
                uof.Save();
            }

            return allotemenrRef;
        }


        [HttpGet]
        [Route("api/Accounts/GetBeneficiery/{refNo}")]
        public List<Beneficiery> GetBeneficiery(string refNo)
        {
            var stubBene = new List<Beneficiery>() {
                new Beneficiery() { Name = "LADUP LEPCHA", Id  = 1003, AllotementNumber = "Alt1003", Constituency = "Cons for Alt1003", GPU = "GPU for Alt1003", Distance= "DIS For Alt1003"},
                new Beneficiery() { Name = "BHAKTA BAHADUR MANGER", Id  = 1004, AllotementNumber = "Alt1004",  Constituency = "Cons for Alt1004", GPU = "GPU for Alt1004", Distance= "DIS For Alt1004"},
                new Beneficiery() { Name = "RINGZING LEPCHA", Id  = 1005, AllotementNumber = "Alt1005",Constituency = "Cons for Alt1005", GPU = "GPU for Alt1005", Distance= "DIS For Alt1005"},
                new Beneficiery() { Name = "BHAKTA BAHADUR MANGER", Id  = 1002, AllotementNumber = "02/CMRHM/W/RMDD/GYL", Constituency = "Demo Cons...", GPU ="KARJEE MANGNAM"  },


                };

            return stubBene.Where(b => b.Name.ToLower().Contains(refNo.ToLower())).ToList();
        }

    }

    }


