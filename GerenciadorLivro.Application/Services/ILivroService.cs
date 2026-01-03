using GerenciadorLivro.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Application.Services
{
    public interface ILivroService
    {
        ResultViewModel<List<LivroItemViewModel>> GetAll(string search = "");
        ResultViewModel<LivroViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateLivroInputModel model);
        ResultViewModel Delete(int id);
    }
}
