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
        public IHttpActionResult Get()
        {
            return Ok(_repositorioAlunos.Selecionar());
        }
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            return Content(HttpStatusCode.Found, aluno);
        }
        public IHttpActionResult Post([FromBody]Aluno aluno)
        {
            try
            {
                _repositorioAlunos.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put(int? id, [FromBody]Aluno aluno)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                aluno.Id = id.Value;
                _repositorioAlunos.Atualizar(aluno);
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }
                Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);
                if (aluno == null)
                {
                    return NotFound();
                }
                _repositorioAlunos.ExcluirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }
    }
}
