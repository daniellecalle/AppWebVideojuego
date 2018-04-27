namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class Estado
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
		private string nombre;
			private string color;
			private string descripcion;
		#endregion

		#region "Constructores"
			public Estado() { }

			public Estado(string nombre, string color, string descripcion)
			{
				this.nombre = nombre;
				this.color = color;
				this.descripcion = descripcion;
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

				string sql = "INSERT INTO TBLESTADO VALUES ('" + GetNombre() + "', '" + GetColor()
					+ "', '" + GetDescripcion() + "')";

				int n = con.operaracion(sql, a);

				return n;
			}

		#endregion
	}
}