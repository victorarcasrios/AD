using System;

namespace PNotebook
{
	public partial class NewCategoryWindow : Gtk.Window
	{
		public NewCategoryWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			createCategoryButton.Clicked += delegate {
				if (categoryNameEntry.Text.Length > 0) {
					string name = categoryNameEntry.Text;
					if (Categorias.nameExists (name))
						Console.WriteLine ("ERROR: Ya existe una categoria con el nombre {0}", name);
					else {
						Categorias.insert (name);
						Destroy ();
					}
				}
			};
		}
	}
}

