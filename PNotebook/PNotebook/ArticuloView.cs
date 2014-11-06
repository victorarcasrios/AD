using Gtk;
using System;
using System.Collections.Generic;
using PNotebook;

namespace PNotebook
{
	public class ArticuloView : TreeView
	{
		public ArticuloView ()
		{
			AppendColumn ("id", new CellRendererText (), "text", 0);
			AppendColumn ("nombre", new CellRendererText (), "text", 1);			
			AppendColumn ("categoria", new CellRendererText (), "text", 2);
			AppendColumn ("precio", new CellRendererText (), "text", 3);

			Model = new ListStore (typeof(long), typeof(string), typeof(string), typeof(double));

			refreshContent ();

			Visible = true;
		}

		public void createRecord(){
			NewArticleWindow window = new NewArticleWindow ();
			window.ShowAll ();
			window.Destroyed += delegate {
				refreshContent ();
			};
		}

		public void refreshContent(){
			((ListStore)Model).Clear ();

			List<object[]> articulos = Articulos.listAll ();

			foreach (object[] articulo in articulos) {
				((ListStore)Model).AppendValues (Convert.ToInt64(articulo [0]), articulo [1], articulo[2], Convert.ToDouble(articulo[3]));
			}
		}

		public void deleteRecord(){

		}
	}
}

