using MinhaApi.AcessoDados.Entity.Context;
using MinhaApi.Comum.Repositorios.Interfaces;
using MinhaApi.Dominio;
using MinhaApi.Repositorios.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MinhaApi.Api.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorioMinhaApi<Aluno, int> _repositorioAlunos = new RepositorioAlunos(new MinhaApiDbContext());

        public IEnumerable<Aluno> Get()
        {
            return _repositorioAlunos.Selecionar();
        }

        public Aluno Get(int? id)
        {
            return _repositorioAlunos.SelecionarPorId(id.Value);
        }
    }
}
