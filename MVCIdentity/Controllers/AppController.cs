using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MVCIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Dashboard()
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

           
           ViewBag.Role = UserManager.GetRoles(id);
         
            ViewBag.UserRole = context.Roles.Where(x => x.Id == id).Select(c => c.Name).FirstOrDefault();
                
          //ViewBag.UserRoles = context.Roles.Where(x => x.Id == id).Select(c => c.Name).ToList();

            };
                  
               return View();
        }
    }
}