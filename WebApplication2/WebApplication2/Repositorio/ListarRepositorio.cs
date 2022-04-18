//using WebApplication2.Data;
//using WebApplication2.Models;
//using System;

//namespace WebApplication2.Repositorio.Interfaces
//{
//    public class ListarRepositorio : IListarRepositorio
//    {
//        private readonly ApplicationDbContext _applicationDbContext;
//        public ListarRepositorio(ApplicationDbContext applicationDbContext)
//        {
//            _applicationDbContext = applicationDbContext;
//        }

//        public ParceiroModel ListarPorId(int id)
//        {
//            return _applicationDbContext.Parceiro.FirstOrDefault(x => x.ParceiroId == id);
//        }

//        public List<ParceiroModel> ListarTodos()
//        {
            
//            return _applicationDbContext.Parceiro.ToList();
//        }

//        public ParceiroModel Adicionar(ParceiroModel parceiro)
//        {
//            parceiro.DataDeCadastro = DateTime.Now;
//            _applicationDbContext.Parceiro.Add(parceiro);
//            _applicationDbContext.SaveChanges();

//            return parceiro;
//        }

//        public ParceiroModel Atualizar(ParceiroModel parceiro)
//        {
//            ParceiroModel parceiroDb = ListarPorId(parceiro.ParceiroId);

//            if (parceiroDb == null) throw new System.Exception("Houve um erro na atualização do contato!");

//            parceiroDb.ParceiroNome = parceiro.ParceiroNome;

//            parceiroDb.DataDeAlteracao = DateTime.Now;

//            _applicationDbContext.Parceiro.Update(parceiroDb);
//            _applicationDbContext.SaveChanges();

//            return parceiroDb;
//        }

//        public bool Apagar(int id)
//        {
//            ParceiroModel parceiroDb = ListarPorId(id);

//            if (parceiroDb == null) throw new System.Exception("Houve um erro na tentativa de apagar o contato!");

//            _applicationDbContext.Parceiro.Remove(parceiroDb);
//            _applicationDbContext.SaveChanges();

//            return true;

//        }

//    }
//}
