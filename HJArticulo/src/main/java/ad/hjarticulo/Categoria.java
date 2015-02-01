package ad.hjarticulo;


//import javax.persistence.Column;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

//import javax.persistence.Temporal;
//import javax.persistence.TemporalType;
import org.hibernate.annotations.GenericGenerator;

@Entity
public class Categoria{
	
	private Long id;
	private String nombre;
	
	public Categoria() {}
	
	public Categoria(String nombre){
		this.nombre = nombre;
	}
	
	public Categoria(long id, String nombre) {
		this.id =id;
		this.nombre = nombre;
	}
	
	@Id
	@Column(name = "id")
	@GeneratedValue(generator="increment")
	@GenericGenerator(name="increment", strategy = "increment")
	public Long getId() {
		return id;
	}
	
	private void setId(Long id) {
		this.id = id;
	}
	
	public String getNombre() {
		return nombre;
	}
	
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	
	public String toString(){
		return nombre;
	}
}