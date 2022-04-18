using WebApplication2.Models;



namespace WebApplication2.Repositorio
{ 
    public interface IParceiroRepositorio
    {
         IEnumerable<ParceiroModel> Parceiros { get;}
        IEnumerable<ParceiroModel> ParceiroAtivo { get;}

        ParceiroModel GetParceiroById(int parceiroId);
    }

}
