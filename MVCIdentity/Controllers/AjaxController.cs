using MVCIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIdentity.Controllers
{
    [Authorize(Roles ="Admin,Biker")]
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
            
        }


        public ActionResult AjaxGet()
        {
       return Json(new {message="Hello Json"},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AjaxPost(JsonDataViewModel model)
        {
            var jvm = new JsonDataViewModel();
            
            return View();
        }


    }
}