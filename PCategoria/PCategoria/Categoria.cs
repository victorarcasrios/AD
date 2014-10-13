using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace PCategoria
{
	public class Categoria
	{
		private const string TABLE = "categoria";

		public Categoria ()
		{
		}

		// Devuelve una lista con todos los registros de la tabla como arrays de objetos
		public static List<Object[]> listAll(){
			List<Object[]> lista = new List<Object[]>();

			MySqlCommand select = Db.Instance.CreateCommand ();
			select.CommandText = "SELECT * FROM " + TABLE;
			MySqlDataReader reader = select.ExecuteReader ();
			while (reader.Read())
				lista.Add (new Object[]{reader[0], reader[1]});
			Db.Instance.Close();
			return lista;
		}

		public static int insert(string nombre){
			MySqlCommand insert = Db.Instance.CreateCommand();
			insert.CommandText = "INSERT INTO categoria (nombre) VALUES (@nombre)";
			insert.Parameters.Add ("@nombre", MySqlDbType.VarString);
			insert.Parameters ["@nombre"].Value = nombre;
			return insert.ExecuteNonQuery ();
		}

		public static void removeRegistro (int id){
			MySqlCommand delete = Db.Instance.CreateCommand ();
			delete.CommandText = "DELETE FROM " +TABLE+ " WHERE id = @id";
			delete.Parameters.Add ("@id", MySqlDbType.Int32);
			delete.Parameters ["@id"].Value = id;
			delete.ExecuteNonQuery ();
		}

		public static String getNombre(int id){
			MySqlCommand select = Db.Instance.CreateCommand ();
			select.CommandText = "SELECT nombre FROM " + TABLE + " WHERE id = @id";
			select.Parameters.Add ("@id", MySqlDbType.Int32);
			select.Parameters ["@id"].Value = id;
			return (string)select.ExecuteScalar ();
		}

		public static int updateName(int id, string name){
			MySqlCommand update = Db.Instance.CreateCommand ();
			update.CommandText = "UPDATE " + TABLE + " SET nombre = @name WHERE id = @id";
			update.Parameters.Add ("@name", MySqlDbType.String);
			update.Parameters.Add ("@id", MySqlDbType.Int32);
			update.Parameters ["@name"].Value = name;
			update.Parameters ["@id"].Value = id;
			return update.ExecuteNonQuery ();
		}
	}
}

