using libraryejercicio.Context;
using libraryejercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryejercicio.Repositories.Implements
{
    public class GeneroRepository:IGeneroRepository
    {
        private readonly libraryContext _context;
        public GeneroRepository(libraryContext context)
        {
            _context = context;
        }
        public async Task<Genero> CreateAsync(Genero genero)
        {
            await _context.AddAsync(genero);
            await _context.SaveChangesAsync();
            return genero;
        }

        public Task<List<Genero>> GetAllAsync()
        {
            return _context.Generos.ToListAsync();
        }

        public async void UpdateAsync(Genero genero)
        {
            _context.Generos.Update(genero);
            await _context.SaveChangesAsync();
        }
    }
}
