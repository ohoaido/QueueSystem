using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueSystem.Controllers
{
    public class BaseController : Controller
    {
        protected string AccountID => System.Web.HttpContext.Current.User.Identity.GetUserId();
    }
}