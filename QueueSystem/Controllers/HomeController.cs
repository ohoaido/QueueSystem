using QueueSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueSystem.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeThongXepHang()
        {
            var roles = db.Roles.Where(p => p.Users.Select(x => x.UserId == AccountID).FirstOrDefault());
            Boolean flag = false;
            foreach (var item in roles)
            {
                if (item.Name == "SuperAdmin")
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                return View(db.ManHinhs.ToList());
            }
            else
            {
                int PortInfomaitonElectricID = db.Users.Where(user => user.Id == AccountID).Select(p => p.PortInfomaitonElectricID).FirstOrDefault();
                return View(db.ManHinhs.Where(p => p.PortInfomaitonElectric.ID == PortInfomaitonElectricID).ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}