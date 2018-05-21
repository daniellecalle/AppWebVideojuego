namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Web;

	public class Conexion
	{
		#region "Constructor"
		public Conexion() { }
		#endregion

		#region "Metodos Publicos"

		//Metodo Conectar. Este metodo Retorna un dato tipo sqlConnection
		//Instaciamos la cadena de conexion pasando unos parametros y Abrimos la conexion
		public SqlConnection Conectar()
		{
			SqlConnection conectar = new SqlConnection("Data Source=.;" +
					"Initial Catalog=VIDEOJUEGO2;Integrated Security=SSPI;");

			try
			{
				conectar.Open();//AQUI!!! con la referencia ala clase SqlConnection al objeto conectar instanciado, 
								//abrimos la conexion.
				return conectar;//Retornado el objeto 
			}
			catch (SqlException e)
			{
				return null;//RETORNA!! null si en el proceso ocurrio un error en la conexion. 
				throw e;
			}
		}

		//Metodo para cerrar al conexion que recibe como paremetro un objeto de tipo SqlConnection
		public void CerrarConexion(SqlConnection conectar)
		{
			try
			{
				conectar.Close();//Con el objeto referenciado. Cerramos la conexion.
			}
			catch (SqlException e)
			{
				throw e;
			}
		}

		//Metodo para ejecutar de las instrucciones delete, insert, update
		//las instrucciones SQL que retorna una cantidad de filas afectadas.
		public int operaracion(string conSQL, SqlConnection conector)
		{
			int num = 0;

			try
			{
				//variable comando tipo SqlCommand le pasamos el Query(puede ser insert, delete o update) 
				//Junto con el objeto conectar.
				SqlCommand comando = new SqlCommand(conSQL, conector);
				num = comando.ExecuteNonQuery();//Ejecutamos el comando
				return num;//Retorna el numero de filas afectadas.
			}
			catch (SqlException ex)
			{
				return num;
				throw ex;
			}
		}

		public SqlDataReader Consulta(string conSQL, SqlConnection conector)
		{
			try
			{
				SqlCommand comando = new SqlCommand(conSQL, conector);
				SqlDataReader datos = comando.ExecuteReader();
				return datos;
			}
			catch (SqlException e)
			{
				return null;
				throw e;
			}
		}

		#endregion


	}
}