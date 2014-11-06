using System;

namespace PNotebook
{
	public partial class NewArticleWindow : Gtk.Window
	{
		public NewArticleWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

		}
	}
}

