using MVCIdentity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIdentity.Controllers
{
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            return View("UploadPhoto");
        }

        public ActionResult UploadPhotos()
        {
            return View("UploadPhoto");
        }



    

        [HttpPost]
        public ActionResult UploadPhotos(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                if (files.Count() > 0)
                {
                    foreach (var file in files)
                    {
                        if (file.ContentLength > 4001000)
                        {
                            ViewBag.Message = "FIle size Exceeds 4mb";
                            return View("UploadPhoto");
                        }

                        if (file.ContentType.Contains("gif"))
                        {
                            ViewBag.Message = "gif format not supported";
                            return View("UploadPhoto");
                        }
                        else
                        {
                        
                            string _FileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Photos"), _FileName);

                            var photo = new Photo()
                            {
                                FileName = _FileName,
                                FIleSize = file.ContentLength.ToString(),
                                FileType = file.ContentType,
                                ImageUrl = _path
                            };
                            
                            var context = new ApplicationDbContext();
                            context.Photos.Add(photo);
                            if (context.SaveChanges() > 0)
                            {

                                file.SaveAs(_path);
                            }
                        }
                    }
                }
                ViewBag.Message = "Success";
                return View("UploadPhoto");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("UploadPhoto");
            }
        }



        public ActionResult SearchPhotos()
        {
            ViewBag.Photos = "";
            return View();
        }


        [HttpPost]
        public ActionResult SearchPhotos(string fileName)
        {
            var context = new ApplicationDbContext();
            //var photos = contex.Photos.Where(x => x.FileName == fileName).ToList();
            var photos = context.Photos.Where(x => x.FileName.Contains(fileName)).ToList();
            ViewBag.Photos = photos;
            return View(photos);
        }
    }
}