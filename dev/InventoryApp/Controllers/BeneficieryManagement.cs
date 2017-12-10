using Accounts.Model;
using Accounts.Repository;
using AccountsApp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountsApp.Controllers
{
    //[WebErrHandler]
    public class BeneficieryManagementController : ApiController
    {
        [HttpGet]
        [Route("api/BeneficieryManagement/GetUserCar")]
        public IEnumerable<Beneficiery> GetBeneficieryByName(string userName)
        {
            UnitOfWork uof = new UnitOfWork();
            var users = uof.Beneficiery.GetAll();
            var data = users.Where(u => u.Name == userName);

            return data;
        }

        [HttpGet]
        [Route("api/BeneficieryManagement/GetUserCar")]
        public Beneficiery GetBeneficieryByAllotement(string allotementNumber)
        {
            UnitOfWork uof = new UnitOfWork();
            var users = uof.Beneficiery.GetAll();
            var data = users.FirstOrDefault(u => u.AllotementNumber == allotementNumber);

            return data;
        }

        //[HttpPost]
        //[Route("api/UserInventory/EditUserCar")]
        //public bool EditUserCar(string userId, string carId, string model, string brand, string price, string year)
        //{
        //    UnitOfWork uof = new UnitOfWork();
        //    //var car = new Car() { Id = int.Parse(carId) };
        //    //uof.CarRepository.Delete(car);

        //    uof.CarRepository.Update(
        //      new Car()
        //      { Id = int.Parse(carId), Brand = brand, Model = model, OwnerId = int.Parse(userId), Price = decimal.Parse(price), Year = int.Parse(year) }
        //    );

        //    uof.Save();

        //    return true;
        //}

        [HttpPost]
        [Route("api/UserInventory/AddBeneficiery")]
        public bool AddBeneficiery(Beneficiery beneficiery)
        {
            UnitOfWork uof = new UnitOfWork();
            uof.Beneficiery.Insert(beneficiery);
            uof.Save();

            return true;
        }
    }
}
