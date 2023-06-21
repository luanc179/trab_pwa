using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroLivroApi.Models;

namespace CadastroLivroApi.DAOs
{
    public class LivroAutoresDAO : AutoDAO<LivroAutores>
    {
        protected override string Tabela => "livro_autores";

        protected override string? TituloCampoIdMestre => "IdLivro";
    }
}