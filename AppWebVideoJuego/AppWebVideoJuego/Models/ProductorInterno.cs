namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	public class ProductorInterno : Persona
	{
		#region "Atributos"
			public string cargo;
		#endregion

		#region "Constructores"
			public ProductorInterno() { }

			public ProductorInterno(string cargo, string cedula, string nombre, string apellido,
				string telefono, string direccion) : base(cedula, nombre, direccion,apellido, telefono)
			{
				this.cargo = cargo;
			}
		#endregion

		#region "Propiedades"
			public string Cargo { get; set; }
		#endregion
	}
}