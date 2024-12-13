using libraryejercicio.Models;
using libraryejercicio.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;

        public LibroController(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLibros()
        {
            var libros = await _libroRepository.GetAllAsync();
            return Ok(libros);
        }

        [HttpPost]
        public async Task<IActionResult> PostLibro([FromBody] Libro libroDto)
        {
            var libro = await _libroRepository.CreateAsync(libroDto);
            return Ok(libro);
        }
    }
}
