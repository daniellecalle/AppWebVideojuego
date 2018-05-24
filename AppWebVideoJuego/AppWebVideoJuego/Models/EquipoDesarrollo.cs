namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class EquipoDesarrollo
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
			[Key]
			private int id;
			private string nombre;
			private string descripcion;
		#endregion

		#region "Constructores"
			public EquipoDesarrollo() { }

			public EquipoDesarrollo(int id, string nombre, string descripcion)
			{
				this.nombre = nombre;
				this.descripcion = descripcion;
			}
		#endregion

		#region "Propieades"

			public int Id
			{
				get { return id; }
				set { id = value; }
			}

			public string Nombre
			{
				get { return nombre; }
				set { nombre = value; }
			}

			public string Descripcion
			{
				get { return descripcion; }
				set { descripcion = value; }
			}
		#endregion

		#region "Metodos Publicos"
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

			string sql = "INSERT INTO EQUIPO VALUES ('"+Nombre+"', '"+Descripcion+"')";
			int n = con.operaracion(sql, a);

			return n;
		}

		public int EditarEquipo()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "UPDATE EQUIPO SET NOMBRE='"+Nombre+"', DESCRIPCION='"+Descripcion+"' WHERE ID="+Id;
			int n = con.operaracion(sql, a);

			return n;
		}

		public int EliminarEquipo()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "DELETE FROM EQUIPO WHERE ID="+Id;

			int n = con.operaracion(sql, a);

			return n;
		}

		public List<EquipoDesarrollo> ListarEquipos()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT * FROM EQUIPO";
			SqlDataReader leer = con.Consulta(sql, a);

			List<EquipoDesarrollo> lista = new List<EquipoDesarrollo>();

			while (leer.Read())
			{
				lista.Add(new EquipoDesarrollo() {
					id = Convert.ToInt32(leer["ID"]),
					nombre = Convert.ToString(leer["NOMBRE"]),
					descripcion = Convert.ToString(leer["DESCRIPCION"]),
				});
			}

			return lista;
		}

		public List<EquipoDesarrollo> listarEquiposConTareas()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT ID, NOMBRE FROM EQUIPO;";
			SqlDataReader leer = con.Consulta(sql, a);

			List<EquipoDesarrollo> listaEquipos = new List<EquipoDesarrollo>();

			while (leer.Read())
			{
				listaEquipos.Add(new EquipoDesarrollo()
				{
					id = Convert.ToInt32(leer["ID"]),
					nombre = Convert.ToString(leer["NOMBRE"]),
				});
			}

			return listaEquipos;
		}
		#endregion
	}
}