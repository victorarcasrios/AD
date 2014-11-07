using System;
using Gtk;
using System.Collections.Generic;
using PNotebook;

public partial class MainWindow: Gtk.Window
{

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		addAction.Sensitive = refreshAction.Sensitive = editAction.Sensitive = deleteAction.Sensitive = false;

		CategoriasAction.Activated += delegate {
			CategoriaView view = new CategoriaView();
			newPage ("Categorías", view);

			view.Selection.Changed += delegate {
				bool hasSelected = view.Selection.CountSelectedRows() > 0;
				editAction.Sensitive = deleteAction.Sensitive = hasSelected;
			};
		};

		ArtculosAction.Activated += delegate {
			ArticuloView view = new ArticuloView();
			newPage("Artículos", view);

			view.Selection.Changed += delegate {
				bool hasSelected = view.Selection.CountSelectedRows() > 0;
				editAction.Sensitive = deleteAction.Sensitive = hasSelected;
			};
		};

		myNotebook.PageAdded += togglePageButtons;
		myNotebook.PageRemoved += delegate {
			bool hasSelected = false;

			if(myNotebook.NPages > 0){
				hasSelected = ((TreeView)myNotebook.CurrentPageWidget).Selection.CountSelectedRows () > 0;
			}
			editAction.Sensitive = deleteAction.Sensitive = hasSelected;
			togglePageButtons ();
		};

		addAction.Activated += delegate {
			TreeView view = (TreeView)myNotebook.CurrentPageWidget;
			if( view.GetType() == typeof(CategoriaView))
				((CategoriaView)view).createRecord();
			else if(view.GetType() == typeof(ArticuloView))
				((ArticuloView)view).createRecord();
		};

		refreshAction.Activated += delegate {
			TreeView view = (TreeView)myNotebook.CurrentPageWidget;
			if( view.GetType() == typeof(CategoriaView))
				((CategoriaView)view).refreshContent();
			else if(view.GetType() == typeof(ArticuloView))
				((ArticuloView)view).refreshContent();
		};

		deleteAction.Activated += delegate {
			TreeView view = (TreeView)myNotebook.CurrentPageWidget;
			if( view.GetType() == typeof(CategoriaView))
				((CategoriaView)view).deleteRecord();
			else if(view.GetType() == typeof(ArticuloView))
				((ArticuloView)view).deleteRecord();
		};
	}

	private void togglePageButtons(object sender, EventArgs a){
		togglePageButtons ();
	}

	private void togglePageButtons(){
		bool hasPage = myNotebook.NPages > 0;
		addAction.Sensitive = refreshAction.Sensitive = hasPage;
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
