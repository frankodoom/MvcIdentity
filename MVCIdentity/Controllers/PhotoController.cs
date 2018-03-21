using MVCIdentity.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public  async Task<ActionResult> UploadPhotos(IEnumerable<HttpPostedFileBase> files)
        {
            var res = await UploadPhotosAsync(files);
            if (res > 0)
            {
                return ViewBag.Message = "Success";
            }
            return View();
        }

        public async Task<int> UploadPhotosAsync(IEnumerable<HttpPostedFileBase> files)
        {
            int count = 0;
            try
            {
                if (files.Count() > 0)

                {
                    foreach (var file in files)
                    {
                        if (file.ContentLength > 4001000)
                        {
                            continue;    
                        }
                        if (file.ContentType.Contains("gif"))
                        {
                            continue;
                            //return "NotSupported";
                            // return View("UploadPhoto");
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
                                count++;                    
                            }
                        }
                    }
                }
                int result = await Task.FromResult<int>(count);
                return result;

            }
            catch(Exception ex)
            {
                return 0; ;
            }
          
        }

        [HttpGet]
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
            return View();
        }
    }
}