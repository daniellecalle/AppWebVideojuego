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
			private int idEquipo;
		#endregion

		#region "Contructores"
		public Tarea() { }

			public Tarea(int id, string nombre, string descripcion, int idEquipo)
			{
				this.id = id;
				this.nombre = nombre;
				this.descripcion = descripcion;
				this.idEquipo = idEquipo;
				
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

			public int GetId()
			{
				return id;
			}

			public void SetId(int id)
			{
				this.id = id;
			}

			public int GetIdEquipo()
			{
				return idEquipo;
			}

			public void SetIdEquipo(int idEquipo)
			{
				this.idEquipo = idEquipo;
			}

			public bool Validar()
			{
				return (!String.IsNullOrEmpty(nombre) || !String.IsNullOrEmpty(descripcion));
			}



			public int Guardar()
			{
				try
				{
					a = con.Conectar();//retornamos objeto de conexion 
				}
				catch (Exception ex)
				{
					throw ex;
				}

				string sql = "INSERT INTO TAREA (NOMBRE, DESCRIPCION, IDEQUIPO) " +
						"VALUES ('" + GetNombre() + "', '" + GetDescripcion() + "', '" +GetIdEquipo()+ "')";

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

			string sql = "UPDATE TAREA SET NOMBRE='"+GetNombre()+"', DESCRIPCION='"+GetDescripcion()
				+"' WHERE ID="+GetId();
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

			string sql = "DELETE FROM TAREA WHERE ID="+GetId();
			int num = con.operaracion(sql, a);

			return num;
		}

		

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

				string sql = "SELECT * FROM TAREA";
				SqlDataReader d = con.Consulta(sql, a);

				while (d.Read())
				{
					datos.Add(new Tarea()
					{
						id = Convert.ToInt32(d["ID"]),
						nombre = Convert.ToString(d["NOMBRE"]),
						descripcion = Convert.ToString(d["DESCRIPCION"]),
						idEquipo = Convert.ToInt32(d["IDEQUIPO"]),
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
				});
			}

			return lista;
		}

		#endregion
	}
}