using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroAtletaDll.DOs
{
    public class AtletaRecordDO : BaseDO
    {
        public string? IdAtleta { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A descrição do record deve ter no máximo 100 caracteres.")]
        public string? Descricao { get; set; }
        
        public DateTime Data { get; set; }
    }
}
