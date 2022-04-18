using WebApplication2.Models;
using System;
using WebApplication2.Context;

namespace WebApplication2.Repositorio.Interfaces
{
    public class PlanoRepositorio : IPlanoRepositorio
    {

        private readonly AppDbContext _context;

        public PlanoRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public PlanoModel ListarPorId(int planoid)
        {
            return _context.Planos.FirstOrDefault(x => x.PlanoId == planoid);
        }

        public List<PlanoModel> ListarTodos()
        {
            return _context.Planos.ToList();
        }

        public PlanoModel Adicionar(PlanoModel plano)
        {
            _context.Planos.Add(plano);
            _context.SaveChanges();

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
            _context.Planos.Update(planoDB);
            _context.SaveChanges();

            return planoDB;
        }

        public bool Apagar(int Planoid)
        {
            PlanoModel planoDB = ListarPorId(Planoid);

            if (planoDB == null) throw new System.Exception("Houve um erro na tentativa de apagar o contato!");

            _context.Planos.Remove(planoDB);
            _context.SaveChanges();

            return true;

        }

    }
}
