using Site.Models;
using System.Collections.Generic;

namespace Site.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel BuscarPorID(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
