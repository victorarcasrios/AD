using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private ListStore listStore;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;

		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);

		listStore = new ListStore (typeof(string), typeof(string));

		treeView.Model = listStore;

		printCategoria ();

		treeView.Selection.Changed += delegate {
			deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
		};
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnAddActionActivated(object sender, EventArgs e){
		nameInput.Visible = !nameInput.Visible;
		AddButton.Visible = !AddButton.Visible;
	}

	protected void OnAddButtonClicked (object sender, EventArgs e)
	{
		if (PCategoria.Categoria.insert (nameInput.Text) > 0)
			printCategoria ();
		else
			Console.WriteLine ("Error al insertar valor en base de datos");
	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		printCategoria ();
	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);

		if(!confirm(String.Format("¿Quieres eliminar el registro con el id {0}?", id)))
			return;

		PCategoria.Categoria.removeRegistro (Convert.ToInt32(id));
		printCategoria ();
	}

	// Muestra un modal de confirmacion y devuelve true si la respuesta del usuario es yes o false si ha sido otra
	public bool confirm(String text){
		MessageDialog messageDialog = new MessageDialog(
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			text
			);		

		ResponseType response = (ResponseType)messageDialog.Run ();
		messageDialog.Destroy ();

		return response == ResponseType.Yes; 
	}

	// Imprime todos los registros de la tabla categoria
	private void printCategoria(){
		listStore.Clear ();
		List<object[]> registros  = PCategoria.Categoria.listAll ();
		foreach (object[] arrFila in registros)
			listStore.AppendValues (Convert.ToString(arrFila[0]), arrFila[1]);
	}
}
