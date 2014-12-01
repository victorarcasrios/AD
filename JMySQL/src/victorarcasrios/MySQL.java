package victorarcasrios;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class MySQL {

	public static void main(String[] args) throws ClassNotFoundException, SQLException {
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
			
		Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("SELECT * FROM categoria");
		
		while(resultSet.next())
			System.out.printf("id = %d, nombre = %s\n",
					resultSet.getObject("id"), resultSet.getObject("nombre"));
		
		resultSet.close();
		statement.close();
		connection.close();
	}
}
