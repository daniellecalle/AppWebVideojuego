namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;
	
	public class Tarea
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
			[Key]
			private int id;
			private string nombre;
			private string descripcion;
			private string fecha;
			private string hora;
		#endregion

		#region "Contructores"
			public Tarea() { }

			public Tarea(int id, string nombre, string descripcion, string fecha, string hora)
			{
				this.id = id;
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

			public int GetId()
			{
				return id;
			}

			public void SetId(int id)
			{
				this.id = id;
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
				catch (Exception ex)
				{
					throw ex;
				}

				string sql = "INSERT INTO TBLTAREA (NOMBRE, DESCRIPCION, FECHA, HORA) " +
						"VALUES ('" + GetNombre() + "', '" + GetDescripcion() + "', '" + GetFecha()
						+ "', '" + GetHora() + "')";

				int n = con.operaracion(sql, a);

				return n;
			}

		public int EditarTarea()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "UPDATE TBLTAREA SET NOMBRE='"+GetNombre()+"', '"+GetDescripcion()
				+"', '"+GetFecha()+"','"+GetHora()+"' WHERE ID = "+GetId();
			int num = con.operaracion(sql, a);

			return num;
		}

		public int EliminarTarea()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "DELETE FROM TBLTAREA WHERE ID="+GetId();
			int num = con.operaracion(sql, a);

			return num;
		}

		
		/*public List<Tarea> ListarEquipos()
		{ 

			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			List<Tarea> datos = new List<Tarea>();
			SqlDataReader d;

			string sql = "SELECT E.ID, E.NOMBRE FROM TBLTAREA T INNER JOIN TBLEQUIPO E ON T.IDEQUIPO = E.ID";

			d = con.Consulta(sql, a);

			while (d.Read())
			{
				datos.Add(new Tarea()
				{
					idEquipo = Convert.ToInt32(d["ID"]),
					nomEquipo = Convert.ToString(d["NOMBRE"])
				});

			}

			return datos;

		}*/

		public List<Tarea> ListarTareas()
		{
				try
				{
					a = con.Conectar();
				}
				catch (Exception)
				{
					throw;
				}

				List<Tarea> datos = new List<Tarea>();

				string sql = "SELECT * FROM TBLTAREA";
				SqlDataReader d = con.Consulta(sql, a);

				while (d.Read())
				{
					datos.Add(new Tarea()
					{
						id = Convert.ToInt32(d["ID"]),
						nombre = Convert.ToString(d["NOMBRE"]),
						descripcion = Convert.ToString(d["DESCRIPCION"]),
						fecha = Convert.ToString(d["FECHA"]),
						hora = Convert.ToString(d["HORA"])
					});
				}

				return datos;
		}

		public List<Tarea> MostrarTareas()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception e)
			{
				throw e;
			}

			string sql = "SELECT * FROM TBLTAREA WHERE ID="+GetId();
			SqlDataReader d = con.Consulta(sql, a);
			List<Tarea> lista = new List<Tarea>();

			while (d.Read())
			{
				lista.Add(new Tarea()
				{
					id = Convert.ToInt32(d["ID"]),
					nombre=Convert.ToString(d["NOMBRE"]),
					descripcion = Convert.ToString(d["DESCRIPCION"]),
					fecha = Convert.ToString(d["FECHA"]),
					hora = Convert.ToString(d["HORA"]),
				});
			}

			return lista;
		}

		#endregion
	}
}