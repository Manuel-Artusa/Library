using libraryejercicio.Models;

namespace libraryejercicio.Repositories
{
    public interface IAutorRepository
    {
        Task<List<Autor>> GetAllAsync();

        Task<Autor> CreateAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task<Autor> GetByIdAsync(int id);
    }
}
