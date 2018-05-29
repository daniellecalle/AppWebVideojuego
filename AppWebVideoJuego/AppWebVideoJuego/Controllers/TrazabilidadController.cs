using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebVideoJuego.Models;

namespace AppWebVideoJuego.Controllers
{
    public class TrazabilidadController : Controller
    {
		Trazabilidad objTb;

		// GET: Trazabilidad
		public ActionResult Index()
        {			
			objTb = new Trazabilidad();
			
			//Cargar los datos de tarea
			List<Tarea> datosTarea = objTb.listaTareas();
			ViewData["modelsTareas"] = datosTarea;

			//Cargar los datos de estados
			List<Estado> datosEstados = objTb.listaEstado();
			ViewData["modelsEstados"] = datosEstados;

            return View("FormTrazabilidad");

		}

		[HttpPost]
		public ActionResult CreatedTrazabilidad()
		{
			objTb = new Trazabilidad();
			Tarea T = new Tarea();
			Estado E = new Estado();

			T.SetId(Convert.ToInt32(Request["cbTarea"]));
			E.SetId(Convert.ToInt32(Request["cbEstado"]));

			objTb.Fecha = Request["fecha"];
			objTb.Hora = Request["hora"];
			objTb.Estado = E;
			objTb.Tarea = T;

			if (Request["cbTarea"] == "0" && Request["cbEstado"] == "0")
			{
				return View("error2");
			}
			else
			{
				if (objTb.Guardar() != 0)
				{
					List<Trazabilidad> lista = objTb.listarDatos();
					ViewData["models"] = lista;
					return View("FormAllTrazabilidad");
				}
				else
				{
					return View("errorguardar");
				}
				
			}
		}

		public ActionResult FormAllTrazabilidad()
		{
			objTb = new Trazabilidad();
			List<Trazabilidad> lista = objTb.listarDatos();
			ViewData["models"] = lista;
			return View();
		}

	}
}