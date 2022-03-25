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

        public ParceiroModel ListarPorId(int id)
        {
            return _applicationDbContext.Parceiros.FirstOrDefault(x => x.Id == id);
        }

        public List<ParceiroModel> ListarTodos()
        {
            return _applicationDbContext.Parceiros.ToList();
        }

        public ParceiroModel Adicionar(ParceiroModel parceiro)
        {
            _applicationDbContext.Parceiros.Add(parceiro);
            _applicationDbContext.SaveChanges();

            return parceiro;
        }

        public ParceiroModel Atualizar(ParceiroModel parceiro)
        {
            ParceiroModel parceiroDB = ListarPorId(parceiro.Id);

            if (parceiroDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            parceiroDB.ParceiroNome = parceiro.ParceiroNome;
            parceiroDB.ParceiroFantasia = parceiro.ParceiroFantasia;
            parceiroDB.ParceiroRazaoSocial = parceiro.ParceiroRazaoSocial;
            parceiroDB.Email = parceiro.Email;
            parceiroDB.ParceiroCep = parceiro.ParceiroCep;
            parceiroDB.ParceiroCidade = parceiro.ParceiroCidade;
            parceiroDB.ParceiroEstado = parceiro.ParceiroEstado;
            parceiroDB.ParceiroTelefone = parceiro.ParceiroTelefone;

            _applicationDbContext.Parceiros.Update(parceiroDB);
            _applicationDbContext.SaveChanges();

            return parceiroDB;
        }

        public bool Apagar(int id)
        {
            ParceiroModel parceiroDB = ListarPorId(id);

            if (parceiroDB == null) throw new System.Exception("Houve um erro na tentativa de apagar o contato!");

            _applicationDbContext.Parceiros.Remove(parceiroDB);
            _applicationDbContext.SaveChanges();

            return true;

        }
    }
}
