using Site.Data;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Site.Repositorio
{
    public class PlanoRepositorio : IPlanoRepositorio
    {
        private readonly BancoContent _context;

        public PlanoRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public PlanoModel BuscarPorPlano(string plano)
        {
            return _context.Planos.FirstOrDefault(x => x.Plano.ToUpper() == plano.ToUpper());
        }

        public PlanoModel BuscarPorID(int id)
        {
            return _context.Planos.FirstOrDefault(x => x.Id == id);
        }

        public List<PlanoModel> BuscarTodos()
        {
            return _context.Planos.ToList();
        }

        public PlanoModel Adicionar(PlanoModel plano)
        {
            
            plano.DataCadastro = DateTime.Now;
            _context.Planos.Add(plano);
            _context.SaveChanges();
            return plano;
        }

        public PlanoModel Atualizar(PlanoModel plano)
        {
            PlanoModel planoDB = BuscarPorID(plano.Id);

            if (planoDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            planoDB.Plano = plano.Plano;
            planoDB.Valor = plano.Valor;
            planoDB.DataAtualizacao = DateTime.Now;

            _context.Planos.Update(planoDB);
            _context.SaveChanges();

            return planoDB;
        }

        public bool Apagar(int id)
        {
            PlanoModel planoDB = BuscarPorID(id);

            if (planoDB == null) throw new Exception("Houve um erro na deleção do usuário!");

            _context.Planos.Remove(planoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
