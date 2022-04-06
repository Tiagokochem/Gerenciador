using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public interface IListarRepositorio
    {
        PlanoModel ListarPorId(int id);
        List<PlanoModel> ListarTodos();
        PlanoModel Adicionar(PlanoModel plano);

        PlanoModel Atualizar(PlanoModel plano);

        bool Apagar(int id);


    }
}