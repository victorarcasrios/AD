using System;
using PCategoria;

namespace PCategoria
{
	public partial class EditWindow : Gtk.Window
	{
		private int id;
		private string nombre;

		public EditWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		public EditWindow (int id) :
			this()
		{
			this.Title = String.Format("Editar registro con id {0}", id);
			this.id = id;
			this.nombre = Categoria.getNombre (id);
			setActualData (id, nombre);
		}

		private void setActualData(int id, string nombre){			
			actualData.LabelProp = String.Format("ID#{0} NOMBRE: {1}\n", id, nombre);
		}

		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
			string newName = newNameInput.Text;
			if( Categoria.updateName (id, newName) > 0 )
				setActualData (id, newName);
		}
	}
}

