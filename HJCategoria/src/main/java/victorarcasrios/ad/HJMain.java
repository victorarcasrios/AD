package victorarcasrios.ad;

import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class HJMain {

	private static final persistence_file = "victorarcasrios.ad.hibernate.mysql";
	private static EntityManagerFactory entityManagerFactory;
	
	public static void main(String[] args) {
		
		entityManagerFactory = Persistence.createEntityManager(persistence_file);
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		
		List<Categoria> categorias = entityManager.createQuery("FROM Categoria", Categoria.class).getResultList();
		for (Categoria categoria : categorias)
			System.out.printf("id=%d\t|\tnombre=%s\n", categoria.getId(), categoria.getNombre());
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}

}
