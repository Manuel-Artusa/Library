using libraryejercicio.Models;

namespace libraryejercicio.Repositories
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetAllAsync();

        Task<Libro> CreateAsync(Libro libro);
        void UpdateAsync(Libro libro);
    }
}
