using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MVCIdentity.JsonObjects;
using MVCIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVCIdentity.Controllers
{
    [Authorize]
    public class AppController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
       
        // GET: App
        public  ActionResult Dashboard()
        {
            var context = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                //Username of Signed In user
               // var name = User.Identity.Name;

          // Userid of Signed In user
         var id = User.Identity.GetUserId();

         // Get the profile of signed in user from Asp.Net User Table
         var userProfile = context.Users.Where(x => x.Id == id).FirstOrDefault();
         ViewBag.ProfileImage = userProfile.ImageUrl;
                ViewBag.FullName = userProfile.FirstName + " " + userProfile.LastName;    
              ViewBag.UserRole = context.Roles.Where(x => x.Id == id).Select(c => c.Name).FirstOrDefault();
                
          //ViewBag.UserRoles = context.Roles.Where(x => x.Id == id).Select(c => c.Name).ToList();

            }
            else
            {
                return Content("Unauthorized access please consult administrator");
            }
            
            return View();
        }



        public async Task<ActionResult> GetChartData()
        {
            var data = await PopulateChart();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        

        //populate demograpics
        public Task<string> PopulateChart()
        {
            var context = new ApplicationDbContext();
            var maleCount = context.Students.Where(x => x.Gender == "Male").Count();
            var femaleCount = context.Students.Where(s => s.Gender == "Female").Count();

            List<GenderData> gData = new List<GenderData>()
            {
            new GenderData{xValue= "Male", yValue= maleCount.ToString()},
            new GenderData{xValue= "Female", yValue= femaleCount.ToString()}
            };

            var jsonSerializer = new JavaScriptSerializer();
            string data =  jsonSerializer.Serialize(gData);
            return Task.FromResult(data);
        }


        
    }
}