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
        [StringLength(100, ErrorMessage = "O titulo deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = "";
        
        [StringLength(100, ErrorMessage = "O genero deve ter no máximo 100 caracteres.")]
        public string? Genero { get; set; }

        [Range(20, 500,
        ErrorMessage = "O valor deve estar entre 20 e 500.")]
        public double Valor { get; set; }
    }
}
