using API_Projeto.Enums;

namespace API_Projeto.Models.Entidades
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public string Sexo { get; set; }
        public string TipoContrato { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public StatusLancamento Lancamento { get; set; }
    }
}
