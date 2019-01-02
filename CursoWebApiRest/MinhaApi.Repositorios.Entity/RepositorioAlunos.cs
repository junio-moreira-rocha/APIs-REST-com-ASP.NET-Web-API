using MinhaApi.AcessoDados.Entity.Context;
using MinhaApi.Comum.Repositorios.Entity;
using MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Repositorios.Entity
{
    public class RepositorioAlunos : RepositorioMinhaApi<Aluno, int>
    {
        public RepositorioAlunos(MinhaApiDbContext context)
            : base(context)
        {
        }
    }
}
