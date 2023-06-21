using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroLivroApi.Models;

namespace CadastroLivroApi.DAOs
{
    public class LivroDAO : AutoDAO<Livro>
    {
        protected override string Tabela => "livro";
    }
}