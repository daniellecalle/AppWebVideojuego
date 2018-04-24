namespace AppWebVideoJuego.Controllers
{
	using AppWebVideoJuego.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class TareaController : Controller
	{
		Conexion con = new Conexion();
		SqlConnection a;
		SqlDataReader datos;
		Tarea objT;

		// GET: Tarea
		public ActionResult Index()
		{
			return View("NuevaTarea");
		}

		[HttpPost]
		public ActionResult Created()
		{
			string nombre = Request["txtNombre"];
			string descripcion = Request["txtDescripcion"];
			string fecha = Request["txtFecha"];
			string hora = Request["txtHora"];

			objT = new Tarea(nombre, descripcion, fecha, hora);

			if (!objT.Validar())
			{
				return View();
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

				string sql = "INSERT INTO TBLTAREA (NOMBRE, DESCRIPCION, FECHA, HORA) " +
					"VALUES ('" + objT.GetNombre() + "', '" + objT.GetDescripcion() + "', '" + objT.GetFecha()
					+ "', '" + objT.GetHora() + "')";

				int n = con.operaracion(sql, a);

				if (n != 0)
				{
					return View("ShowTareas");
				}
				else
				{
					return View("MessageError");
				}
			}
		}

		[HttpPost]
		public ActionResult Read()
		{

			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT * FROM TBLTAREA";
			datos = con.Consulta(sql, a);
			Console.WriteLine(datos);

			return View("ShowTareas");
		}
	}
}