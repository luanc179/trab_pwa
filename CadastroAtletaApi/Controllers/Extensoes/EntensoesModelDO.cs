using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroAtletaApi.DAOs;
using CadastroAtletaApi.Models;
using CadastroAtletaDll.DOs;

namespace CadastroAtletaApi.Controllers.Extensoes
{
    public static class EntensoesModelDO
    {
        public static AtletaDO ToDO(this Atleta obj)
        {
            return new AtletaDO
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Altura = obj.Altura,
                Peso = obj.Peso
            };
        }

        public static IList<AtletaDO> ToDO(this IList<Atleta> listaModels)
        {
            var lista = new List<AtletaDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }
        
        public static async Task<Atleta> ToModel(this AtletaDO objDO)
        {
            Atleta? obj = null;

            if (objDO.Id != null)
            {
                var dao = new AtletaDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new Atleta();

            obj.Nome = objDO.Nome;
            obj.Altura = objDO.Altura;
            obj.Peso = objDO.Peso;

            return obj;
        }

        public static async Task<IList<Atleta>> ToModel(this IList<AtletaDO> listaDO)
        {
            var lista = new List<Atleta>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }

        public static AtletaRecordDO ToDO(this AtletaRecord obj)
        {
            return new AtletaRecordDO
            {
                Id = obj.Id,
                IdAtleta = obj.IdAtleta,
                Data = obj.Data,
                Descricao = obj.Descricao
            };
        }

        public static IList<AtletaRecordDO> ToDO(this IList<AtletaRecord> listaModels)
        {
            var lista = new List<AtletaRecordDO>();

            foreach (var obj in listaModels)
                lista.Add(ToDO(obj));

            return lista;
        }

        public static async Task<AtletaRecord> ToModel(this AtletaRecordDO objDO)
        {
            AtletaRecord? obj = null;

            if (objDO.Id != null)
            {
                var dao = new AtletaRecordDAO();
                obj = await dao.RetornarPorIdAsync(objDO.Id);
            }

            if (obj == null)
                obj = new AtletaRecord();

            obj.IdAtleta = objDO.IdAtleta;
            obj.Data = objDO.Data;
            obj.Descricao = objDO.Descricao ?? "";

            return obj;
        }

        public static async Task<IList<AtletaRecord>> ToModel(this IList<AtletaRecordDO> listaDO)
        {
            var lista = new List<AtletaRecord>();

            foreach (var obj in listaDO)
                lista.Add(await ToModel(obj));

            return lista;
        }
    }
}
