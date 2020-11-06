using EasyDescriptionProvider.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDescriptionProvider.Repos
{
    public  class RequisicaoRepo
    {

        XMLRepo xmlrepo;

        public RequisicaoRepo(XMLRepo repo)
        {
            xmlrepo = repo;
        }

        /// <summary>
        /// Cria / Atualiza um Requisicao
        /// </summary>
        /// <param name="requisicao"></param>
        public  void SalvarRequisicao(Requisicao requisicao)
        {

            try
            {
                xmlrepo.SalvarRequisicao(requisicao);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Retorna os Requisições persistidas.
        /// </summary>
        /// <returns>IList<Requisicao></returns>
        public  IList<Requisicao> ListarRequisicaos()
        {
            IList<Requisicao> requisicoes = new List<Requisicao>();
            try
            {
                requisicoes = xmlrepo.ListarRequisicoes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requisicoes;
        }

        /// <summary>
        /// Retorna os Requisições persistidas.
        /// </summary>
        /// <returns>IList<Requisicao></returns>
        public  IList<Requisicao> ListarRequisicoesPorTipo(int idTipo)
        {
            IList<Requisicao> requisicoes = new List<Requisicao>();
            try
            {
                requisicoes = xmlrepo.ListarRequisicoesPorTipo(idTipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requisicoes;
        }

        /// <summary>
        /// Retorna uma Requisição selecionada.
        /// </summary>
        /// <returns>IList<TipoRequisicao></returns>
        public  Requisicao ObterRequisicao(int idRequisicao)
        {
            Requisicao requisicao = new Requisicao();
            try
            {
                requisicao = xmlrepo.ObterRequisicao(idRequisicao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return requisicao;
        }

        public void ExlcuirRequisicao(Requisicao req) 
        {
            try
            {
                xmlrepo.ExcluirRequisicao(req);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
