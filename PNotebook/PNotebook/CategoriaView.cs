using Gtk;
using System;
using System.Collections.Generic;
using PNotebook;

namespace PNotebook
{
	public class CategoriaView : TreeView
	{
		public CategoriaView ()
		{
			AppendColumn ("id", new CellRendererText (), "text", 0);
			AppendColumn ("nombre", new CellRendererText (), "text", 1);

			Model = new ListStore (typeof(long), typeof(string));

			refreshContent ();

			Visible = true;
		}

		private void selectionChanged(object sender, EventArgs e){
			bool hasSelected = Selection.CountSelectedRows () > 0;
		}

		private void refreshContent(){
			((ListStore)Model).Clear ();

			List<object[]> categorias = Categorias.listAll ();

			foreach (object[] categoria in categorias) {
				((ListStore)Model).AppendValues (Convert.ToInt64 (categoria [0]), categoria [1]);
			}
		}
	}
}