using API_Productos.Datos;
using API_Productos.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Productos.Repository
{
    // Implementación del repositorio de productos
    public class ProductoRepository : E_ProductoRepository
    {
        // Contexto de la base de datos para interactuar con los datos
        private readonly ApplicationDbContext _context;

        // Constructor que inyecta el contexto de la base de datos
        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los productos de la base de datos
        public async Task<IEnumerable<Productos>> FindAll()
        {
            return await _context.Productos.ToListAsync();
        }

        // Método para obtener un producto por su ID
        public async Task<Productos?> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            // Retorna null si el producto no se encuentra
            if (producto == null)
            {
                return null;
            }
            return producto;
        }

        // Método para crear un nuevo producto en la base de datos
        public async Task<Productos> Create(Productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        // Método para actualizar un producto existente en la base de datos
        public async Task Update(int id, Productos producto)
        {
            var existingProduct = await _context.Productos.FindAsync(id);

            // Si el producto no existe, se lanza una excepción
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Producto no encontrado");
            }

            // Se actualizan los datos del producto
            existingProduct.Nombre = producto.Nombre;
            existingProduct.Precio = producto.Precio;
            existingProduct.Stock = producto.Stock;

            await _context.SaveChangesAsync();
        }

        // Método para eliminar un producto por su ID
        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            // Si el producto existe, se elimina de la base de datos
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}



