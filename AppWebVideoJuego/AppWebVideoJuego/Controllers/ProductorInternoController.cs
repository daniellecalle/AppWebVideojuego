using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebVideoJuego.Controllers
{
    public class ProductorInternoController : Controller
    {
        // GET: ProductorInterno
        public ActionResult Index()
        {
			return View("FormProductorInterno");
		}
    }
}