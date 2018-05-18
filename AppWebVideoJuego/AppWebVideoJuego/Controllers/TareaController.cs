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
					List<Tarea> objListaTareas = objT.ListarTareas();
					ViewData["listaTareas"] = objListaTareas;
					return View("ShowTareas");
				}
				else
				{
					return View("MessageError");
				}
			}
		}

		public ActionResult ShowAllTask()
		{
			objT = new Tarea();
			List<Tarea> objListaTareas = objT.ListarTareas();
			ViewData["listaTareas"] = objListaTareas;
			return View("ShowTareas");
		}

		[HttpPost]
		public ActionResult ShowForm() 
		{ 
			objT = new Tarea();

			//Capuramos los datos
			objT.SetId(Convert.ToInt32(Request["id"]));
			objT.SetNombre(Request["nombre"]);
			objT.SetDescripcion(Request["descripcion"]);
			objT.SetFecha(Request["fecha"]);
			objT.SetHora(Request["hora"]);

			ViewData["model"] = objT;

			return View("_Show");
		}

		[HttpPost]
		public ActionResult ShowFormEdit()
		{
			objT = new Tarea();

			//capturamos la informacion del formulario
			objT.SetId(Convert.ToInt32(Request["id"]));
			objT.SetNombre(Request["nombre"]);
			objT.SetDescripcion(Request["descripcion"]);
			objT.SetFecha(Request["fecha"]);
			objT.SetHora(Request["hora"]);

			//Enviamos los datos ala vista
			ViewData["modeltask"] = objT;

			return View("ShowTareas");
		}
		

		public ActionResult SaveFormEdit()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Delete()
		{
			objT = new Tarea();
			objT.SetId(Convert.ToInt32(Request["id"]));

			if (objT.EliminarTarea() != 0)
			{
				return View("successDelete");
			}
			else
			{
				return View("errorDelete");
			}

		}
		
	}
}