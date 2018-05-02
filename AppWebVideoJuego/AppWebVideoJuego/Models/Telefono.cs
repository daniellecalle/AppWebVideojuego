using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebVideoJuego.Models
{
	public class Telefono
	{
		#region "Atributos"
			[Key]
			private int id;
			private string telefono;
		#endregion

		#region "Contructor"
			public Telefono() { }

			public Telefono(int id, string telefono)
			{
				this.id = id;
				this.telefono = telefono;
			}
		#endregion

		#region "Propiedades"
			public int ID
			{
				get { return id; }
				set { id = value; }
			}

			public string NumeroTelefono 
			{
				get { return telefono; }
				set { telefono = value; }
			}
		#endregion
	}
}