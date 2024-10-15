using API_Projeto.Model.Entidades;
using API_Projeto.Models.Entidades;
using API_Projeto.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuncionarioModel>>> BuscarTodosFuncionarios()
        {
            List<FuncionarioModel> funcionarios = await _funcionarioRepositorio.BuscarTodosFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioModel>> BuscarPorId(int id)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorId(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> Cadastrar([FromBody] FuncionarioModel funcionarioModel)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.Adicionar(funcionarioModel);
            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Atualizar([FromBody] FuncionarioModel funcionarioModel, int id, string email)
        {
            funcionarioModel.Id = id;
            FuncionarioModel funcionario = await _funcionarioRepositorio.Atualizar(funcionarioModel, id, email);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Apagar(int id)
        {
            bool apagado = await _funcionarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
