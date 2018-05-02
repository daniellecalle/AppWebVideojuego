using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebVideoJuego.Controllers
{
    public class TareaEstadoController : Controller
    {
        // GET: TareaEstado
        public ActionResult Index()
        {
            return View("FormTareaEstado");
        }


    }
}