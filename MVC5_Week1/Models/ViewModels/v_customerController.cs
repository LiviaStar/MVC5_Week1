using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5_Week1.Models;

namespace MVC5_Week1.Models.ViewModels
{
    public class v_customerController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: v_customer
        public ActionResult v_Index()
        {

            return View(db.v_customer.ToList());
        }

    }
}
