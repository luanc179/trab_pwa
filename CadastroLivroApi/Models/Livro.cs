using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroLivroApi.Models
{
    public class Livro : BaseModel
    {
        public string Titulo { get; set; } = "";

        public string? Genero { get; set; }

        public double Valor { get; set; }
    }
}