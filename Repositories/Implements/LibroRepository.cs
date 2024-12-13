using libraryejercicio.Context;
using libraryejercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryejercicio.Repositories.Implements
{
    public class LibroRepository : ILibroRepository
    {
        private readonly libraryContext _context;
        public LibroRepository(libraryContext context)
        {
            _context = context;
        }
        public async Task<Libro> CreateAsync(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task<List<Libro>> GetAllAsync()
        {
            return await _context.Libros
            .Include(l => l.Autor) 
            .Include(l => l.Genero)
            .ToListAsync();
        }

        public async Task<Libro?> GetByIdAsync(int id)
        {
            return await _context.Libros.FindAsync(id);
        }
        public async Task<Libro> UpdateAsync(Libro libro)
        { 
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();

            return libro;

        }
    }
}
