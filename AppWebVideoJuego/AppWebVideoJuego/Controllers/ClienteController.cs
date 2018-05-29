namespace AppWebVideoJuego.Controllers
{
	using AppWebVideoJuego.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

	public class ClienteController : Controller
	{
		Cliente objC;

		// GET: Cliente
		public ActionResult Index()
		{
			return View("FormCliente");
		}

		[HttpPost]
		public ActionResult Created()
		{
			objC = new Cliente();
			objC.Cedula = Request["txtCedula"];
			objC.Nombre = Request["txtNombre"];
			objC.Apellido = Request["txtApellido"];
			objC.Telefono = Request["txtTelefono"];
			objC.Direccion = Request["txtDireccion"];
			objC.Email = Request["txtEmail"];

			if (!objC.Validar())
			{
				return View("FormCliente");
			}
			else
			{
				if (objC.Guardar() != 0)
				{
					return View("exitoGuardar");
				}
				else
				{
					return View("errorGuardar");
				}
			}
		}

	}
}