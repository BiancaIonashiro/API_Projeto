using API_Projeto.Data;
using API_Projeto.Models.Entidades;
using API_Projeto.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Projeto.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dBContext;

        public FuncionarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dBContext = sistemaTarefasDBContex;
        }

        public async Task<FuncionarioModel> BuscarPorId(int id)
        {
            return await _dBContext.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Id == id);
        }

        //Pedido adicional do cliente Gabriel
        public async Task<FuncionarioModel> BuscarPorEmail(string email)
        {
            return await _dBContext.Funcionarios.FirstOrDefaultAsync(funcionario => funcionario.Email == email);
        }

        public async Task<List<FuncionarioModel>> BuscarTodosFuncionarios()
        {
            return await _dBContext.Funcionarios.ToListAsync();
        }
        public async Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario)
        {
            await _dBContext.Funcionarios.AddAsync(funcionario);
            await _dBContext.SaveChangesAsync();

            return funcionario;
        }

        public async Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id, string email)
        {
            FuncionarioModel funcionarioPorId = await BuscarPorId(id);
            FuncionarioModel funcionarioPorEmail = await BuscarPorEmail(email);

            if (funcionarioPorId == null && funcionarioPorEmail == null)
            {
                throw new Exception($"Funcionário para o ID: {id} não foi encontrado no banco de dados.");
                throw new Exception($"Funcionário para o Email: {email} não foi encontrado no banco de dados.");
            }

            funcionarioPorId.Id = funcionario.Id;
            funcionarioPorId.Nome = funcionario.Nome;
            funcionarioPorId.Email = funcionario.Email;
            funcionarioPorId.Salario = funcionario.Salario;
            funcionarioPorId.Sexo = funcionario.Sexo;
            funcionarioPorId.TipoContrato = funcionario.TipoContrato;
            funcionarioPorId.DataCadastro = funcionario.DataCadastro;
            funcionarioPorId.DataAtualizacao = funcionario.DataAtualizacao;

            _dBContext.Funcionarios.Update(funcionarioPorId);
           await _dBContext.SaveChangesAsync();

            return funcionarioPorId;

            funcionarioPorEmail.Id = funcionario.Id;
            funcionarioPorEmail.Nome = funcionario.Nome;
            funcionarioPorEmail.Email = funcionario.Email;
            funcionarioPorEmail.Salario = funcionario.Salario;
            funcionarioPorEmail.Sexo = funcionario.Sexo;
            funcionarioPorEmail.TipoContrato = funcionario.TipoContrato;
            funcionarioPorEmail.DataCadastro = funcionario.DataCadastro;
            funcionarioPorEmail.DataAtualizacao = funcionario.DataAtualizacao;

            _dBContext.Funcionarios.Update(funcionarioPorEmail);
            await _dBContext.SaveChangesAsync();

            return funcionarioPorEmail;

        }


        public async Task<bool> Apagar(int id)
        {
            FuncionarioModel funcionarioPorId = await BuscarPorId(id);
            if (funcionarioPorId == null)
            {
                throw new Exception($"Funcionário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dBContext.Funcionarios.Remove(funcionarioPorId);
            await _dBContext.SaveChangesAsync();
            return true;

        }      
        
    }
}
