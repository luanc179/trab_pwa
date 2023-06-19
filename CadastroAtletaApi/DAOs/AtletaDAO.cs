using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroAtletaApi.Models;

namespace CadastroAtletaApi.DAOs
{
    public class AtletaDAO : AutoDAO<Atleta>
    {
        protected override string Tabela => "atleta";
    }
}