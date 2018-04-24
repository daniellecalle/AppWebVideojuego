namespace AppWebVideoJuego.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Web;

	public class Persona
	{
		#region "Atributos"
			[Key]
			private string cedula;
			private string nombre;
			private string direccion;
			private string apellido;
			private string telefono;
		#endregion

		#region "Constructores"
			public Persona() { }

			public Persona(string cedula, string nombre, string direccion, string apellido, string telefono)
			{
				this.cedula = cedula;
				this.nombre = nombre;
				this.direccion = direccion;
				this.apellido = apellido;
				this.telefono = telefono;
			}
		#endregion

		#region "Metodos Publicos"

		public string GetCedula()
		{
			return cedula;
		}

		public void SetCedula(string cedula)
		{
			this.cedula = cedula;
		}

		public string GetNombre()
		{
			return nombre;
		}

		public void SetNombre(string nombre)
		{
			this.nombre = nombre;
		}

		public string GetDireccion()
		{
			return direccion;
		}

		public void SetDireccion(string direccion)
		{
			this.direccion = direccion;
		}

		public string GetApellido()
		{
			return apellido;
		}

		public void SetApellido(string apellido)
		{
			this.apellido = apellido;
		}

		public string GetTelefono()
		{
			return telefono;
		}

		public void SetTelefono(string telefono)
		{
			this.telefono = telefono;
		}

		public bool Validar1()
		{
			if (!String.IsNullOrEmpty(cedula) || !String.IsNullOrEmpty(nombre) || !String.IsNullOrEmpty(apellido)
				|| !String.IsNullOrEmpty(telefono) || !String.IsNullOrEmpty(direccion))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion


	}
}