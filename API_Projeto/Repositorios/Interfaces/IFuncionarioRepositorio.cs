using API_Projeto.Models.Entidades;

namespace API_Projeto.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<FuncionarioModel>> BuscarTodosFuncionarios();
        Task<FuncionarioModel> BuscarPorId(int Id);
        Task<FuncionarioModel> BuscarPorEmail(string Email);
        Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario);
        Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id, string email);
        Task<bool> Apagar(int id);
    }
}
