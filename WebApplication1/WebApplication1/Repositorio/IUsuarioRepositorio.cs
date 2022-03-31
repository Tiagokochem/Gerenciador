using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> ListarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);


    }
}

