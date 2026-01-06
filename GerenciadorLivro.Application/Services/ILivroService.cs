using GerenciadorLivro.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Application.Services
{
    public interface ILivroService
    {
        Task<ResultViewModel<List<LivroItemViewModel>>> GetAll(string search = "");
        Task<ResultViewModel<LivroViewModel>> GetById(int id);
        Task<ResultViewModel<int>> Insert(CreateLivroInputModel model);
        Task<ResultViewModel> Delete(int id);
    }
}
