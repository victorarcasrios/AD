package ad.hjarticulo;

import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class Main {
	
	private static EntityManagerFactory entityManagerFactory;
	
	public static void main(String[] args) {		
		entityManagerFactory = Persistence.createEntityManagerFactory( "ad.hjarticulo.lpa.mysql" );
		
		showCategorias();
		showArticulos();

		insertCategoria();
		insertArticulo();
		
		updateCategoria();
		updateArticulo();
		
		deleteCategoria();
		deleteArticulo();
		
		entityManagerFactory.close();
	}
	
	public static void showCategorias(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		List<Categoria> categorias = entityManager.createQuery( "from Categoria", Categoria.class ).getResultList();
		System.out.print("\nCategorias:\nID\tNombre\n");
		for ( Categoria categoria : categorias ) {
			System.out.printf( "#%d\t%s\n",
					categoria.getId(), categoria.getNombre());
		}
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void showArticulos(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		List<Articulo> articulos = entityManager.createQuery( "from Articulo", Articulo.class ).getResultList();
		System.out.print("\nArticulos:\nID\tNombre\t\tCategoria\t\tPrecio\n");
		for ( Articulo articulo : articulos ){
			System.out.printf("#%d\t%s\t%s\t\t%.2f\n",
					articulo.getId(), articulo.getNombre(), articulo.getCategoria(), articulo.getPrecio());
		}
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void insertCategoria(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Categoria categoria = new Categoria("Nueva categoria");
		entityManager.persist(categoria);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void insertArticulo(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = new Articulo(
				"Nuevo articulo", new Categoria("Categoria articulo"), 15.00
				);
		entityManager.persist(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();		
	}
	
	public static void updateCategoria(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Categoria categoria = entityManager.find(Categoria.class, (long)4);
		categoria.setNombre("Categoria actualizada");
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void updateArticulo(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = entityManager.find(Articulo.class, (long)7);
		articulo.setNombre("Articulo actualizado");
		articulo.setPrecio(10.00);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void deleteCategoria(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Categoria categoria = entityManager.find(Categoria.class, (long)19);
		entityManager.remove(categoria);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	
	public static void deleteArticulo(){
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = entityManager.find(Articulo.class, (long)9);
		entityManager.remove(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
}