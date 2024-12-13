using System.ComponentModel.DataAnnotations;

namespace libraryejercicio.Models
{
    public class Libro
    {
        [Key]
        public int ISBN { get; set; }
        public string Titulo { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public DateTime Fec_Publi { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
