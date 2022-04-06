using WebApplication1.Data;
using WebApplication1.Models;
using System;

namespace WebApplication1.Repositorio
{
    public class ListarRepositorio : IListarRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ListarRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public PlanoModel ListarPorId(int id)
        {
            return _applicationDbContext.Planos.FirstOrDefault(x => x.Id == id);
        }

        public List<PlanoModel> ListarTodos()
        {
            return _applicationDbContext.Planos.ToList();
        }

        public PlanoModel Adicionar(PlanoModel parceiro)
        {
            parceiro.DataDeCadastro = DateTime.Now;
            _applicationDbContext.Planos.Add(parceiro);
            _applicationDbContext.SaveChanges();

            return parceiro;
        }

        public PlanoModel Atualizar(PlanoModel plano)
        {
            PlanoModel planoDB = ListarPorId(plano.Id);

            if (planoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            planoDB.ParceiroNome = plano.ParceiroNome;

            planoDB.DataDeAlteracao = DateTime.Now;

            _applicationDbContext.Planos.Update(planoDB);
            _applicationDbContext.SaveChanges();

            return planoDB;
        }

        public bool Apagar(int id)
        {
            PlanoModel planoDB = ListarPorId(id);

            if (planoDB == null) throw new System.Exception("Houve um erro na tentativa de apagar o contato!");

            _applicationDbContext.Planos.Remove(planoDB);
            _applicationDbContext.SaveChanges();

            return true;

        }
    }
}
