using GerenciadorLivro.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Application.Services
{
    public interface IEmprestimoService
    {
        Task<ResultViewModel<List<EmprestimoItemViewModel>>> GetAll(string search = "");
        Task<ResultViewModel<EmprestimoViewModel>> GetById(int id);
        Task<ResultViewModel<int>> Insert(CreateEmprestimoInputModel model);
        Task<ResultViewModel> Devolver(int id);
    }
}
