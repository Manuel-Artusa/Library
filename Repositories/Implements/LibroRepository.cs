using libraryejercicio.Context;
using libraryejercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryejercicio.Repositories.Implements
{
    public class LibroRepository: ILibroRepository
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

        public Task<List<Libro>> GetAllAsync()
        {
            return _context.Libros.ToListAsync();
        }

        public void UpdateAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            _context.SaveChanges();
        }
    }
}
