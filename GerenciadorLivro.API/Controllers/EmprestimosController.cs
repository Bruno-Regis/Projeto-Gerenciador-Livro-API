using GerenciadorLivro.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/emprestimos")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        [HttpPost]
        // POST api/emprestimos
        public IActionResult Post(CreateEmprestimoInputModel model)
        {
            return CreatedAtAction(nameof(Post), new { id = 1 }, model);
        }


    }
}
