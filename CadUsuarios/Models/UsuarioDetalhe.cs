namespace CadUsuarios.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioDetalhe")]
    public partial class UsuarioDetalhe
    {
        [Key]
        public int IdUsuarioDetalhe { get; set; }

        public int? IdUsuario { get; set; }

        [StringLength(50)]
        public string Telefone { get; set; }

        [StringLength(500)]
        public string Endereco { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
