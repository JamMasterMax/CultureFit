using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZipHackathon.Models;

namespace ZipHackathon.Controllers
{
    [RoutePrefix("culturefit")]
    public class CultureFitController : Controller
    {
        // GET: TestUpload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [Route("{id:int}")]
        public ActionResult Player(int id)
        {
            PlayerViewModel model = new PlayerViewModel();
            model.Id = id;
            return View(model);
        }
    }
}