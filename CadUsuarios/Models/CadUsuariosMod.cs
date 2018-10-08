namespace CadUsuarios.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CadUsuariosMod : DbContext
    {
        public CadUsuariosMod()
            : base("name=CadUsuariosMod")
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioDetalhe> UsuarioDetalhes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.SobreNome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioDetalhe>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioDetalhe>()
                .Property(e => e.Endereco)
                .IsUnicode(false);
        }
    }
}
