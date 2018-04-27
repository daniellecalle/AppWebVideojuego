namespace AppWebVideoJuego.Controllers
{
	using AppWebVideoJuego.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class TareaController : Controller
	{

		Tarea objT;

		// GET: Tarea
		public ActionResult Index()
		{
			return View("NuevaTarea");
		}

		[HttpPost]
		public ActionResult Created()
		{

			objT = new Tarea();

			objT.SetNombre(Request["txtNombre"]);
			objT.SetDescripcion(Request["txtDescripcion"]);
			objT.SetFecha(Request["txtFecha"]);
			objT.SetHora(Request["txtHora"]);

			if (!objT.Validar())
			{
				return View();
			}
			else
			{
				if (objT.Guardar() != 0)
				{
					return View("ShowTareas");
				}
				else
				{
					return View("MessageError");
				}
			}
		}

		
	}
}