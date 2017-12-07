using AccountsApp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountsApp.Controllers
{
   // [WebErrHandler]
    public class AccountsController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
    }
}