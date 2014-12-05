package victorarcasrios;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

import com.mysql.jdbc.PreparedStatement;


public class MySQL {
	private static Scanner scanner;
	
	public static void main(String[] args) throws ClassNotFoundException {
		
		Map<Integer, Runnable>functionMap = new HashMap();
		functionMap.put(0, ()->{System.out.println("Hasta pronto");});
		functionMap.put(1, ()->{displayAll();});
		functionMap.put(2, ()->{insertRecord(); displayAll();});
		functionMap.put(3, ()->{searchRecord();});
		scanner = new Scanner(System.in);
		int option = 1;
		
		while(option != 0){
			displayMenu();
			option = scanner.nextInt();
			scanner.nextLine();
			functionMap.get(option).run();
		}
		
	}
	
	public static void displayMenu(){
		String string = "\nMENU\n1. Listar\n2. Insertar\n3. Buscar\n0. Cerrar\nElige:\t";
		System.out.println(string);
	}
	
	public static void displayAll() {
		ArrayList<Object[]>records = Categories.listAll();
		for( Object[] record : records){
			System.out.printf("ID = %d, Nombre = %s\n", record[0], record[1]);
		}
	}
	
	public static void insertRecord() {
		System.out.printf("\nNueva categoria\nNombre:\t");
		String name = scanner.nextLine();
		Categories.insert(name);
	}
	
	public static void searchRecord(){
		System.out.printf("\n¿Buscar por id(1) o por nombre(2)?\t");
		int option = scanner.nextInt();
		scanner.nextLine();

		switch(option){
		case 1: searchForId();
		break;
		case 2: searchForName();
		break;
		default: System.out.println("Busqueda cancelada por el usuario");
		}
	}
	
	public static void searchForId(){
		System.out.printf("\nID a buscar:\t");
		ArrayList<Object[]> records = Categories.list("id", scanner.nextInt());
		if(records == null)
			System.out.println("No existe ningun registro con el ID introducido");
		else{
			for(Object[] record : records)
				System.out.printf("\nID = %d, Nombre = %s", record[0], record[1]);
		}
			
	}
	
	public static void searchForName(){
		System.out.printf("\nNombre a buscar:\t");
		String name = String.format("%%%s%%", scanner.nextLine());
		ArrayList<Object[]> records = Categories.list("nombre", name);
		String string = "";
		int counter = 0;
		
		if(records == null)
			System.out.println("No existe nigun registro con el Nombre introducido");
		else{
			if(records.size() < 1)
				System.out.printf("\nID = %d, Nombre = %s");
			else{
				Object record;
				for(counter = 0; counter < records.size(); counter++)
					string += String.format("\nID = %d, Nombre = %s", 
							records.get(counter)[0], records.get(counter)[1]);
				System.out.printf("Encontrados %d categorias para %s\n%s");
			}
		}
	}
}
