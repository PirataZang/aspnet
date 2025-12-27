using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Data;
using AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem(Personagens personagem)
        {
            await _AppDbContext.Personagens.AddAsync(personagem);
            await _AppDbContext.SaveChangesAsync();
            return Ok(personagem);
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonagens()
        {
            var personagens = await _AppDbContext.Personagens.ToListAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonagem(int id)
        {
            var personagem = await _AppDbContext.Personagens.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }
            return Ok(personagem);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatePersonagem(int id, Personagens updatedPersonagem)
        {
            var personagem = await _AppDbContext.Personagens.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }

            personagem.nome = updatedPersonagem.nome;
            personagem.descricao = updatedPersonagem.descricao;

            await _AppDbContext.SaveChangesAsync();
            return Ok(personagem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _AppDbContext.Personagens.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }

            _AppDbContext.Personagens.Remove(personagem);
            await _AppDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}