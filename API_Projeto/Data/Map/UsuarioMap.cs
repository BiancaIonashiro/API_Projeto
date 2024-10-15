using API_Projeto.Model.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Projeto.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {

        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(25);
        }
    }
}