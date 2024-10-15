using API_Projeto.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Projeto.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Salario).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(1);
            builder.Property(x => x.DataCadastro).IsRequired().HasMaxLength(8);
            builder.Property(x => x.DataAtualizacao).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Lancamento).IsRequired();

        }
    }
}
