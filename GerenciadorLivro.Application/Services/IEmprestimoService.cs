using GerenciadorLivro.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Application.Services
{
    public interface IEmprestimoService
    {
        ResultViewModel<List<EmprestimoItemViewModel>> GetAll(string search = "");
        ResultViewModel<EmprestimoViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateEmprestimoInputModel model);
        ResultViewModel Devolver(int id);
    }
}
