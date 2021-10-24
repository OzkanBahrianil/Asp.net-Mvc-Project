using BusinessLayer.concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.concrete;
using DataAccessLayer.EntityFremawork;
using EntityLayer.concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TestOdev.Controllers
{
    public class HomeController : Controller
    {
        ProductManeger cmP = new ProductManeger(new EfProductDal());

        public ActionResult Index()
        {
            var ProductValues = cmP.GetListProduct();
            return View(ProductValues);

        }


        OrderManeger cmo = new OrderManeger(new EfOrderDal());
        [HttpGet]
        public ActionResult AddOrder()
        {
            if (Session["sessionProductId"] == null && Session["sessionAddressId"] == null && Session["sessionCusId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int id = Convert.ToInt32(Session["sessionProductId"].ToString());
                int AddressId = Convert.ToInt32(Session["sessionAddressId"].ToString());
                int CustomerId = Convert.ToInt32(Session["sessionCusId"].ToString());
                VievModel viewModel = new VievModel();

                viewModel.ProductS = cmP.GetListProduct().Where(p => p.Id == id);
                viewModel.AddressS = cma.GetListAddress().Where(p => p.AddressId == AddressId);
                viewModel.CustomerS = cmc.GetList().Where(p => p.CustomerId == CustomerId);

                return View(viewModel);

            }


        }
        [HttpPost]
        public ActionResult AddOrder(Order p)
        {
            p.CustomerId = Convert.ToInt32(Session["sessionCusId"].ToString());
            p.AddressId = Convert.ToInt32(Session["sessionAddressId"].ToString());
            p.Id = Convert.ToInt32(Session["sessionProductId"].ToString());
            p.CreatedAt = DateTime.Now;
            p.UpdatedAt = DateTime.Now;
            p.Status = "Hold";
            cmo.OrderAdd(p);
            return RedirectToAction("Index");

        }
        CustomerManeger cmc = new CustomerManeger(new EfCustomerDal());
        [HttpGet]
        public ActionResult AddCustomer(int id)
        {
            Session["sessionProductId"] = id.ToString();
            return View();

        }
        AdressManeger cma = new AdressManeger(new EfAddressDal());
        [HttpPost]
        public ActionResult AddCustomer(Address p, Customer Cus)
        {

            CustomerValidation CustomerValidator = new CustomerValidation();
            ValidationResult result = CustomerValidator.Validate(Cus);
            if (result.IsValid)
            {
                var search = cmc.GetList().Where(x => x.Email == Cus.Email || x.Name == Cus.Name);
                bool serachE = search.Any();
                if (serachE)
                {
                    ViewBag.X = "you have already registered";
                }
                else
                {
                    cma.AddressAdd(p);
                    Context context = new Context();
                    var i = context.Addresses.OrderByDescending(u => u.AddressId).FirstOrDefault();
                    Cus.CreatedAt = DateTime.Now;
                    Cus.UpdatedAt = DateTime.Now;
                    Cus.AddressId = i.AddressId;
                    cmc.CategoryAdd(Cus);
                    return RedirectToAction("LoginCustomer");

                }

            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ViewBag.X = item.ErrorMessage;

                }
            }
            return View();



        }
        [HttpGet]
        public ActionResult LoginCustomer()
        {
            if (Session["sessionCusId"] != null && Session["sessionAddressId"] != null)
            {
                return RedirectToAction("AddOrder", "Home");
            }
            else
            {
                if (Session["sessionProductId"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();

                }


            }


        }
        [HttpPost]
        public ActionResult LoginCustomer(Customer p)
        {
            Context Login = new Context();
            var userinfo = Login.Customers.FirstOrDefault(x => x.Name == p.Name && x.Email == p.Email);
            if (userinfo != null)
            {
                Session["sessionCusId"] = userinfo.CustomerId.ToString();
                Session["Name"] = userinfo.Name.ToString();
                Session["sessionAddressId"] = userinfo.AddressId.ToString();
                return RedirectToAction("AddOrder", "Home");


            }
            else
            {
                ViewBag.Login = "Login Failed";
                return View();
            }



        }




        [HttpGet]
        public ActionResult Editforcustomers(int id)
        {
            var Customervalue = cmc.GetByID(id);
            return View(Customervalue);

        }
        [HttpPost]
        public ActionResult Editforcustomers(Customer p)
        {

            CustomerValidation CustomerValidator = new CustomerValidation();
            ValidationResult result = CustomerValidator.Validate(p);
            if (result.IsValid)
            {
                p.UpdatedAt = DateTime.Now;
                cmc.CustomerUpdate(p);
                return RedirectToAction("AddOrder");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }
            return View();


        }

        [HttpGet]
        public ActionResult EditforAddress(int id)
        {
            var Addressvalue = cma.GetByIDAddress(id);
            return View(Addressvalue);

        }
        [HttpPost]
        public ActionResult EditforAddress(Address p)
        {
            AdressValidation categoryValidator = new AdressValidation();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cma.AddressUpdate(p);
                return RedirectToAction("AddOrder");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}