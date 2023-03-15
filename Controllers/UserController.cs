﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBLayer;
using ShoppingApplication.Models.Viewmodel;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Frozen()
        {
            return View();
        }

        public ActionResult customer()
        {
            return View();
        }

        public ActionResult order()
        {
            return View();
        }


        public ActionResult ChangeLanguage(string lang)
        {
            Session["lang"] = lang;
            return RedirectToAction("login", ConfigurationManager.AppSettings["domainurl"].ToString()+"User");//, new { language = lang });
        }

        public ActionResult Users()
        {

            List<Datamodel.UserProfile> userList = new List<Datamodel.UserProfile>();
            UserInfoDdata obj = new UserInfoDdata();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "getall"));

            ds = db.ExecuteProcedure("SP_UserInfo", lst);
            if (ds != null)
            {
                userList = obj.ConvertToUsersList(ds.Tables[0]);
            }

            return View(userList);
        }

        public ActionResult Driver()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            Session.RemoveAll();

            return RedirectToAction("login", ConfigurationManager.AppSettings["domainurl"].ToString() + "user");
        }

        [HttpPost]
        public ActionResult Login(Datamodel.UserProfile objProfile)
        {
            Session["txtdir"] = "ltr";
            Session["txtlang"] = "en";

            if (Session["lang"] != null)
            {
                if (Session["lang"].ToString().ToLower() == "ar")
                {
                    Session["txtdir"] = "rtl";
                    Session["txtlang"] = "ar";
                }
            }

            string userNmae = objProfile.UserName;
            string password = objProfile.Password;

            ds = new DataSet();

            if (userNmae != null & password != null)
            {
                if (userNmae.Length > 0 && password.Length > 0)
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
                            string role = ds.Tables[0].Rows[0]["userrole"].ToString() == "superadmin" ? "admin" : ds.Tables[0].Rows[0]["userrole"].ToString();
                            Session["UserName"] = userNmae;
                            Session["userrole"] = role;

                            objProfile = new Datamodel.UserProfile();

                            objProfile.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]);
                            objProfile.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                            objProfile.UserType = Convert.ToString(ds.Tables[0].Rows[0]["usertype"]);
                            objProfile.UserRole = role;
                            Session["UserProfile"] = objProfile;

                            var domainurl = ConfigurationManager.AppSettings["domainurl"].ToString();

                            if (role == "admin")
                            {

                                return RedirectToAction("home", domainurl + "orders");
                            }
                            else if (role == "callcentre")
                            {
                                return RedirectToAction("order", domainurl + "orders");
                            }
                            else if (role == "driver")
                            {
                                return RedirectToAction("delivery", domainurl + "orders");
                            }
                            else if (role == "slaughter")
                            {
                                return RedirectToAction("slaughter", domainurl + "orders");
                            }
                            else
                            {
                                ViewBag.loginmessage = Resources.Global.Invalid_Role_Mapped;
                            }
                        }
                        else
                        {
                            ViewBag.loginmessage = Resources.Global.Invalid_UserName_Password;
                        }
                    }
                    else
                    {
                        ViewBag.loginmessage = Resources.Global.Invalid_UserName_Password;
                    }
                }
                else
                {
                    ViewBag.loginmessage = Resources.Global.User_Name_Passord_not_empty;
                }
            }
            else
            {
                ViewBag.loginmessage = Resources.Global.User_Name_Passord_not_empty;
            }

            return View();
        }

        private string getScreens(string fileName)
        {
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/Screens/" + fileName + ".txt"));

            return fileContents;
        }
    }
}