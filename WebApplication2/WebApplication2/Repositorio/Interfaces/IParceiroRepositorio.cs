using WebApplication2.Models;



namespace WebApplication2.Repositorio
{ 
    public interface IParceiroRepositorio
    {
         IEnumerable<ParceiroModel> Parceiros { get;}
    }

}
