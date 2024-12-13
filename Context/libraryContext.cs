using libraryejercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryejercicio.Context
{
    public class libraryContext : DbContext
    {
        public libraryContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().HasData(
                new Genero() { Id = 1, Nombre = "Amor" },
                new Genero() { Id = 2, Nombre = "Accion" });

            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "Manuel Artusa", Fec_Nac = new DateTime(2002, 03, 19) },
                new Autor { Id = 2, Nombre = "Davo", Fec_Nac = new DateTime(2002, 11, 21) });

            modelBuilder.Entity<Libro>().HasData(
                new Libro { ISBN = 123456, Titulo = "Soy Leyenda", AutorId = 1, Fec_Publi = new DateTime(2024, 06, 04), GeneroId = 1 },
                new Libro { ISBN = 654321, Titulo = "Soy de TALLERES", AutorId = 2, Fec_Publi = new DateTime(2020, 10, 10), GeneroId = 2 });
        }
    }
}
