using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace PCategoria
{
	public class Categoria
	{
		// CONSTANTES de configuracion de la conexion a la DB
		private const string DB_PASSWORD = "sistemas";
		private const string DB_NAME = "dbprueba";
		private const string TABLE = "categoria";
		// Conexion con la DB
		private static MySqlConnection con = null;

		public Categoria ()
		{
			con = getDbConnection ();
		}

		// Devuelve una lista con todos los registros de la tabla como arrays de objetos
		public static List<Object[]> listAll(){
			List<Object[]> lista = new List<Object[]>();

			MySqlCommand select = singleton ().CreateCommand ();
			select.CommandText = "SELECT * FROM " + TABLE;
			MySqlDataReader reader = select.ExecuteReader ();
			while (reader.Read())
				lista.Add (new Object[]{reader[0], reader[1]});
			closeDbConnection ();
			return lista;
		}

		public static int insert(string nombre){
			MySqlCommand insert = singleton().CreateCommand();
			insert.CommandText = "INSERT INTO categoria (nombre) VALUES (@nombre)";
			insert.Parameters.Add ("@nombre", MySqlDbType.VarString);
			insert.Parameters ["@nombre"].Value = nombre;
			return insert.ExecuteNonQuery ();
		}

		// Devuelve una conexion a la DB (si ya hay una instancia devuelve esa, y si no, la crea)
		private static MySqlConnection singleton(){
			if (con != null)
				return con;
			else
				return getDbConnection ();
		}

		// Si existe una instancia de DB, la cierra
		private static void closeDbConnection(){
			if(con != null)
				con.Close();
		}

		// Crea y devuelve una conexion a la DB
		private static MySqlConnection getDbConnection(){
			string conString = @"server=localhost;userid=root;password="+DB_PASSWORD+";database="+DB_NAME;
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

