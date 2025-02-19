using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Productos.Entity
{
    // Clase que representa la entidad de Productos en la base de datos
    public class Productos
    {
        // Propiedad clave primaria, generada automáticamente por la base de datos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Propiedad obligatoria que almacena el nombre del producto
        [Required]
        public string Nombre { get; set; }

        // Propiedad que almacena el precio del producto con formato decimal (18,2)
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        // Propiedad que almacena la cantidad disponible en stock
        public int Stock { get; set; }
    }
}


