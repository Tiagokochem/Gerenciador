using WebApplication1.Data;
using WebApplication1.Models;
using System;

namespace WebApplication1.Repositorio
{
    public class PlanoRepositorio : IPlanorRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PlanoRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public PlanoModel ListarPorId(int id)
        {
            return _applicationDbContext.Plano.FirstOrDefault(x => x.PlanoId == id);
        }

        public List<PlanoModel> ListarTodos()
        {
            return _applicationDbContext.Plano.ToList();
        }

        public PlanoModel Adicionar(PlanoModel plano)
        {
            _applicationDbContext.Plano.Add(plano);
            _applicationDbContext.SaveChanges();

            return plano;
        }

        public PlanoModel Atualizar(PlanoModel plano)
        {
            PlanoModel planoDB = ListarPorId(plano.PlanoId);

            if (planoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            planoDB.NomePlano = plano.NomePlano;
            planoDB.PrecoPlano = plano.PrecoPlano;
            planoDB.TermoDeUso = plano.TermoDeUso;
            planoDB.tipoPlano = plano.tipoPlano;
            _applicationDbContext.Plano.Update(planoDB);
            _applicationDbContext.SaveChanges();

            return planoDB;
        }

        public bool Apagar(int id)
        {
            PlanoModel planoDB = ListarPorId(id);

            if (planoDB == null) throw new System.Exception("Houve um erro na tentativa de apagar o contato!");

            _applicationDbContext.Plano.Remove(planoDB);
            _applicationDbContext.SaveChanges();

            return true;

        }
    }
}
