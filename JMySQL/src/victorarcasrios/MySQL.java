package victorarcasrios;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Scanner;

import com.mysql.jdbc.PreparedStatement;

public class MySQL {

	private static Connection connection;
	
	public static void main(String[] args) throws ClassNotFoundException, SQLException {
		connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba?user=root&password=root");
		Scanner scanner = new Scanner(System.in);
		int option = 1;
		
		while(option != 0){
			displayMenu();
			option = scanner.nextInt();
			doOption(option);
		}
		
		connection.close();
	}
	
	public static void doOption(int option) throws SQLException{
		switch(option){
		case 1: displayAll();
		break;
		case 2: insertRecord(); displayAll();
		break;
		case 0: System.out.println("Hasta pronto");
		break;
		}
	}
	
	public static void displayMenu(){
		String string = "\nMENU\n1. Listar\n2. Insertar\n0. Cerrar\nElige:\t";
		System.out.println(string);
	}
	
	public static void displayAll() throws SQLException{
		ArrayList<Object[]>records = listAll();
		for( Object[] record : records){
			System.out.printf("ID = %d, Nombre = %s\n", record[0], record[1]);
		}
	}
	
	public static ArrayList<Object[]> listAll() throws SQLException{
		Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("SELECT * FROM categoria");
		ArrayList <Object[]> resultArrayList = new ArrayList<Object[]>();		
		
		while(resultSet.next())
			resultArrayList.add(
					new Object[]{resultSet.getObject("id"), resultSet.getObject("nombre")});
		
		resultSet.close();
		statement.close();
		return resultArrayList;
	}
	
	public static void insertRecord() throws SQLException{
		Scanner scanner = new Scanner(System.in);
		System.out.printf("\nNueva categoria\nNombre:\t");
		String name = scanner.nextLine();
		insert(name);
	}
	
	public static void insert(String name) throws SQLException{
		String insert = "INSERT INTO categoria VALUES(NULL, ?)";
		PreparedStatement statement = (PreparedStatement) connection.prepareStatement(insert);
		statement.setString(1, name);
		statement.executeUpdate();		
	}
}
