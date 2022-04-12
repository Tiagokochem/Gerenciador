using WebApplication1.Models;

namespace WebApplication1.Repositorio
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