using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroAtletaDll.DOs
{
    public class AtletaDO : BaseDO
    {

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = "";
        
        [Range(0.9, 3.0,
        ErrorMessage = "A altura deve estar entre 0,9 e 3 metros.")]
        public double Altura { get; set; }

        [Range(20, 500,
        ErrorMessage = "O peso deve estar entre 20 e 500Kg.")]
        public double Peso { get; set; }
    }
}
