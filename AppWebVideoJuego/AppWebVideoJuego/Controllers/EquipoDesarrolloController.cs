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
					List<EquipoDesarrollo> lista = objE.ListarEquipos();
					ViewData["models"] = lista;
					return View("mostrarEquipos");
				}
				else
				{
					return View("error");
				}
			}
		}

		public ActionResult mostrarEquipos()
		{
			objE = new EquipoDesarrollo();
			List<EquipoDesarrollo> lista = objE.ListarEquipos();
			ViewData["models"] = lista;
			return View();
		}

		public ActionResult ShowEquipo()
		{
			objE = new EquipoDesarrollo();

			//capturamos la informacion de Equipo
			objE.Id = Convert.ToInt32(Request["id"]);
			objE.Nombre = Request["nombre"];
			objE.Descripcion = Request["descripcion"];

			ViewData["model"] = objE;

			return View();
		}

		[HttpPost]
		public ActionResult ShowFormEdit()
		{
			objE = new EquipoDesarrollo();

			//capturamos la informacion de Equipo
			objE.Id = Convert.ToInt32(Request["id"]);
			objE.Nombre = Request["nombre"];
			objE.Descripcion = Request["descripcion"];

			ViewData["model"] = objE;

			return View();
		}

		[HttpPost]
		public ActionResult SaveFormEdit()
		{
			objE = new EquipoDesarrollo();

			//capturamos la informacion de Equipo
			objE.Id = Convert.ToInt32(Request["id"]);
			objE.Nombre = Request["txtNombre"];
			objE.Descripcion = Request["txtDescripcion"];

			if (objE.EditarEquipo() != 0)
			{
				return View("exitoEditar");
			}
			else
			{
				return View("errorEditar");
			}

		}

		public ActionResult DeleteEquipment()
		{ 
			objE = new EquipoDesarrollo();

			objE.Id = Convert.ToInt32(Request["id"]);

			if (objE.EliminarEquipo() != 0)
			{
				return View("exitoEliminar");
			}
			else
			{
				return View("errorEliminar");
			}

		}

	}
}