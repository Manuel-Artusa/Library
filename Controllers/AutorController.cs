using libraryejercicio.Models;
using libraryejercicio.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _repository;
        public AutorController(IAutorRepository autorRepository)
        {
            _repository = autorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            return Ok (await _repository.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> postAutores([FromBody] Autor autor)
        {
            var autorPost = await _repository.CreateAsync(autor);
            return Ok(autorPost);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateAutor(int id, [FromBody] Autor autor)
        {
            if (autor == null || autor.Id != id)
            {
                return BadRequest();
            }

            var existingAutor = await _repository.GetByIdAsync(id);
            if (existingAutor == null)
            {
                return NotFound();
            }

            
            existingAutor.Nombre = autor.Nombre;
            existingAutor.Fec_Nac = autor.Fec_Nac;

            await _repository.UpdateAsync(existingAutor);
            return Ok(existingAutor);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getAutorById(int id) { 

            return Ok(await _repository.GetByIdAsync(id));
        }

    }
}
