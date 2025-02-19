using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Productos.Entity;
using API_Productos.Repository;

namespace API_Productos.Controllers
{
    // Define la ruta base para el controlador como "api/productos".
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // Repositorio para manejar operaciones relacionadas con productos.
        private readonly E_ProductoRepository _repository;

        // Constructor que inyecta el repositorio de productos.
        public ProductosController(E_ProductoRepository repository)
        {
            _repository = repository;
        }

        // Método para obtener todos los productos.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> FindAll()
        {
            return Ok(await _repository.FindAll());
        }

        // Método para obtener un producto por su ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos?>> GetById(int id)
        {
            var producto = await _repository.GetById(id);

            // Si no se encuentra el producto, devuelve un código 404 (Not Found).
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // Método para crear un nuevo producto.
        [HttpPost]
        public async Task<ActionResult<Productos>> Create([FromBody] Productos producto)
        {
            // Verifica que el producto no sea nulo.
            if (producto == null)
            {
                return BadRequest(); // Devuelve un código 400 (Bad Request) si el objeto es inválido.
            }

            var createProduct = await _repository.Create(producto);

            // Retorna el producto creado con un código 201 (Created) y la ruta para consultarlo.
            return CreatedAtAction(nameof(GetById), new { id = createProduct.Id }, createProduct);
        }

        // Método para actualizar un producto existente por su ID.
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Productos productos)
        {
            await _repository.Update(id, productos);
            return Ok(); // Devuelve un código 200 (OK) si la actualización fue exitosa.
        }

        // Método para eliminar un producto por su ID.
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok(); // Devuelve un código 200 (OK) si la eliminación fue exitosa.
        }
    }
}

