namespace AppWebVideoJuego.Controllers
{
	using AppWebVideoJuego.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class EstadoController : Controller
	{
		
		Estado objEst;

		// GET: Estado
		public ActionResult Index()
		{
			return View("NuevoEstado");
		}

		[HttpPost]
		public ActionResult Created()
		{
			objEst = new Estado();
			objEst.SetNombre(Request["txtNombre"]);
			objEst.SetDescripcion(Request["txtDescripcion"]);
			Color c = ColorTranslator.FromHtml(Request["fvColor"]);
			objEst.SetColor(ColorTranslator.ToHtml(c));

			if (!objEst.Validar())
			{
				return View("NuevoEstado");
			}
			else
			{
				if (objEst.Guardar()!=0)
				{
					List<Estado> lista = objEst.ListarEstados();
					ViewData["models"] = lista;
					return View("ShowEstados");
				}
				else
				{
					return View("MessageError");
				}
			}
		}

		public ActionResult ShowEstados()
		{
			objEst = new Estado();
			List<Estado> lista = objEst.ListarEstados();
			ViewData["models"] = lista;
			return View();
		}

		[HttpPost]
		public ActionResult ShowEstado()
		{
			objEst = new Estado();

			objEst.SetId(Convert.ToInt32(Request["id"]));
			objEst.SetNombre(Request["nombre"]);
			objEst.SetDescripcion(Request["descripcion"]);
			Color c = ColorTranslator.FromHtml(Request["fvColor"]);
			objEst.SetColor(ColorTranslator.ToHtml(c));

			ViewData["model"] = objEst;

 			return View();
		}

		[HttpPost]
		public ActionResult ShowFormEdit()
		{
			objEst = new Estado();

			objEst.SetId(Convert.ToInt32(Request["id"]));
			objEst.SetNombre(Request["nombre"]);
			objEst.SetDescripcion(Request["descripcion"]);
			Color c = ColorTranslator.FromHtml(Request["fvColor"]);
			objEst.SetColor(ColorTranslator.ToHtml(c));

			ViewData["model"] = objEst;

			return View();

		}

		[HttpPost]
		public ActionResult SaveFormEdit()
		{
			objEst = new Estado();

			objEst.SetId(Convert.ToInt32(Request["id"]));
			objEst.SetNombre(Request["txtNombre"]);
			objEst.SetDescripcion(Request["txtDescripcion"]);
			Color c = ColorTranslator.FromHtml(Request["fvColor"]);
			objEst.SetColor(ColorTranslator.ToHtml(c));

			if (objEst.Editar() != 0)
			{
				return View("exitoEditar");
			}
			else
			{
				return View("errorEditar");
			}			
		}

		public ActionResult DeleteState()
		{
			objEst = new Estado();

			objEst.SetId(Convert.ToInt32(Request["id"]));

			if (objEst.Eliminar() != 0)
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
