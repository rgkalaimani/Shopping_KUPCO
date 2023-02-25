using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBLayer;
using Datamodel = ShoppingApplication.Models.Datamodel;
using Viewmodel = ShoppingApplication.Models.Viewmodel;

namespace ShoppingAPI.Controllers
{
    public class UserController : Controller
    {
        DataSet ds;

        ShoppingDatabase db;

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction("login", "user");
        }

        [HttpPost]
        public ActionResult Login(Datamodel.UserProfile objProfile)
        {

            string userNmae = objProfile.UserName;
            string password = objProfile.Password;

            ds = new DataSet();

            if (userNmae.Length > 0 && userNmae.Length > 0)
            {
                db = new ShoppingDatabase();
                List<KeyValuePair<string, string>> listUserinfo = new List<KeyValuePair<string, string>>();
                listUserinfo.Add(new KeyValuePair<string, string>("@USERNAME", userNmae));
                listUserinfo.Add(new KeyValuePair<string, string>("@PASSWORD", password));
                ds = db.ExecuteProcedure("SP_LOGIN", listUserinfo);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        Session["UserName"] = userNmae;
                        //Session["UserId"] = user.UserName;


                        return RedirectToAction("home", "orders");
                    }
                }
            }

            return View();
        }


    }
}