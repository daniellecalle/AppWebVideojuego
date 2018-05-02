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
			//CAPTURAMOS LA INFORMACION DE CLIENTE
			string cedula = Request["txtCedula"];
			string nombre = Request["txtNombre"];
			string apellido = Request["txtApellido"];
			string tel = Request["txtTelefono"];
			string dir = Request["txtDireccion"];
			string nit = Request["txtNit"];
			string tipoCliente = Request["cbTipoCliente"];

			//INSTANCIAMOS EL OBJETO CLIENTE...
			//LE PASAMOS LOS DATOS CAPTURADOS AL OBJETO (SOBRECARGA)
			objC = new Cliente(nit, tipoCliente, cedula, nombre, dir, apellido, tel);

			if (!objC.Validar1() || !objC.Validar2())
			{
				return View("errorMessage");
			}
			else
			{
				if (objC.Guardar() != 0)
				{
					return View("MostrarClientes");
				}
				else
				{
					return View("ErrorMesage");
				}
			}
		}

	}
}