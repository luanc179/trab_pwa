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
                Titulo = obj.Titulo,
                Genero = obj.Genero,
                Valor = obj.Valor
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

            obj.Titulo = objDO.Titulo;
            obj.Genero = objDO.Genero;
            obj.Valor = objDO.Valor;

            return obj;
        }

        public static async Task<IList<Livro>> ToModel(this IList<LivroDO> listaDO)
        {
            var lista = new List<Livro>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }

        public static LivroAutoresDO ToDO(this LivroAutores obj)
        {
            return new LivroAutoresDO
            {
                Id = obj.Id,
                IdLivro = obj.IdLivro,
                Nome = obj.Nome,
                Sobrenome = obj.Sobrenome
            };
        }

        public static IList<LivroAutoresDO> ToDO(this IList<LivroAutores> listaModels)
        {
            var lista = new List<LivroAutoresDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }

        public static async Task<LivroAutores> ToModel(this LivroAutoresDO objDO)
        {
            LivroAutores? obj = null;

            if (objDO.Id != null)
            {
                var dao = new LivroAutoresDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new LivroAutores();

            obj.IdLivro = objDO.IdLivro;
            obj.Nome = objDO.Nome;
            obj.Sobrenome = objDO.Sobrenome ?? "";

            return obj;
        }

        public static async Task<IList<LivroAutores>> ToModel(this IList<LivroAutoresDO> listaDO)
        {
            var lista = new List<LivroAutores>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }
    }
}
