using Site.Models;
using System.Collections.Generic;

namespace Site.Repositorio
{
    public interface IPlanoRepositorio
    {
        PlanoModel BuscarPorPlano(string plano);
        List<PlanoModel> BuscarTodos();
        PlanoModel BuscarPorID(int id);
        PlanoModel Adicionar(PlanoModel plano);

        PlanoModel Atualizar(PlanoModel plano);
        bool Apagar (int id);
    }
}
