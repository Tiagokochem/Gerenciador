using WebApplication2.Models;

namespace WebApplication2.Repositorio
{
    public interface IListarRepositorio
    {
        ParceiroModel ListarPorId(int id);
        List<ParceiroModel> ListarTodos();
        ParceiroModel Adicionar(ParceiroModel plano);

        ParceiroModel Atualizar(ParceiroModel plano);

        bool Apagar(int id);


    }
}