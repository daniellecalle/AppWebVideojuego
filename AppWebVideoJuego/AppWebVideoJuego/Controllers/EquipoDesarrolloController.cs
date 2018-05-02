namespace AppWebVideoJuego.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using AppWebVideoJuego.Models;

	public class EquipoDesarrolloController : Controller
    {
		EquipoDesarrollo objE;

        // GET: EquipoDesarrollo
        public ActionResult Index()
        {
            return View("FormEquipoDesarrollo");
        }

		public ActionResult Created()
		{
			objE = new EquipoDesarrollo();

			//capturamos la informacion de Equipo
			objE.Nombre = Request["txtNombre"];
			objE.Descripcion = Request["txtDescripcion"];

			if (!objE.Validar())
			{
				return View("FormEquipoDesarrollo");
			}
			else
			{
				if (objE.Guardar() != 0)
				{
					return View("mostrarEquipos");
				}
				else
				{
					return View("error");
				}
			}
		}

	}
}