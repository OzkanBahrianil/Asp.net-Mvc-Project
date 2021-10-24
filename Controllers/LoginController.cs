using DataAccessLayer.concrete;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TestOdev.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin_User user)
        {
            if (IsValit(user))
            {
                FormsAuthentication.SetAuthCookie(user.UName, false);
                Session["Name"] = user.UName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                @ViewBag.LogAdmin = "Wrong Username Or Password";
                return View();

            }

        }
        private bool IsValit(Admin_User user)
        {
            return (user.UName == "AdminProje" && user.Password == "9876543210");
        }

        [HttpGet]
        public ActionResult LoginCustomersforMYOrders()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCustomersforMYOrders(Customer p)
        {
            Context Login = new Context();
            var userinfo = Login.Customers.FirstOrDefault(x => x.Name == p.Name && x.Email == p.Email);
            if (userinfo != null)
            {
                Session["sessionCusId"] = userinfo.CustomerId.ToString();
                Session["Name"] = userinfo.Name.ToString();
                Session["sessionAddressId"] = userinfo.AddressId.ToString();
                return RedirectToAction("Index", "Order");


            }
            else
            {
                ViewBag.Log = "You entered incorrectly";
                return View();
            }



        }
    }
}