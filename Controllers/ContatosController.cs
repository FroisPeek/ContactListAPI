using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
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

        // [HttpPost("createContatos")]
        // public async Task<IActionResult> createContato([FromForm] CreateContatoDto contatoDto)
        // {
        //     var response = new Response<CreateContatoDto>();
        //     try
        //     {



        //     }
        //     catch(Exception e)
        //     {
        //         response.Success = false;
        //         response.Message = e.Message;
        //         return BadRequest(response);
        //     }
        // }
    }
}