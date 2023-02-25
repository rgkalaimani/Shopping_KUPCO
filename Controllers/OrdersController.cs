using DBLayer;
using ShoppingApplication.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viewmodel = ShoppingApplication.Models.Viewmodel;


namespace ShoppingAPI.Controllers
{
    public class OrdersController : Controller
    {
        DataSet ds;        
        List<Product> productList;

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {          

            List<Viewmodel.Order> orderList = new List<Viewmodel.Order>();

            ShoppingDatabase db = new ShoppingDatabase();
            ds = db.ExecuteProcedure("orders_all");
            if (ds != null)
            {
                orderList = DataTableConverter.DashboardList(ds.Tables[0]);
            }

            return View(orderList);
        }

        public ActionResult Order()
        {
            productList = new List<Product>();

            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "all"));
            ds = db.ExecuteProcedure("SP_Product", lst);
            if (ds != null)
            {
                productList = DataTableConverter.ProductList(ds.Tables[0]);
            }

            return View(productList);
        }

        public ActionResult Salesreport()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult voucher()
        {
            return View();
        }
    }
}