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

		public static bool nameExists(string name){
			MySqlCommand select = Singleton.Instance.CreateCommand ();
			select.CommandText = String.Format ("SELECT id FROM {0} WHERE nombre = @name", TABLE);
			select.Parameters.Add ("@name", MySqlDbType.VarString);
			select.Parameters["@name"].Value = name;
			bool exists = select.ExecuteScalar() != null;
			Singleton.Instance.Close ();
			return exists;
		}

		public static void insert(string name){
			MySqlCommand insert = Singleton.Instance.CreateCommand ();
			insert.CommandText = String.Format ("INSERT INTO {0} VALUES(NULL, @name)", TABLE);
			insert.Parameters.Add ("@name", MySqlDbType.VarString);
			insert.Parameters ["@name"].Value = name;
			insert.ExecuteNonQuery ();
		}
	}
}

