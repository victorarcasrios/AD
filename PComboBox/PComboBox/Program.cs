using System;
using Gtk;
using System.Collections.Generic;

namespace PComboBox
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Dictionary<int, string> exampleValues = new Dictionary<int, string> (){
				{1, "Ejemplo1"},
				{45, "Ejemplo2"},
				{67, "Ejemplo3"}
			};
			Application.Init ();
			MainWindow win = new MainWindow (exampleValues, 45);
			win.Show ();
			Application.Run ();
		}
	}
}
