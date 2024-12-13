using libraryejercicio.Models;

namespace libraryejercicio.Repositories
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetAllAsync();

        Task<Libro> CreateAsync(Libro libro);
        Task<Libro> UpdateAsync(Libro libro);

        Task<Libro?> GetByIdAsync(int id);
    }
}
