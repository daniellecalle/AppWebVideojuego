namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	public class VideoJuego
	{
		#region "Atributos"
			private string nombre;
			private string objetivo;
			private string tipoRecurso;
			private string nombreRecurso;
			private string publicoObjetivo;
			private double costo;
		#endregion

		#region "Constructores"
			public VideoJuego() { }

			public VideoJuego(string nombre, string objetivo, string tipoRecurso,
					string nombreRecurso, string publicoObjetivo, double costo)
			{
				this.nombre = nombre;
				this.objetivo = objetivo;
				this.tipoRecurso = tipoRecurso;
				this.nombreRecurso = nombreRecurso;
				this.publicoObjetivo = publicoObjetivo;
				this.costo = costo;
			}
		#endregion

		#region "Propiedades"
			public string Nombre { get; set; }
			public string Objetivo { get; set; }
			public string TipoRecurso { get; set; }
			public string NombreRecurso { get; set; }
			public string PublicoObjetivo { get; set; }
			public double Costo { get; set; }
		#endregion
	}
}