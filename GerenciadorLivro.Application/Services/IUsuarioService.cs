using GerenciadorLivro.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Application.Services
{
    public interface IUsuarioService
    {
        Task<ResultViewModel<List<UsuarioItemViewModel>>> GetAll(string search = "");
        Task<ResultViewModel<UsuarioViewModel>> GetById(int id);
        Task<ResultViewModel<int>> Insert(CreateUsuarioInputModel model);
    }
}
