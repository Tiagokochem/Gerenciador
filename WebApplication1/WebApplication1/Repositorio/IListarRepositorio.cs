﻿using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public interface IListarRepositorio
    {
        ParceiroModel ListarPorId(int id);
        List<PlanoModel> ListarTodos();
        ParceiroModel Adicionar(ParceiroModel parceiro);

        ParceiroModel Atualizar(ParceiroModel parceiro);

        bool Apagar(int id);


    }
}