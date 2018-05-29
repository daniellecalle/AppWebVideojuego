namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class Estado
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
			[Key]
			private int id;
		    private string nombre;
			private string color;
			private string descripcion;
		#endregion

		#region "Constructores"
		public Estado() { }

			public Estado(int id, string nombre, string color, string descripcion)
			{
				this.id = id;
				this.nombre = nombre;
				this.color = color;
				this.descripcion = descripcion;
			}
		#endregion

		#region "Metodos Publicos"

			public int GetId()
			{
				return id;
			}

			public void SetId(int id)
			{
				this.id=id;
			}

			public string GetNombre()
			{
				return nombre;
			}

			public void SetNombre(string nombre)
			{
				this.nombre = nombre;
			}

			public string GetColor()
			{
				return color;
			}

			public void SetColor(string color)
			{
				this.color = color;
			}

			public string GetDescripcion()
			{
				return descripcion;
			}

			public void SetDescripcion(string descripcion)
			{
				this.descripcion = descripcion;
			}

		public bool Validar()
			{
				return (!String.IsNullOrEmpty(nombre) || !String.IsNullOrEmpty(color)
					|| !String.IsNullOrEmpty(descripcion));
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

				string sql = "INSERT INTO ESTADO VALUES('"+GetNombre()+"', '"+GetDescripcion()
					+"', '"+GetColor()+"')";
				int n = con.operaracion(sql, a);

				return n;
			}


		public int Editar()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "UPDATE ESTADO SET NOMBRE='"+GetNombre()+"', DESCRIPCION='"+GetDescripcion()
				+"', COLOR='"+GetColor()+"' WHERE ID=" +GetId();

			int n = con.operaracion(sql, a);

			return n;
		}


		public int Eliminar()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "DELETE FROM ESTADO WHERE ID="+GetId();
			int n = con.operaracion(sql, a);

			return n;

		}

		public List<Estado> ListarEstados()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT * FROM ESTADO";
			SqlDataReader leer = con.Consulta(sql, a);

			List<Estado> lista = new List<Estado>();

			while (leer.Read())
			{
				lista.Add(new Estado()
				{
					id = Convert.ToInt32(leer["ID"]),
					nombre = Convert.ToString(leer["NOMBRE"]),
					descripcion = Convert.ToString(leer["DESCRIPCION"]),
					color = Convert.ToString(leer["COLOR"]),
				});
			}

			return lista;
		}
		#endregion
	}
}