using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Helper;
using api.Mappers;
using api.Models;
using ContactListAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Services;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly ApplicationDBContext _context;
        public AuthController(ApplicationDBContext context, TokenService tokenService)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCadastrados user)
        {
            var response = new Response<UserCadastrados>();

            try 
            {

            var userExists = await _context.UserCadastrados.AnyAsync();
            var lastCode = userExists ? _context.UserCadastrados.Max(p => p.codigo) + 1 : 1;

            var newUser = new UserCadastrados 
            {
                codigo = lastCode,
                nome = user.nome,
                senha = user.senha
            };

            _context.UserCadastrados.Add(newUser);
            await _context.SaveChangesAsync();

            response.Data = newUser;
            response.Success = true;
            response.Message = "Usuário criado com sucesso.";
            return Ok(response);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Algo ocorreu errado";
                response.Data = null;
                return BadRequest(response);
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCadastrados login)
        {
            var response = new Response<object>();

            try
            {
                if (string.IsNullOrEmpty(login.nome) || string.IsNullOrEmpty(login.senha))
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "E-mail e senha são obrigatórios.";
                    return BadRequest(response);
                }

                var user = await _context.UserCadastrados
                    .FirstOrDefaultAsync(u => u.nome == login.nome && u.senha == login.senha);

                if (user == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Usuário ou senha inválidos.";
                    return Unauthorized(response); 
                }                
                response.Success = true;
                response.Message = "Usuário autenticado com sucesso.";
                response.Data = new
                {
                    userId = user.codigo,
                    userName = user.nome,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Erro interno ao autenticar usuário.";
                return StatusCode(500, response); 
            }
        }



    }
}