namespace CadUsuarios.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            UsuarioDetalhes = new HashSet<UsuarioDetalhe>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [StringLength(255)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string SobreNome { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioDetalhe> UsuarioDetalhes { get; set; }
    }
}
