using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnAceptarClicked (object sender, EventArgs e)
	{
		sayHi ();
	}

	private void sayHi(){
		hello.LabelProp = String.Format("Hola {0}", inputName.Text);
	}

	protected void OnActionTestActivated (object sender, EventArgs e)
	{
		Console.WriteLine ("Has activado la acción actionPrueba");
	}
}
