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
        [HttpPost]
        public async Task<IActionResult> PostGenero([FromBody] Genero generoDto)
        {
            var genero = await _generoRepository.CreateAsync(generoDto);
            return Ok(genero);
        }
    }
}
