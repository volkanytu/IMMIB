using SRC.Web.Portal.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.Portal.Controllers
{
    public class HowtoController : Controller
    {
        // GET: Howto
        public ActionResult Index()
        {
            var page = DynamicPageMock.GetHowtoPage();

            return View(page);
        }
    }
}