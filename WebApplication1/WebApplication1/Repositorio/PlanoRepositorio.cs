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
            return _applicationDbContext.Parceiros.FirstOrDefault(x => x.Id == id);
        }

        public List<PlanoModel> ListarTodos()
        {
            return _applicationDbContext.Parceiros.ToList();
        }

        public PlanoModel Adicionar(PlanoModel parceiro)
        {
            parceiro.DataDeCadastro = DateTime.Now;
            _applicationDbContext.Parceiros.Add(parceiro);
            _applicationDbContext.SaveChanges();

            return parceiro;
        }

        public PlanoModel Atualizar(PlanoModel parceiro)
        {
            PlanoModel parceiroDB = ListarPorId(parceiro.Id);

            if (parceiroDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            parceiroDB.ParceiroNome = parceiro.ParceiroNome;
            parceiroDB.ParceiroFantasia = parceiro.ParceiroFantasia;
            parceiroDB.ParceiroRazaoSocial = parceiro.ParceiroRazaoSocial;
            parceiroDB.Email = parceiro.Email;
            parceiroDB.ParceiroCep = parceiro.ParceiroCep;
            parceiroDB.ParceiroCidade = parceiro.ParceiroCidade;
            parceiroDB.ParceiroEstado = parceiro.ParceiroEstado;
            parceiroDB.ParceiroTelefone = parceiro.ParceiroTelefone;
            parceiroDB.DataDeAlteracao = DateTime.Now;

            _applicationDbContext.Parceiros.Update(parceiroDB);
            _applicationDbContext.SaveChanges();

            return parceiroDB;
        }

        public bool Apagar(int id)
        {
            PlanoModel parceiroDB = ListarPorId(id);

            if (parceiroDB == null) throw new System.Exception("Houve um erro na tentativa de apagar o contato!");

            _applicationDbContext.Parceiros.Remove(parceiroDB);
            _applicationDbContext.SaveChanges();

            return true;

        }
    }
}
