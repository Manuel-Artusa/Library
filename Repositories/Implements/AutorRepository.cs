using libraryejercicio.Context;
using libraryejercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryejercicio.Repositories.Implements
{
    public class AutorRepository : IAutorRepository
    {
        private readonly libraryContext _context;
        public AutorRepository(libraryContext context)
        {
            _context = context;
        }
        public async Task<Autor> CreateAsync(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<List<Autor>> GetAllAsync()
        {
            return await _context.Autores.ToListAsync();
             
        }

        public async Task<Autor> GetByIdAsync(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task UpdateAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }
    }
}
