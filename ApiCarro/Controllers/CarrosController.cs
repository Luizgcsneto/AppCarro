using ApiCarro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCarro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly Contexto _contexto;

        public CarrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> PegarTodosAsync()
        {
            return await _contexto.Carros.ToListAsync();
        }

        [HttpGet("{CarroId}")]
        public async Task<ActionResult<Carro>> PegarPeloId(int carroId)
        {
            Carro carro = await _contexto.Carros.FindAsync(carroId);
            if (carro == null)
                NotFound();

            return carro;
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> SalvarCarroAsync(Carro carro)
        {
            await _contexto.Carros.AddAsync(carro);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarCarroAsync(Carro carro)
        {
            _contexto.Carros.Update(carro);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{CarroId}")]
        public async Task<ActionResult> DeletarCarroAsync(int carroId)
        {
            Carro carro = await _contexto.Carros.FindAsync(carroId);
            if (carro == null)
                return NotFound();
            _contexto.Remove(carro);
            await _contexto.SaveChangesAsync();
            return Ok();
        }
    }
}