using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	// TODO show only string values in combobox, not their ids
	public MainWindow (Dictionary<int, string> values, int defaultIndex): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		TreeIter defaultIter = new TreeIter();

		ListStore store = new ListStore (typeof(int), typeof(string));
		foreach (KeyValuePair<int, string> pair in values) {
			TreeIter currentIter = store.AppendValues (pair.Key, pair.Value);
			if (pair.Key == defaultIndex)
				defaultIter = currentIter;
		}

		CellRendererText rendererText = new CellRendererText ();
		ComboBox.PackStart (rendererText, false);
		ComboBox.SetAttributes (rendererText, "text", 1);

		ComboBox.Model = store;
		ComboBox.SetActiveIter (defaultIter);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
