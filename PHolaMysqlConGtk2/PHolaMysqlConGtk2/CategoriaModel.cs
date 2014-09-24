using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PHolaMysqlConGtk2
{
	public class CategoriaModel
	{
		// CONSTANTES
		private const string DB_PASSWORD = "sistemas";
		private const string DB_NAME = "dbprueba";
		private const string TABLE = "categoria";

		private static MySqlConnection con;

		public CategoriaModel ()
		{
			initConnection ();
		}

		private void initConnection()
		{
			string conConfig = @"server=localhost;userid=root;password="+DB_PASSWORD+";database="+DB_NAME;

			try{
				con = new MySqlConnection (conConfig);
				con.Open ();
			}catch(MySqlException ex){
				Console.WriteLine("ERROR: Error de conexion con la base de datos");
				Console.WriteLine ("Detalle del error: {0}", ex.ToString());
			}
		}

		public List<object> list()
		{
			List<object> list;

			MySqlCommand select = con.CreateCommand();
			select.CommandText = "SELECT id, nombre FROM categoria";
			MySqlDataReader reader = select.ExecuteReader ();

			while (reader.Read())
			list.Add(new object[] {reader[0], reader[1]});
			reader.Close ();

			return list;
		}
	}
}

