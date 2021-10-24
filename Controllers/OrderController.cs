using BusinessLayer.concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFremawork;
using EntityLayer.concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestOdev.Controllers
{
    public class OrderController : Controller
    {
        OrderManeger cmOrder = new OrderManeger(new EfOrderDal());
        // GET: Order
        public ActionResult Index()
        {
            if (Session["sessionCusId"] == null)
            {
                return RedirectToAction("LoginCustomersforMYOrders", "Login");
            }
            else
            {
                VievModel viewModel = new VievModel();


                int CustomerId = Convert.ToInt32(Session["sessionCusId"].ToString());
                viewModel.Orders = cmOrder.GetListOrder().Where(p => p.CustomerId == CustomerId);


                return View(viewModel);

            }

        }
        public ActionResult DeleteOrder(int id)
        {
            var Ordervalue = cmOrder.GetByIDOrder(id);
            cmOrder.OrderDelete(Ordervalue);
            return RedirectToAction("Index", "Order");
        }

        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            var Ordervalue = cmOrder.GetByIDOrder(id);
            return View(Ordervalue);

        }
        [HttpPost]
        public ActionResult EditOrder(Order p)
        {
            OrderValidation OrderValidator = new OrderValidation();
            ValidationResult result = OrderValidator.Validate(p);
            if (result.IsValid)
            {
                p.UpdatedAt = DateTime.Now;
                p.Status = "Being Evaluated";
                cmOrder.OrderUpdate(p);
                return RedirectToAction("Index", "Order");

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
    }
}