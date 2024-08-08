using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class ContatosMapper
    {
        public static ReadContatosDto ToReadContatosDto(this Contatos contatos)
        {
            return new ReadContatosDto
            {
                codigo = contatos.codigo,
                nome = contatos.nome,
                sobrenome = contatos.sobrenome,
                email = contatos.email,
                numero = contatos.numero,
                link = contatos.link
            };
        }

        public static CreateContatoDto ToCreateContatoDto(this Contatos contato)
        {
            return new CreateContatoDto
            {
                nome = contato.nome,
                sobrenome = contato.sobrenome,
                email = contato.email,
                numero = contato.numero,
                link = contato.link
            };
        }
    }
}