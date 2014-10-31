using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PNotebook
{
	public class Singleton
	{
		private const string DB_PASSWORD = "sistemas";
		private const string DB_NAME = "dbprueba";
		private static MySqlConnection instance = null;

		private Singleton (){}

		public static MySqlConnection Instance{
			get{
				if (instance != null) {
					if (instance.State != ConnectionState.Open)
						instance.Open ();
					return instance;
				}else {
					instance = getNewConnection ();
					return instance;
				}
			}
		}

		private static MySqlConnection getNewConnection(){
			String connectionString = @"server=localhost;userid=root;password="+DB_PASSWORD+";database="+DB_NAME;
			instance = new MySqlConnection (connectionString);
			instance.Open ();
			return instance;
		}
	}
}

