using libraryejercicio.Models;

namespace libraryejercicio.Repositories
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetAllAsync();
        Task<Genero> getGeneroById(int id);
        Task<Genero> CreateAsync(Genero genero);
        Task<Genero> UpdateAsync(Genero genero);
    }
}
