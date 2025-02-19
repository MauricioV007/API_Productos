using API_Productos.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Productos.Repository
{
    // Interfaz que define las operaciones CRUD para la entidad Productos
    public interface E_ProductoRepository
    {
        // Método para obtener todos los productos
        Task<IEnumerable<Productos>> FindAll();

        // Método para obtener un producto por su ID
        Task<Productos> GetById(int id);

        // Método para crear un nuevo producto
        Task<Productos> Create(Productos producto);

        // Método para actualizar un producto existente
        Task Update(int id, Productos producto);

        // Método para eliminar un producto por su ID
        Task Delete(int id);
    }
}
