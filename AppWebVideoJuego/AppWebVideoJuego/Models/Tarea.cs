namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class Tarea
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
		private string nombre;
			private string descripcion;
			private string fecha;
			private string hora;
			//private int estado;
		#endregion

		#region "Contructores"
			public Tarea() { }

			public Tarea(string nombre, string descripcion, string fecha, string hora)
			{
				this.nombre = nombre;
				this.descripcion = descripcion;
				this.fecha = fecha;
				this.hora = hora;
			}
		#endregion

		#region "Metodos Publicos"
			public string GetNombre()
			{
				return nombre;
			}

			public void SetNombre(string nombre)
			{
				this.nombre = nombre;
			}

			public string GetDescripcion()
			{
				return descripcion;
			}

			public void SetDescripcion(string descripcion)
			{
				this.descripcion = descripcion;
			}

			public string GetFecha()
			{
				return fecha;
			}

			public void SetFecha(string fecha)
			{
				this.fecha = fecha;
			}

			public string GetHora()
			{
				return hora;
			}

			public void SetHora(string hora)
			{
				this.hora = hora;
			}


			public bool Validar()
			{
				return (!String.IsNullOrEmpty(nombre) || !String.IsNullOrEmpty(descripcion));
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

				string sql = "INSERT INTO TBLTAREA (NOMBRE, DESCRIPCION, FECHA, HORA) " +
						"VALUES ('" + GetNombre() + "', '" + GetDescripcion() + "', '" + GetFecha()
						+ "', '" + GetHora() + "')";

				int n = con.operaracion(sql, a);

				return n;
			}

		

		#endregion
	}
}