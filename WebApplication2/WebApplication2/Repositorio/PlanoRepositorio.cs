using WebApplication2.Data;
using WebApplication2.Models;
using System;

namespace WebApplication2.Repositorio.Interfaces
{
    public class PlanoRepositorio : IPlanorRepositorio
    {
        private readonly AppDbContext _AppDbContext;
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

        PlanoModel IPlanorRepositorio.ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        List<PlanoModel> IPlanorRepositorio.ListarTodos()
        {
            throw new NotImplementedException();
        }

        public PlanoModel Adicionar(PlanoModel plano)
        {
            throw new NotImplementedException();
        }

        public PlanoModel Atualizar(PlanoModel plano)
        {
            throw new NotImplementedException();
        }
    }
}
