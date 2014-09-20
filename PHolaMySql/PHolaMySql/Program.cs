using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{

		private const string DB_PASSWORD = "";
		private const string DB_NAME = "dbprueba";
		private const string TABLE = "categoria";

		public static void Main (string[] args)
		{
			string input, output;
			int opcion = -1;

			MySqlConnection con = getDBConnection ();
			if (con == null)
				return;

			while (opcion != 0) {
				output = "";
				showMenu ();
				input = Console.ReadLine ();
				opcion = Convert.ToInt32 (input);
				switch (opcion) {
				
				case 0:
					output = "Cerrando... Hasta otra";
					break;
				
				case 1:
					// Insertamos valores de manera segura
					Console.WriteLine("Introduce el nombre a registrar:\t");
					output = safeInsert (con, Console.ReadLine());
					break;

				case 2:
					output = showSearchRegistro(con, 1);
					break;

				case 3:
					output = showSearchRegistro(con, 2);
					break;
				
				case 4:
					output = showSearchRegistro (con);
					break;

				case 5:
					// Listamos la tabla al completo
					output = listCategoria (con);
					break;
				}
				// Mostramos el resultado
				Console.WriteLine ("{0}\n", output);
			}

			// Cerramos las conexion a la DB
			con.Close ();
		}

		/*
		 * Gestiona la busqueda de un registro
		 * @param after 1 para actualizar despues de encontrar, 2 para eliminar despues de encontrar 
		 **/
		private static string showSearchRegistro(MySqlConnection con, int after = 0){
			int id = 0;
			char intentar = 'y';
			string output = "", campoBusqueda;

			// Target busqueda
			Console.WriteLine ("Buscar registro por id(1) o por nombre(2)?");
			int opcion = Convert.ToInt32(Console.ReadLine ());
			campoBusqueda = (opcion == 1)? "id" : "nombre";

			// Busqueda
			while (id == 0 && intentar == 'y') {
				// Valor busqueda
				Console.WriteLine ("Introduce el {0} a buscar:\t", campoBusqueda);
				string valor = Console.ReadLine ();
				id = getIdForRegistro (con, opcion, valor);

				if (id == 0) {
					Console.WriteLine ("ERROR: Registro no encontrado. Probar de nuevo? (y/n)");
					intentar = Convert.ToChar (Console.ReadLine ());
				}
			}
			// Detener
			if (id == 0)
				output = "Búsqueda detenida por el usuario";
			else { // Encontrado
				printRegistro (con, id);
				if (after != 0) // Hacer algo más
					output = doWithRegistro (con, id, after);
			}
			return output;
		}

		/*
		 * Devuelve el id del registro que tiene el valor @valor en la columna @field, o si no lo encuentra devuelve 0
		 * @param field 1 -> id, 2 -> nombre
		 **/
		private static int getIdForRegistro(MySqlConnection con, int field, string valor){
			object devuelto;
			MySqlCommand select = con.CreateCommand ();
			string campo = (field == 1)? "id" : "nombre";
			select.CommandText = "SELECT id FROM categoria WHERE " + campo + " = @valor";

			if(field == 1)
				select.Parameters.Add("@valor", MySqlDbType.Int32);
			else
				select.Parameters.Add("@valor", MySqlDbType.VarString);
				
			select.Parameters["@valor"].Value = valor;

			devuelto = select.ExecuteScalar();
			return (devuelto != null) ? Convert.ToInt32(devuelto) : 0;
		}

		// Imprime por pantalla el registro con el id @id
		private static void printRegistro(MySqlConnection con, int id){
			MySqlCommand select = con.CreateCommand ();
			select.CommandText = "SELECT * FROM " +TABLE+ " WHERE id = (@id)";
			select.Parameters.Add("@id", MySqlDbType.Int32);
			select.Parameters["@id"].Value = id;

			MySqlDataReader reader = select.ExecuteReader();
			while (reader.Read ()) {
				Console.Write("\nID\tNOMBRE\n{0}\t{1}\n", reader[0], reader[1]);
			}
			reader.Close ();
		}

		/*
		 * Para el registro con id @id hace lo siguiente:
		 * @param opcion es 1 -> actualizar; 2 -> borrar
		 **/
		private static string doWithRegistro(MySqlConnection con, int id, int opcion){
			char borrar = 'n';
			if (opcion == 1)
				return showUpdateRegistro (con, id);
			else
			{
				Console.WriteLine("Seguro que quieres eliminar el registro con id {0}?(y/N)", id);
				borrar = Convert.ToChar(Console.ReadLine ());
				if(borrar == 'y'){
					removeRegistro(con, id);
					return "Registro borrado satisfactoriamente";
				}else
					return "Borrado cancelado por el usuario";
			}
		}

		// Si encuentra el registro lo elimina y devuelve 1, de lo contrario devuelve 0
		private static void removeRegistro (MySqlConnection con, int id){
			MySqlCommand delete = con.CreateCommand ();
			delete.CommandText = "DELETE FROM " +TABLE+ " WHERE id = @id";
			delete.Parameters.Add ("@id", MySqlDbType.Int32);
			delete.Parameters ["@id"].Value = id;
			delete.ExecuteNonQuery ();
		}

		// Gestiona la llamada a updateRegistro
		private static string showUpdateRegistro(MySqlConnection con, int id){
			return "CACA";
		}

		private static int updateRegistro (MySqlConnection con, int id){
			return 0;
		}


		// Muestra el menu
		private static void showMenu(){
			string menu = "\nMenu:\n0. Salir\n1. Nuevo\n2. Modificar\n3. Eliminar\n4. Buscar un registo\n5. Listar todos los registros\nElige una opción:\t";
			Console.Write (menu);
		}

		// Devuelve una conexion válida o en su defecto, devuelve null
		private static MySqlConnection getDBConnection(){
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
		
		// Inserta un registro de manera segura
		private static string safeInsert (MySqlConnection con, String value){
			MySqlCommand insert = con.CreateCommand();
			insert.CommandText = "INSERT INTO categoria (nombre) VALUES (@nombre)";
			insert.Parameters.Add ("@nombre", MySqlDbType.VarString);
			insert.Parameters ["@nombre"].Value = value;
			insert.ExecuteNonQuery ();
			return "Registro insertado";
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
