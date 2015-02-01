package ad.hjarticulo;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;

import org.hibernate.annotations.GenericGenerator;

@Entity
public class Articulo {

	private Long id;
	private String nombre;
	private Categoria categoria;
	private Double precio;
	
	public Articulo(){}
	
	public Articulo(String nombre, Categoria categoria, Double precio){
		this.nombre = nombre;
		this.categoria = categoria;
		this.precio = precio;
	}
	
	public Articulo(Long id, String nombre, Categoria categoria, Double precio){
		this.id = id;
		this.nombre = nombre;
		this.categoria = categoria;
		this.precio = precio;
	}
	
	@Id
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
	
	@OneToOne(cascade = CascadeType.ALL)
	@JoinColumn(name = "categoria")
	public Categoria getCategoria(){
		return categoria;
	}
	
	public void setCategoria(Categoria categoria){
		this.categoria = categoria;
	}
	
	public Double getPrecio(){
		return precio;
	}
	
	public void setPrecio(Double precio){
		this.precio = precio;
	}
	
}
