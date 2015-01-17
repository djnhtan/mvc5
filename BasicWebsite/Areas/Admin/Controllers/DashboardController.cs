using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicWebsite.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        //
        // GET: /Admin/Dashboard/
        [Authorize(Roles="admin")]
        public ActionResult Index()
        {
            return View();
        }
	}
}