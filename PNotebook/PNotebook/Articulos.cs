using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using PNotebook;

namespace PNotebook
{
	public class Articulos
	{
		private const string TABLE = "articulo";

		public Articulos (){}
	
		public static List<Object[]> listAll(){
			List<Object[]> list = new List<Object[]> ();

			MySqlCommand select = Singleton.Instance.CreateCommand();
			select.CommandText = String.Format ("SELECT a.id, a.nombre, c.nombre categoria, a.precio FROM {0} a, categoria c WHERE a.categoria=c.id", TABLE);
			MySqlDataReader reader = select.ExecuteReader ();
			while (reader.Read()) {
				list.Add (new Object[] { reader[0], reader[1], reader[2], reader[3] });
			}
			Singleton.Instance.Close ();
			return list;
		}
	}

}

