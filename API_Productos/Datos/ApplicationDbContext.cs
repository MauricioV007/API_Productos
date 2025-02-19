using Microsoft.EntityFrameworkCore;
using API_Productos.Entity;
namespace API_Productos.Datos
{
    // Clase que representa el contexto de la base de datos y gestiona las entidades.
    public class ApplicationDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración para el contexto.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet que representa la tabla de productos en la base de datos.
        public DbSet<Productos> Productos { get; set; }

        // Configuración adicional del modelo de datos.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura la propiedad 'Id' para que se genere automáticamente al agregar un nuevo producto.
            modelBuilder.Entity<Productos>().Property(product => product.Id).ValueGeneratedOnAdd();

            // Configura la propiedad 'Nombre' para que sea un campo único en la base de datos.
            modelBuilder.Entity<Productos>().HasIndex(product => product.Nombre).IsUnique();
        }
    }
}

