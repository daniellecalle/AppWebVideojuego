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
				if (objEst.Guardar() != 0)
				{
					return View("ShowEstados");
				}
				else
				{
					return View("MessageError");
				}
			}
		}



	}
}