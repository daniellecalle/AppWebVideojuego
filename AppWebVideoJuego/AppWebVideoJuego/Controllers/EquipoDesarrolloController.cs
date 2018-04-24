using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebVideoJuego.Controllers
{
    public class EquipoDesarrolloController : Controller
    {
        // GET: EquipoDesarrollo
        public ActionResult Index()
        {
            return View("FormEquipoDesarrollo");
        }
    }
}