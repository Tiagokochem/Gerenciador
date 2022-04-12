using WebApplication1.Data;
using WebApplication1.Models;
using System;

namespace WebApplication1.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UsuarioRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _applicationDbContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper()) ;
        }
        public UsuarioModel ListarPorId(int id)
        {
            return _applicationDbContext.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
        }

        public List<UsuarioModel> ListarTodos()
        {
            return _applicationDbContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _applicationDbContext.Usuarios.Add(usuario);
            _applicationDbContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.UsuarioId);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na atualização do usuário!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;


            _applicationDbContext.Usuarios.Update(usuarioDb);
            _applicationDbContext.SaveChanges();

            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na tentativa de apagar o usuario!");

            _applicationDbContext.Usuarios.Remove(usuarioDb);
            _applicationDbContext.SaveChanges();

            return true;

        }

        
    }
}
