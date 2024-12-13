using libraryejercicio.Models;
using libraryejercicio.Repositories;
using libraryejercicio.Repositories.Implements;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, [FromBody] Libro libro)
        {
            if (libro == null || libro.ISBN != id)
            {
                return BadRequest();
            }

            var exisitingLibro = await _libroRepository.GetByIdAsync(id);

            if (exisitingLibro == null)
            {
                return NotFound();
            }
            exisitingLibro.Titulo = libro.Titulo;
            exisitingLibro.Fec_Publi = libro.Fec_Publi;
            exisitingLibro.Autor = libro.Autor;
            exisitingLibro.AutorId = libro.AutorId;
            exisitingLibro.GeneroId = libro.GeneroId;
            exisitingLibro.Genero = libro.Genero;


            await _libroRepository.UpdateAsync(exisitingLibro);
            return Ok(exisitingLibro);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getLibroById(int id) {
            return Ok(await _libroRepository.GetByIdAsync(id));
        }
    }
}
