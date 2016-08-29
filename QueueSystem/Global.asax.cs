using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QueueSystem.App_Start;
using QueueSystem.Mappings;
using QueueSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QueueSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var context = new ApplicationDbContext();

            if (!context.PortInfomaitonElectrics.Any(n => n.Name == "Meditech"))
            {
                PortInfomaitonElectric portInfomaitonElectric = new PortInfomaitonElectric();
                portInfomaitonElectric.Name = "Meditech";
                portInfomaitonElectric.Url = "http://meditech.vn/";
                portInfomaitonElectric.IsPublic = true;
                portInfomaitonElectric.Datecreated = DateTime.Now;
                context.PortInfomaitonElectrics.Add(portInfomaitonElectric);
                context.SaveChanges();
            }
            if (!context.Roles.Any(role => role.Name == "SuperAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("SuperAdmin"));
            }
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("Admin"));
            }

            int idPort = context.PortInfomaitonElectrics.Where(n => n.Name == "Meditech").Select(p => p.ID).FirstOrDefault();
            if (!context.Users.Any(user => user.UserName == "admin@meditech.com"))
            {
                var UserManagerFactory = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = new ApplicationUser { UserName = "admin@meditech.com", Email = "admin@meditech.com", PortInfomaitonElectricID = idPort };
                var result = UserManagerFactory.Create(user, "admin123");
                UserManagerFactory.AddToRole(user.Id, "SuperAdmin");
            }
            if (!context.Users.Any(user => user.UserName == "admin@admin.com"))
            {
                var UserManagerFactory = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com", PortInfomaitonElectricID = idPort };
                var result = UserManagerFactory.Create(user, "admin123");
                UserManagerFactory.AddToRole(user.Id, "Admin");
            }

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.Configure();
        }
    }
}
