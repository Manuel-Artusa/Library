using System.ComponentModel.DataAnnotations;

namespace libraryejercicio.Models
{
    public class Genero
    {
        [Key]
        public int? Id { get; set; }
        public string Nombre { get; set; }
    }
}
