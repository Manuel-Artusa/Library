using libraryejercicio.Models;
using libraryejercicio.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var generos = await _generoRepository.GetAllAsync();
            return Ok(generos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneroById(int id)
        {
            return Ok(await _generoRepository.getGeneroById(id));
        }
        [HttpPost]
        public async Task<IActionResult> PostGenero([FromBody] Genero generoDto)
        {
            var genero = await _generoRepository.CreateAsync(generoDto);
            return Ok(genero);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> putGenero(int id, [FromBody]Genero genero) {
            if(genero == null || genero.Id != id)
            {
                return BadRequest();
            }

            var existingGenero = await _generoRepository.getGeneroById(id);
            if (existingGenero == null)
            {
                return NotFound();
            }


            existingGenero.Nombre = genero.Nombre;
            

            await _generoRepository.UpdateAsync(existingGenero);
            return Ok(existingGenero);
            
        }
    }
}
