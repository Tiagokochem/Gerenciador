using WebApplication2.Models;

namespace WebApplication2.Repositorio
{
    public interface IPlanorRepositorio
    {
        PlanoModel ListarPorId(int id);
        List<PlanoModel> ListarTodos();
        PlanoModel Adicionar(PlanoModel plano);

        PlanoModel Atualizar(PlanoModel plano);

        bool Apagar(int id);


    }
}