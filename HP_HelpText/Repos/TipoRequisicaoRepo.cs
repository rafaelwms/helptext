using EasyDescriptionProvider.Models;
using System;
using System.Collections.Generic;
using System.Data;


namespace EasyDescriptionProvider.Repos
{
    public class TipoRequisicaoRepo
    {

        XMLRepo xmlrepo;

        public TipoRequisicaoRepo(XMLRepo repo)
        {
            xmlrepo = repo;
        }

        /// <summary>
        /// Cria / Atualiza um Tipo de Requisição
        /// </summary>
        /// <param name="tipo"></param>
        public  void SalvarTipoRequisicao(TipoRequisicao tipo)
        {

            try
            {
                xmlrepo.SalvarTipoRequisicao(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Retorna os Tipos de Requisição existentes.
        /// </summary>
        /// <returns>IList<TipoRequisicao></returns>
        public IList<TipoRequisicao> ListarTiposRequisicao() 
        {
            IList<TipoRequisicao> tiposRequisicao = new List<TipoRequisicao>();
            try
            {
                tiposRequisicao = xmlrepo.ListarTiposRequisicao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tiposRequisicao;
        }

        public TipoRequisicao ObterTipoRequisicao(int id)
        {
            TipoRequisicao tipo = new TipoRequisicao();
            try
            {
                tipo = xmlrepo.ObterTipoRequisicao(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tipo;
        }

        public void ExcluirTipoRequisicao(TipoRequisicao tipo) 
        {
            try
            {
                xmlrepo.ExcluirTipoRequisicao(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
