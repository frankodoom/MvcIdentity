using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HttpPostedFileHelper;
using MVCIdentity.Models;

namespace MVCIdentity.Controllers
{
    public class AsyncController : Controller
    {
        // GET: Async
        public async Task<ActionResult> Index()
        {
            var context = new ApplicationDbContext();

            var item = context.Photos.Where(x => x.FileType =="");

            //var files = await context.Photos.FindAsync(1);

            //var files = new Photo();
            //files.FileName = "AsyncFile";
            //files.FileType = "jpg";
            //files.FIleSize = "1805";
            //context.Photos.Add(files);
            //var res = await context.SaveChangesAsync();
            //if(res > 0)
            //{
            //    ViewBag.Message = "Files Saved Asynchronously";
            //}
            return View();
        }


        //Async Task
        public async Task DoWork( IEnumerable<HttpPostedFileBase> file)
        {

            var fileHelper = new FileHelper();
            fileHelper.FilePath = "~/Photos";
            fileHelper.FileExtension = "jpeg,png";
            await fileHelper.ProcessFilesAsync(file);
           
        }
    }
}