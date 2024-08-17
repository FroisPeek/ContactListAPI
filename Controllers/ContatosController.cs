using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Helper;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ContatosController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("getContatos")]
        public async Task<IActionResult> getContatos()
        {
            var response = new Response<IEnumerable<ReadContatosDto>>();
            try
            {
                var contatos = await _context.Contatos.ToListAsync();

                if (contatos == null)
                {
                    response.Success = false;
                    response.Message = "Nenhum contato encontrado";
                    return NotFound(response);
                }

                response.Data = contatos.Select(c => c.ToReadContatosDto());
                response.Success = true;
                response.Message = "Contatos encontrados com sucesso";
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("createContatos")]
        public async Task<IActionResult> createContato([FromBody] CreateContatoDto newCt)
        {
            var response = new Response<CreateContatoDto>();
            try
            {
                var newContato = new Contatos
                {
                    nome = newCt.nome,
                    sobrenome = newCt.sobrenome,
                    numero = newCt.numero,
                    cpf = newCt.cpf,
                    email = newCt.email,
                    link = newCt.link
                };

                _context.Contatos.Add(newContato);
                await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "Contato criado com sucesso";
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("editContato/{contatoId}")]
        public async Task<IActionResult> editContato([FromRoute] int contatoId, [FromBody] EditContatoDto editContato)
        {
            var response = new Response<EditContatoDto>();
            try
            {
                var contatoToEdit = await _context.Contatos.FirstOrDefaultAsync(c => c.codigo == contatoId);

                if (contatoToEdit == null)
                {
                    response.Success = false;
                    response.Message = "Contato não encontrado";
                    return NotFound(response);
                }

                contatoToEdit.nome = editContato.nome;
                contatoToEdit.sobrenome = editContato.sobrenome;
                contatoToEdit.email = editContato.email;
                contatoToEdit.cpf = editContato.cpf;
                contatoToEdit.numero = editContato.numero;
                contatoToEdit.link = editContato.link;

                await _context.SaveChangesAsync();
                response.Data = contatoToEdit.ToEditContatoDto();
                response.Success = true;
                response.Message = "Contato editado com sucesso!";
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteContato/{contatoId}")]
        public async Task<IActionResult> DeleteContato([FromRoute] int contatoId)
        {
            var response = new Response<ReadContatosDto>();
            try
            {
                var contatoToDelete = await _context.Contatos.FirstOrDefaultAsync(c => c.codigo == contatoId);

                if (contatoToDelete == null)
                {
                    response.Success = false;
                    response.Message = "Nenhum contato encontrado";
                    return NotFound(response);
                }

                _context.Contatos.Remove(contatoToDelete);
                await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "Contato deletado com sucesso";
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? nome)
        {
            var response = new Response<List<Contatos>>();
            try
            {
                var query = _context.Contatos.AsQueryable();

                if (!string.IsNullOrEmpty(nome))
                {
                    query = query.Where(q => q.nome.Contains(nome));
                }

                response.Data = query.ToList();
                response.Success = true;
                response.Message = "Contatos encontrados.";
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return BadRequest(response);
            }
        }

    }
}