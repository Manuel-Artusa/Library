using System.ComponentModel.DataAnnotations;

namespace libraryejercicio.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fec_Nac { get; set; }
    }
}
