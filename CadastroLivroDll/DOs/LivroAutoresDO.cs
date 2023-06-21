using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroLivroDll.DOs
{
    public class LivroAutoresDO : BaseDO
    {
        public string? IdLivro { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O sobrenome deve ter no máximo 100 caracteres.")]
        public string? Sobrenome { get; set; }
        
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = "";
    }
}
