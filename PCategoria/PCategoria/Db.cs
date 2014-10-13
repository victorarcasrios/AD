using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PCategoria
{
	public class Db
	{
		// CONSTANTES de configuracion de la conexion a la DB
		private const string DB_PASSWORD = "sistemas";
		private const string DB_NAME = "dbprueba";

		private static MySqlConnection instance = null;

		private Db ()
		{
		}

		public static MySqlConnection Instance{
			get{ return (instance != null && instance.State == ConnectionState.Open ) ? instance : getNewConnection(); }
		}

		private static MySqlConnection getNewConnection(){
			string conString = @"server=localhost;userid=root;password="+DB_PASSWORD+";database="+DB_NAME;

			try{
				instance = new MySqlConnection(conString);
				instance.Open();
			}
			catch(MySqlException ex){
				Console.WriteLine("ERROR: Error de conexion con la base de datos");
				Console.WriteLine ("Detalle del error: {0}", ex.ToString());
			}
			return instance;
		}
	}
}

