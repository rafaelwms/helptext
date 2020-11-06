using EasyDescriptionProvider.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace EasyDescriptionProvider.Repos
{
    public  class AmbienteRepo
    {
        XMLRepo xmlrepo;
        public AmbienteRepo(XMLRepo repo)
        {
            xmlrepo = repo;
        }
        /// <summary>
        /// Cria / Atualiza um Ambiente
        /// </summary>
        /// <param name="tipo"></param>
        public  void SalvarAmbiente(Ambiente tipo)
        {

            try
            {
                xmlrepo.SalvarAmbiente(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Retorna os Ambientes persistidos.
        /// </summary>
        /// <returns>IList<TipoRequisicao></returns>
        public  IList<Ambiente> ListarAmbientes()
        {
            IList<Ambiente> ambientes = new List<Ambiente>();
            try
            {
                ambientes = xmlrepo.ListarAmbientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ambientes;
        }

        /// <summary>
        /// Retorna um Ambiente persistidos pelo seu ID.
        /// </summary>
        /// <returns>IList<TipoRequisicao></returns>
        public  Ambiente ObterAmbiente(int idAmbiente)
        {
            Ambiente ambiente = new Ambiente();
            try
            {
                ambiente = xmlrepo.ObterAmbiente(idAmbiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ambiente;
        }

        public void ExcluirAmbiente(Ambiente ambiente) 
        {
            try
            {
                xmlrepo.ExcluirAmbiente(ambiente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
