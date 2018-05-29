using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppWebVideoJuego.Models
{
	public class Trazabilidad
	{
		Conexion con = new Conexion();
		SqlConnection a;

		#region "Atributos"
			private Tarea tarea;
			private Estado estado;
			private String fecha;
			private String hora;
		#endregion

		#region "Constructor"
			public Trazabilidad() { }

			public Trazabilidad(Tarea tarea, Estado estado, string fecha, string hora, string color)
			{
				this.tarea = tarea;
				this.estado = estado;
				this.fecha = fecha;
				this.Hora = hora;
			}
		#endregion

		#region "Propiedades"
			public Tarea Tarea 
			{
				get { return tarea; }
				set { tarea = value; }
			}

			public Estado Estado
			{
				get { return estado; }
				set { estado = value; }
			}

			public String Fecha
			{
				get { return fecha; }
				set { fecha = value; }
			}

			public String Hora
			{
				get { return hora; }
				set { hora = value; }
			}

		#endregion

		#region "Metodos Publicos"

		public List<Tarea> listaTareas()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT T.ID, T.NOMBRE FROM TAREA T ";

			SqlDataReader leer = con.Consulta(sql, a);

			List<Tarea> listaT = new List<Tarea>();

			while (leer.Read())
			{
				tarea = new Tarea();
				tarea.SetId(Convert.ToInt32(leer["ID"]));
				tarea.SetNombre(Convert.ToString(leer["NOMBRE"]));
				listaT.Add(tarea);
			}

			return listaT;
		}

		public List<Estado> listaEstado()
		{
			try
			{
				a = con.Conectar();
			} 
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT E.ID, E.NOMBRE FROM ESTADO E";
			SqlDataReader leer = con.Consulta(sql, a);

			List<Estado> listaE = new List<Estado>();

			while (leer.Read())
			{
				estado = new Estado();
				estado.SetId(Convert.ToInt32(leer["ID"]));
				estado.SetNombre(Convert.ToString(leer["NOMBRE"]));
				listaE.Add(estado);
			}

			return listaE;
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

			string sql = "INSERT INTO TRAZABILIDAD VALUES ('"+tarea.GetId()+"', '"+estado.GetId()
				+"', '"+Fecha+"', '"+Hora+"')";

			int num = con.operaracion(sql, a);

			return num;
		}

		public int Actualizar()
		{
			try
			{ 
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "UPDATE TRAZABILIDAD SET IDTAREA='"+tarea.GetId()+"', IDESTADO='"+estado.GetId()
				+"', FECHA='"+Fecha+"', HORA='"+Hora
				+"' WHERE IDTAREA='"+tarea.GetId()+"' AND IDESTADO='"+estado.GetId()+"'";
			int num = con.operaracion(sql, a);

			return num;
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

			string sql = "DELETE FROM TRAZABILIDAD " +
				"WHERE IDTAREA='" + tarea.GetId() + "' AND IDESTADO='" + estado.GetId() + "'";

			int num = con.operaracion(sql, a);

			return num;
		}

		public List<Trazabilidad> listarDatos()
		{
			try
			{
				a = con.Conectar();
			}
			catch (Exception)
			{
				throw;
			}

			string sql = "SELECT * FROM TRAZABILIDAD";

			SqlDataReader leer = con.Consulta(sql, a);

			List<Trazabilidad> lista = new List<Trazabilidad>();

			while (leer.Read())
			{
				Trazabilidad t = new Trazabilidad();
				Tarea ta = new Tarea();
				Estado est = new Estado();
				ta.SetId(Convert.ToInt32(leer["IDTAREA"]));
				est.SetId(Convert.ToInt32(leer["IDESTADO"]));
				t.Tarea = ta;
				t.Estado = est;
				t.Fecha = Convert.ToString(leer["FECHA"]);
				t.Hora = Convert.ToString(leer["HORA"]);
				lista.Add(t);
			}

			return lista;
		}

		public bool Validar()
		{
			return (!String.IsNullOrEmpty(estado.GetNombre()) || !String.IsNullOrEmpty(tarea.GetNombre())
				||!String.IsNullOrEmpty(fecha)||!String.IsNullOrEmpty(hora));

		}
		#endregion

	}
}