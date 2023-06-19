using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroAtletaApi.Models;

namespace CadastroAtletaApi.DAOs
{
    public class AtletaRecordDAO : AutoDAO<AtletaRecord>
    {
        protected override string Tabela => "atleta_record";

        protected override string? NomeCampoIdMestre => "IdAtleta";
    }
}