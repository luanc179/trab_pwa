using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroLivroApi.DAOs;
using CadastroLivroApi.Models;
using CadastroLivroDll.DOs;

namespace CadastroLivroApi.Controllers.Extensoes
{
    public static class EntensoesModelDO
    {
        public static LivroDO ToDO(this Livro obj)
        {
            return new LivroDO
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Autor = obj.Autor,
                Genero = obj.Genero
            };
        }

        public static IList<LivroDO> ToDO(this IList<Livro> listaModels)
        {
            var lista = new List<LivroDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }
        
        public static async Task<Livro> ToModel(this LivroDO objDO)
        {
            Livro? obj = null;

            if (objDO.Id != null)
            {
                var dao = new LivroDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new Livro();

            obj.Nome = objDO.Nome;
            obj.Autor = objDO.Autor;
            obj.Genero = objDO.Genero;

            return obj;
        }

        public static async Task<IList<Livro>> ToModel(this IList<LivroDO> listaDO)
        {
            var lista = new List<Livro>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }

    }
}
