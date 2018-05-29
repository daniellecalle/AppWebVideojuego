namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class VideoJuego
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
		private int id;
		private string objetivo;
			private string publicoObjetivo;
			private double costo;
			private Cliente cliente;
			private Tarea tarea;
		#endregion


		#region "Propiedades"
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Objetivo
		{ 
			get { return objetivo; }
			set { objetivo = value; }
		}

		public string PublicoObjetivo
		{
			get { return publicoObjetivo; }
			set { publicoObjetivo = value; }
		}

		public double Costo
		{
			get { return costo; }
			set { costo = value; }
		}

		public Tarea Tarea
		{
			get { return tarea; }
			set { tarea = value; }
		}

		public Cliente Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}
		#endregion

		public List<Tarea> listaTareas()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT T.ID, T.NOMBRE FROM TAREA T ";

			SqlDataReader leer = con.Consulta(sql, a);

			List<Tarea> listaT = new List<Tarea>();

			while (leer.Read())
			{
				tarea = new Tarea();
				tarea.SetId(Convert.ToInt32(leer["ID"]));
				tarea.SetNombre(Convert.ToString(leer["NOMBRE"]));
				listaT.Add(tarea);
			}

			return listaT;
		}

		public List<Cliente> listaCliente()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT C.CEDULA, C.NOMBRE FROM CLIENTE C";

			SqlDataReader leer = con.Consulta(sql, a);

			List<Cliente> listaC = new List<Cliente>();

			while (leer.Read())
			{
				cliente = new Cliente();
				cliente.Cedula = Convert.ToString(leer["CEDULA"]);
				cliente.Nombre = Convert.ToString(leer["NOMBRE"]);
				listaC.Add(cliente);
			}

			return listaC;
		}


		public int Guardar()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "INSERT INTO VIDEOJUEGO VALUES ('"+Objetivo+"', '"+PublicoObjetivo+"', '"
				+Cliente.Cedula+"', '"+Tarea.GetId()+"', '"+Costo+"')";

			int n = con.operaracion(sql, a);

			return n;
		}

		public List<VideoJuego> listaVideojuegos()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT * FROM VIDEOJUEGO";

			SqlDataReader leer = con.Consulta(sql, a);

			List<VideoJuego> lista = new List<VideoJuego>();

			while (leer.Read())
			{
				VideoJuego V = new VideoJuego();
				V.Id = Convert.ToInt32(leer["ID"]);
				V.Objetivo = Convert.ToString(leer["OBJETIVO"]);
				V.publicoObjetivo = Convert.ToString(leer["PUBLICO_OBJETIVO"]);
				V.Costo = Convert.ToDouble(leer["COSTO"]);

				tarea = new Tarea();
				tarea.SetId(Convert.ToInt32(leer["IDTAREA"]));

				cliente = new Cliente();
				cliente.Cedula = Convert.ToString(leer["CEDCLIENTE"]);

				V.Cliente = cliente;
				V.Tarea = tarea;

				lista.Add(V);
			}

			return lista;
		}


	}
}