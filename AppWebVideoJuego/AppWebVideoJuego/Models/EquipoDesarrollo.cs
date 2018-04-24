namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	public class EquipoDesarrollo
	{
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

		#region "Metodos Publicos"
			public string GetNombre()
			{
				return nombre;
			}

			public void SetNombre(string nombre)
			{
				this.nombre = nombre;
			}
		#endregion
	}
}