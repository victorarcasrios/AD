using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string input;
			int opcion = -1;
			MySqlConnection con = getDBConnection ();
			if (con == null)
				return;

			while (opcion != 0) {
				showMenu ();
				input = Console.ReadLine ();
				opcion = Convert.ToInt32 (input);
				switch (opcion) {
				
				case 0:
					Console.WriteLine ("Cerrando... Hasta otra");
					break;
				
				case 1:
					// Insertamos valores de manera segura
					Console.WriteLine("Introduce el nombre a registrar:\t");
					safeInsert (con, Console.ReadLine());
					break;

				case 2:
					showUpdateRegistro();
					break;

				case 3:
					showRemoveRegistro();
					break;
				
				case 4:
					listCategoria();
					break;
				}
			}

			// Listamos la tabla al completo
			string salida = listCategoria (con);

			// Mostramos el resultado
			Console.WriteLine (salida);

			// Cerramos las conexion a la DB
			con.Close ();
		}

		private static void showRemoveRegistro(){
			Console.WriteLine ("Buscar registro por id(1) o por nombre(2)?");
			int exito = removeRegistro(Convert.ToInt32(Console.ReadLine()));
			if (exito)
				Console.WriteLine ("Exito al eliminar registro");
			else
				Console.WriteLine ("ERROR: El registro no pudo ser eliminado. Puede que no exista");
		}

		// Muestra el menu
		private static void showMenu(){
			string menu = "\nMenu:\n0. Salir\n1. Nuevo\n2. Modificar\n3. Eliminar\n4. Ver\nElige una opción:\t";
			Console.Write (menu);
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
		
		// Inserta un registro de manera segura
		private static void safeInsert (MySqlConnection con, String value){
			MySqlCommand insert = con.CreateCommand();
			insert.CommandText = "INSERT INTO categoria (nombre) VALUES (@nombre)";
			insert.Parameters.Add ("@nombre", MySqlDbType.VarString);
			insert.Parameters ["@nombre"].Value = value;
			insert.ExecuteNonQuery ();
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
			reader.Close ();
			return salida;
		}


	}
}
