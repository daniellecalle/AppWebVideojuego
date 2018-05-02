using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebVideoJuego.Models
{
	public class TareaEstado
	{
		#region "Atributos"
			private int idTarea;
			private int idEstado;
			private string fecha;
			private string hora;
			private string color;
		#endregion

		#region "Constructor"
			public TareaEstado() { }

			public TareaEstado(int idTarea, int idEstado, string fecha, string hora, string color)
			{
				this.idTarea = idTarea;
				this.idEstado = idEstado;
				this.fecha = fecha;
				this.hora = hora;
				this.color = color;
			}
		#endregion

		#region "Propiedades"
			public int IDTarea
			{
				get { return idTarea; }
				set { idTarea = value; }
			}

			public int IDEstado
			{
				get { return idEstado; }
				set { idEstado = value; }
			}

			public string Fecha
			{
				get { return fecha; }
				set { fecha = value; }
			}

			public string Hora
			{
				get { return hora; }
				set { hora = value; }
			}

			public string Color
			{
				get { return color; }
				set { color = value; }
			}
		#endregion

		#region "Metodos Publicos"
			
		#endregion

	}
}