using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private ListStore listStore;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);

		listStore = new ListStore (typeof(string), typeof(string));

		treeView.Model = listStore;

		printCategoria ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		if (PCategoria.Categoria.insert (Convert.ToString(DateTime.Now)) > 0) 
			printCategoria ();
		else
			Console.WriteLine ("Error al insertar");
	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		printCategoria ();
	}

	// Imprime todos los registros de la tabla categoria
	private void printCategoria(){
		listStore.Clear ();
		List<object[]> registros  = PCategoria.Categoria.listAll ();
		foreach (object[] arrFila in registros)
			listStore.AppendValues (Convert.ToString(arrFila[0]), arrFila[1]);
	}
}
