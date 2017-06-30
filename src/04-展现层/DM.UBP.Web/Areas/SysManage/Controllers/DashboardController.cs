using DM.UBP.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DM.UBP.Web.Areas.SysManage.Controllers
{
    public class DashboardController : UbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}