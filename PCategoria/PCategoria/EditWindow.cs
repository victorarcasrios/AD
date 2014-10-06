using System;

namespace PCategoria
{
	public partial class EditWindow : Gtk.Window
	{
		public EditWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		public EditWindow () :
			this()
		{

		}
	}
}

