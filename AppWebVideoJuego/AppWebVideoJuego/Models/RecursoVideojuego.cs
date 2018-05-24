
namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Data.SqlClient;

	public class RecursoVideojuego
	{
		private int idVideojuego;
		private int numero;
		private String nombre;
		private String tipoRecurso;

		Conexion con = new Conexion();
		SqlConnection a;

		public String Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		} 

		public String TipoRecurso
		{
			get { return tipoRecurso; }
			set { tipoRecurso = value; }
		}

		public int IdVideoJuego
		{
			get { return idVideojuego; }
			set { idVideojuego = value; }
		}

		public int Numero
		{
			get { return numero; }
			set { numero = value; }
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

			string sql = "INSERT INTO RECURSO VALUES ('"+IdVideoJuego+"', '"+Numero
				+"', '"+Nombre+"', '"+TipoRecurso+"')";
			int n = con.operaracion(sql, a);

			return n;
		}

		public int Editar()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			string sql = "UPDATE RECURSO SET NOMBRE='"+Nombre+"', TIPO_RECURSO='"
				+TipoRecurso+"' WHERE IDVIDEOJUEGO="+IdVideoJuego+"AND NUMERO="+Numero;
			int n = con.operaracion(sql, a);

			return n;
		}


	}
}