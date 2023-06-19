using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAtletaApi.Models
{
    public class Atleta : BaseModel
    {
        public string Nome { get; set; } = "";

        public double Altura { get; set; }

        public double Peso { get; set; }
    }
}