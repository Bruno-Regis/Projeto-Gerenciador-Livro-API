using GerenciadorLivro.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Application.Services
{
    public interface IUsuarioService
    {
        ResultViewModel<List<UsuarioItemViewModel>> GetAll(string search = "");
        ResultViewModel<UsuarioViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateUsuarioInputModel model);
    }
}
