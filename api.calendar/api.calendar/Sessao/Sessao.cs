using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.calendar.Sessao
{
    public class Sessao
    {
        private IHttpContextAccessor _context;
        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

        /*
         * CRUD - Cadastrar/Atualizar/Consultar/Remover - RemoverTodos/Exist
         */
        public void Cadastrar(string Key, string Valor)
        {
            _context.HttpContext.Session.SetString(Key, Valor);
        }
    }
}
