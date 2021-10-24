using BusinessLayer.concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFremawork;
using EntityLayer.concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestOdev.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        CustomerManeger cm = new CustomerManeger(new EfCustomerDal());
        [HttpGet]
        public ActionResult Index(int? page, Customer c)
        {

            if (TempData["Name"] != null)
            {
                if (TempData["Name"].ToString() == "1")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.CustomerS = cm.GetList().OrderBy(p => p.Name).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Name"].ToString() == "2")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.CustomerS = cm.GetList().OrderBy(p => p.UpdatedAt).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Name"].ToString() == "3")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.CustomerS = cm.GetList().OrderBy(p => p.CreatedAt).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                else
                {
                    VievModel vievModel = new VievModel();

                    vievModel.CustomerS = cm.GetList().ToPagedList(page ?? 1, 10);
                    return View(vievModel);

                }
            }
            else
            {
                VievModel vievModel = new VievModel();

                vievModel.CustomerS = cm.GetList().ToPagedList(page ?? 1, 10);
                return View(vievModel);

            }

        }
        [HttpPost]
        public ActionResult Index(Customer c, int? page)
        {

            if (c.Name == "1")
            {
                TempData["Name"] = "1";
                VievModel vievModel = new VievModel();
                vievModel.CustomerS = cm.GetList().OrderBy(p => p.Name).ToPagedList(page ?? 1, 10);
                return View(vievModel);

            }
            if (c.Name == "0")
            {
                VievModel vievModel = new VievModel();
                vievModel.CustomerS = cm.GetList().ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            if (c.Name == "2")
            {
                TempData["Name"] = "2";
                VievModel vievModel = new VievModel();
                vievModel.CustomerS = cm.GetList().OrderBy(p => p.UpdatedAt).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            if (c.Name == "3")
            {
                TempData["Name"] = "3";
                VievModel vievModel = new VievModel();
                vievModel.CustomerS = cm.GetList().OrderBy(p => p.CreatedAt).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            else
            {
                VievModel vievModel = new VievModel();
                vievModel.CustomerS = cm.GetList().ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }

        }



        public ActionResult DeleteCustomer(int id)
        {
            var customervalue = cm.GetByID(id);
            cm.CustomerDelete(customervalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customervalue = cm.GetByID(id);
            return View(customervalue);

        }
        [HttpPost]
        public ActionResult EditCustomer(Customer p)
        {
            CustomerValidation CustomerValidator = new CustomerValidation();
            ValidationResult result = CustomerValidator.Validate(p);
            if (result.IsValid)
            {
                p.UpdatedAt = DateTime.Now;
                cm.CustomerUpdate(p);
                return RedirectToAction("Index");

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
        AdressManeger cmAdress = new AdressManeger(new EfAddressDal());
        [HttpGet]
        public ActionResult EditAddress(int id)
        {
            var Addressvalue = cmAdress.GetByIDAddress(id);
            return View(Addressvalue);

        }
        [HttpPost]
        public ActionResult EditAddress(Address p)
        {
            AdressValidation categoryValidator = new AdressValidation();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cmAdress.AddressUpdate(p);
                return RedirectToAction("Index");

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

        ProductManeger cmP = new ProductManeger(new EfProductDal());
        public ActionResult Product(int? page)
        {
            VievModel vievModel2 = new VievModel();

            vievModel2.ProductS = cmP.GetListProduct().ToPagedList(page ?? 1, 10);


            return View(vievModel2);
        }



        public ActionResult DeleteProduct(int id)
        {
            var Productvalue = cmP.GetByIDProduct(id);
            cmP.ProductDelete(Productvalue);
            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var Productvalue = cmP.GetByIDProduct(id);
            return View(Productvalue);

        }
        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            ProductValidation categoryValidator = new ProductValidation();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cmP.ProductUpdate(p);
                return RedirectToAction("Product");

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
        public ActionResult addProduct()
        {
            return View();

        }
        [HttpPost]
        public ActionResult addProduct(Product p)
        {

            cmP.ProductAdd(p);
            return RedirectToAction("Product");

        }



        OrderManeger cmOrder = new OrderManeger(new EfOrderDal());
        [HttpGet]
        public ActionResult ManegeOrder(int? page)
        {
            if (TempData["Status"] != null)
            {
                if (TempData["Status"].ToString() == "1")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Customer.Name).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Status"].ToString() == "2")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Product.Name).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Status"].ToString() == "3")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Price).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Status"].ToString() == "4")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.CreatedAt).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Status"].ToString() == "5")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.UpdatedAt).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                if (TempData["Status"].ToString() == "6")
                {
                    VievModel vievModel = new VievModel();
                    vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Status).ToPagedList(page ?? 1, 10);
                    return View(vievModel);
                }
                else
                {
                    VievModel vievModel = new VievModel();

                    vievModel.Orders = cmOrder.GetListOrder().ToPagedList(page ?? 1, 10);
                    return View(vievModel);

                }
            }
            else
            {
                VievModel vievModel3 = new VievModel();

                vievModel3.Orders = cmOrder.GetListOrder().ToPagedList(page ?? 1, 10);

                return View(vievModel3);

            }

        }


        [HttpPost]
        public ActionResult ManegeOrder(Order c, int? page)
        {

            if (c.Status == "1")
            {
                TempData["Status"] = "1";
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Customer.Name).ToPagedList(page ?? 1, 10);
                return View(vievModel);

            }
            if (c.Status == "2")
            {
                TempData["Status"] = "2";
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Product.Name).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            if (c.Status == "3")
            {
                TempData["Status"] = "3";
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Price).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            if (c.Status == "4")
            {
                TempData["Status"] = "4";
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.CreatedAt).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            if (c.Status == "5")
            {
                TempData["Status"] = "5";
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.UpdatedAt).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            if (c.Status == "6")
            {
                TempData["Status"] = "6";
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().OrderBy(p => p.Status).ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }
            else
            {
                VievModel vievModel = new VievModel();
                vievModel.Orders = cmOrder.GetListOrder().ToPagedList(page ?? 1, 10);
                return View(vievModel);
            }

        }

        public ActionResult ManegeOrderStatusApprove(int id)
        {
            var Ordervalue = cmOrder.GetByIDOrder(id);
            Ordervalue.Status = "APPROVED";
            Ordervalue.UpdatedAt = DateTime.Now;
            cmOrder.OrderUpdate(Ordervalue);
            return RedirectToAction("ManegeOrder");
        }
        public ActionResult ManegeOrderStatusrejected(int id)
        {
            var Ordervalue = cmOrder.GetByIDOrder(id);
            Ordervalue.Status = "REJECTED";
            Ordervalue.UpdatedAt = DateTime.Now;
            cmOrder.OrderUpdate(Ordervalue);
            return RedirectToAction("ManegeOrder");
        }
        public ActionResult ManegeOrderStatusrequest(int id)
        {
            var Ordervalue = cmOrder.GetByIDOrder(id);
            Ordervalue.Status = "MONEY CHANGE REQUESTED";
            Ordervalue.UpdatedAt = DateTime.Now;
            cmOrder.OrderUpdate(Ordervalue);
            return RedirectToAction("ManegeOrder");
        }




    }
}