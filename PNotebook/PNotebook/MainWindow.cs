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
			CategoriaView view = new CategoriaView();
			newPage ("Categorías", view);
		};

		ArtculosAction.Activated += delegate {
			ArticuloView view = new ArticuloView();
			newPage("Artículos", view);
		};

		refreshAction.Activated += delegate {
			TreeView view = (TreeView)myNotebook.CurrentPageWidget;
			Console.WriteLine(view.GetType());
			if( view.GetType() == typeof(CategoriaView))
				((CategoriaView)view).refreshContent();
			else if(view.GetType() == typeof(ArticuloView))
				((ArticuloView)view).refreshContent();
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
