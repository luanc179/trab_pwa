using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroLivroDll.DOs
{
    public class LivroDO : BaseDO
    {

        [Required]
        [StringLength(100, ErrorMessage = "O nome do livro deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = "";
        
        [Required]
        [StringLength(100, ErrorMessage = "O nome do autor deve ter no máximo 100 caracteres.")]
        public string? Autor { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome do genero deve ter no máximo 100 caracteres.")]
        public string? Genero { get; set; }
    }
}
