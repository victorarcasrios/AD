using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection con = getDBConnection ();
			if (con == null)
				return;

			safeInsert (con, "" + DateTime.Now);

			string salida = listCategoria (con);

			// Mostramos el resultado
			Console.WriteLine (salida);

			// Cerramos las conexion a la DB
			con.Close ();
		}

		// Lista todos los registros de la tabla categoria
		private static string listCategoria(MySqlConnection con){
			MySqlCommand select = con.CreateCommand();
			select.CommandText = "SELECT nombre FROM categoria";
			MySqlDataReader reader = select.ExecuteReader ();

			string salida = "";
			int contador = 1;
			while (reader.Read())
				salida += "#" + (contador++) + " - " + reader.GetString(0) + "\n";
			return salida;
		}

		// Inserta un registro de manera segura
		private static void safeInsert (MySqlConnection con, String value){
			MySqlCommand insert = con.CreateCommand();
			insert.CommandText = "INSERT INTO categoria (nombre) VALUES (@nombre)";
			insert.Parameters.Add ("@nombre", MySqlDbType.VarString);
			insert.Parameters ["@nombre"].Value = value;
			insert.ExecuteNonQuery ();
		}

		// Devuelve una conexion válida o en su defecto, devuelve null
		private static MySqlConnection getDBConnection(){
			string conString = @"server=localhost;userid=root;password=sistemas;database=dbprueba";
			MySqlConnection con = null;

			try{
				con = new MySqlConnection(conString);
				con.Open();
			}
			catch(MySqlException ex){
				Console.WriteLine("ERROR: Error de conexion con la base de datos");
				Console.WriteLine ("Detalle del error: {0}", ex.ToString());
			}
			return con;
		}
	}
}
