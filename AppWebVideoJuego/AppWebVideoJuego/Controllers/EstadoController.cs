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
		Conexion con = new Conexion();
		SqlConnection a;
		Estado objEst;

		// GET: Estado
		public ActionResult Index()
		{
			return View("NuevoEstado");
		}

		[HttpPost]
		public ActionResult Created()
		{
			string nombre = Request["txtNombre"];
			string descripcion = Request["txtDescripcion"];
			Color c = ColorTranslator.FromHtml(Request["fvColor"]);
			string color = ColorTranslator.ToHtml(c);
			objEst = new Estado(nombre, color, descripcion);

			if (!objEst.Validar())
			{
				return View("NuevoEstado");
			}
			else
			{
				try
				{
					a = con.Conectar();
				}
				catch (Exception)
				{
					throw;
				}

				string sql = "INSERT INTO TBLESTADO VALUES ('" + objEst.GetNombre() + "', '" + objEst.GetColor()
					+ "', '" + objEst.GetDescripcion() + "')";
				int n = con.operaracion(sql, a);

				if (n != 0)
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