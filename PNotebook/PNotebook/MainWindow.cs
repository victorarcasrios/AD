using System;
using Gtk;
using System.Collections.Generic;
using PNotebook;

public partial class MainWindow: Gtk.Window
{


	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		CategoriasAction.Activated += delegate {
			newPage ("Categorías", new CategoriaView());
		};

		ArtculosAction.Activated += delegate {
			newPage("Artículos", new ArticuloView());	
		};
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	private void newPage(string label, TreeView treeView){
		HBox hbox = new HBox ();
		hbox.Add (new Label (label));
		Button button = new Button (new Image (Stock.Cancel, IconSize.Button));
		hbox.Add( button );
		hbox.ShowAll ();
		myNotebook.AppendPage ( treeView, hbox );

		button.Clicked += delegate {
			treeView.Destroy ();
		};
	}
}
