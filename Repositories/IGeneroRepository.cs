using libraryejercicio.Models;

namespace libraryejercicio.Repositories
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetAllAsync();

        Task<Genero> CreateAsync(Genero genero);
        void UpdateAsync(Genero genero);
    }
}
