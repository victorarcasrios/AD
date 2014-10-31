using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PNotebook;

namespace PNotebook
{
	public class Categorias
	{
		private const string TABLE = "categoria";

		public Categorias (){}

		public static List<Object[]> listAll(){
			List<Object[]> list = new List<Object[]> ();

			MySqlCommand select = Singleton.Instance.CreateCommand();
			select.CommandText = String.Format ("SELECT * FROM {0}", TABLE);
			MySqlDataReader reader = select.ExecuteReader ();
			while (reader.Read())
				list.Add (new Object[] { reader[0], reader[1] });
			Singleton.Instance.Close ();
			return list;
		}
	}
}

