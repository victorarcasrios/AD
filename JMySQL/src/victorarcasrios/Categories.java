package victorarcasrios;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

import com.mysql.jdbc.PreparedStatement;

public class Categories {

	private static final String password = "sistemas";
	private static Connection connection = null;
	
	public static ArrayList<Object[]> listAll() {
		ArrayList <Object[]> resultArrayList = new ArrayList<Object[]>();		
		try{
			Statement statement = singleton().createStatement();
			ResultSet resultSet = statement.executeQuery("SELECT * FROM categoria");
			
			while(resultSet.next())
				resultArrayList.add(
						new Object[]{resultSet.getObject("id"), resultSet.getObject("nombre")});
			
			resultSet.close();
			statement.close();
		}catch(SQLException sqle){}
		return resultArrayList;
	}
	
	public static ArrayList<Object[]> list(String fieldName, Object value){		
		String select = String.format("SELECT * FROM categoria WHERE %s = ?", fieldName);
		ArrayList<Object[]>records = new ArrayList();
		
		try{
			PreparedStatement preparedStatement = 
					(PreparedStatement) singleton().prepareStatement(select);
			//ERROR
			System.out.println(preparedStatement.toString());
			//
			preparedStatement.setObject(1, value);
			ResultSet resultSet = preparedStatement.executeQuery();
			
			if(!resultSet.wasNull())
				records = null;
			else{
				resultSet.next();
				records.add(new Object[]{
						resultSet.getObject("id"), resultSet.getObject("nombre")});
			}
			
			resultSet.close();
			preparedStatement.close();
				
		}catch(SQLException sqle){sqle.printStackTrace();}
		return records;
	}
	
	public static void insert(String name) {
		String insert = "INSERT INTO categoria VALUES(NULL, ?)";
		try{
			PreparedStatement statement = (PreparedStatement) singleton().prepareStatement(insert);
			statement.setString(1, name);
			statement.executeUpdate();
		}catch(SQLException sqle){
			sqle.printStackTrace();
		}
	}
	
	private static Connection singleton(){
		if(connection == null)
			openConnection();
		return connection;
	}
	
	private static void openConnection(){
		try {
			 connection = DriverManager.getConnection(
				String.format("jdbc:mysql://localhost/dbprueba?user=root&password=%s",password));
		} catch (SQLException e) {
			System.out.println("ERROR: No se pudo abrir la conexión con la DB");
			e.printStackTrace();
		}
	}	
	
	private static void closeConnection() throws SQLException{connection.close();}

}
