using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppWebVideoJuego.Models;

namespace AppWebVideoJuego.Controllers
{
    public class VideoJuegoController : Controller
    {
		VideoJuego objV;

        // GET: VideoJuego
        public ActionResult Index()
        {
			objV = new VideoJuego();

			List<Tarea> listaTareas = objV.listaTareas();
			ViewData["modelstareas"] = listaTareas;

			List<Cliente> listaClientes = objV.listaCliente();
			ViewData["modelsclientes"] = listaClientes;

			return View("FormVideojuego");
        }

		[HttpPost]
		public ActionResult CrearVideojuego()
		{
			objV = new VideoJuego();

			Cliente C = new Cliente();
			C.Cedula = Request["cbCliente"];

			Tarea T = new Tarea();
			T.SetId(Convert.ToInt32(Request["cbTarea"]));

			objV.Objetivo = Request["txtObjetivo"];
			objV.PublicoObjetivo = Request["txtPublicoObjetivo"];
			objV.Costo = Convert.ToDouble(Request["txtCosto"]);
			objV.Cliente = C;
			objV.Tarea = T;

			if (Request["cbTarea"] == "0" && Request["cbCliente"] == "0")
			{
				return View("error");
			}
			else
			{
				if (objV.Guardar() != 0)
				{
					List<VideoJuego> lista = objV.listaVideojuegos();
					ViewData["models"] = lista;
					return View("FormAllVideojuego");
				}
				else
				{
					return View("errorGuardar");
				}
			}
		}

		public ActionResult FormAllVideojuego()
		{
			objV = new VideoJuego();
			List<VideoJuego> lista = objV.listaVideojuegos();
			ViewData["models"] = lista;
			return View();
		}

	}


}