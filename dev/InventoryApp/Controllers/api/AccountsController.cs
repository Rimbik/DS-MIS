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
    }
}
