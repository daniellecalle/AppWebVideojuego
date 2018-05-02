namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class EquipoDesarrollo
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
		private string nombre;
			private string descripcion;
		#endregion

		#region "Constructores"
			public EquipoDesarrollo() { }

			public EquipoDesarrollo(string nombre, string descripcion)
			{
				this.nombre = nombre;
				this.descripcion = descripcion;
			}
		#endregion

		#region "Propieades"
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

			string sql = "INSERT INTO TBLEQUIPO VALUES('"+ Nombre +"', '"+ Descripcion +"')";

			int n = con.operaracion(sql, a);

			return n;
		}
		#endregion
	}
}