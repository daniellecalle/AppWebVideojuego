﻿namespace AppWebVideoJuego.Controllers
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

		[HttpPost]
		public ActionResult Show() 
		{
			objT = new Tarea();
			objT.SetId(Convert.ToInt32(Request["id"]));
			List<Tarea> objlistTareas = objT.MostrarTareas();
			ViewData["listaTareas"] = objlistTareas;
			return View("ShowTareas");
		}

		[HttpPost]
		public ActionResult Edit()
		{
			objT = new Tarea();
			objT.SetId(Convert.ToInt32(Request["id"]));
			objT.SetNombre(Request["txtNombre"]);
			objT.SetDescripcion(Request["txtDescripcion"]);
			objT.SetFecha(Request["txtFecha"]);
			objT.SetHora(Request["txtHora"]);

			List<Tarea> objListaTareas = objT.MostrarTareas();
			ViewData["listaTareas"] = objListaTareas;


			if (objT.EditarTarea() != 0)
			{
				return View("successEdit");
			}
			else
			{
				return View("errorEdit");
			}
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