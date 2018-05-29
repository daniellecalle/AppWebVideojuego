namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class Cliente
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
		private string cedula;
		private string nombre;
		private string apellido;
		private string telefono;
		private string direccion;
		private string email;
		#endregion

		public string Cedula
		{
			get { return cedula; }
			set { cedula = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		public string Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}

		public string Direccion
		{
			get { return direccion; }
			set { direccion = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
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

			string sql = "INSERT INTO CLIENTE VALUES ('"+Cedula+"', '"+Nombre+"', '"+Apellido
				+"', '"+Telefono+"', '"+Direccion+"', '"+Email+"')";

			int n = con.operaracion(sql, a);

			return n;
		}

		public bool Validar()
		{
			if (!String.IsNullOrEmpty(cedula) || !String.IsNullOrEmpty(nombre) || !String.IsNullOrEmpty(apellido)
				|| !String.IsNullOrEmpty(telefono) || !String.IsNullOrEmpty(direccion) || !String.IsNullOrEmpty(email))
			{
				return true;
			}
			else
			{
				return false;
			}
		}


	}
}