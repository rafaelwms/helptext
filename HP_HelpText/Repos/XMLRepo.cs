using EasyDescriptionProvider.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDescriptionProvider.Repos
{
    public class XMLRepo
    {

        private static string TB_TIPO_REQ = "TB_TP_REQUISICAO";
        private static string TB_REQUISICAO = "TB_REQUISICAO";
        private static string TB_AMBIENTE = "TB_AMBIENTE";
        private static string TB_CONFIG = "TB_CONFIG";

        DataSet schemaXML = new DataSet();
        DataSet configXML = new DataSet();
        public DirectoryInfo DirData { get; set; }
        public string FileString { get; set; }
        public DataTable tbTipoRequisicao;
        public DataTable tbRequisicao;
        public DataTable tbAmbiente;

        private string configFileXML = $@"{Application.StartupPath}\config.xml";

        public XMLRepo()
        {
            var config = new FileInfo(configFileXML);
            if (!config.Exists)
            {
                IniciarArquivoConfig();
                ConfigLoader(Application.StartupPath);
            }
            else
            {
                configXML.ReadXml(configFileXML, XmlReadMode.ReadSchema);
                DataRow row = configXML.Tables["TB_CONFIG"].Select("FolderId = 1").FirstOrDefault();
                string pasta = row["FolderPath"].ToString();
                if (!string.IsNullOrEmpty(pasta))
                {
                    ConfigLoader(pasta);
                }
            }

        }


        /// <summary>
        /// Inicia o arquivo de Configuração
        /// </summary>
        private void IniciarArquivoConfig()
        {
            configXML = new DataSet();
            configXML.DataSetName = "FileConfigurator";
            configXML.Tables.Add(TB_CONFIG);
            DataTable table = configXML.Tables[TB_CONFIG];
            table.Columns.Add("FolderId");
            table.Columns.Add("FolderPath");
            table.Rows.Add("1", Application.StartupPath);
            salvarConfigXML();
        }


        /// <summary>
        /// Construtor responsável pelas inicializações das variáveis de diretório, arquivo e nome do Schema do DataSet XML
        /// </summary>
        /// <param name="diretorio"></param>
        public XMLRepo(string diretorio)
        {
            ConfigLoader(diretorio);
        }

        private void ConfigLoader(string diretorio)
        {
            schemaXML.DataSetName = "XMLDataBase";
            DirData = new DirectoryInfo($@"{diretorio}");
            FileString = $@"{DirData.FullName}\hp_helptext_db.xml";
            CertificarDiretorioArquivo();
            CarregarDataTables();
        }

        /// <summary>
        /// Método responsável por carregar as DataTable
        /// </summary>
        private void CarregarDataTables()
        {
            if (schemaXML != null && schemaXML.Tables.Count == 3)
            {
                tbTipoRequisicao = schemaXML.Tables[TB_TIPO_REQ];
                tbRequisicao = schemaXML.Tables[TB_REQUISICAO];
                tbAmbiente = schemaXML.Tables[TB_AMBIENTE];
            }
        }

        /// <summary>
        /// Verifica existência "Física" do Diretório e Arquivos para armazenamento de dados, caso não existam, ele cria.
        /// </summary>
        private void CertificarDiretorioArquivo()
        {
            if (!DirData.Exists)
            {
                DirData.Create();
            }
            var fileData = new FileInfo(FileString);
            if (!fileData.Exists)
            {
                IniciarArquivo();
            }
            else
            {
                schemaXML.ReadXml(FileString, XmlReadMode.ReadSchema);
            }

        }

        /// <summary>
        /// Inicia o arquivo de Base de Dados.
        /// </summary>
        private void IniciarArquivo()
        {
            schemaXML = new DataSet();
            schemaXML.DataSetName = "XMLDataBase";
            MontarDataTable(TB_TIPO_REQ, new string[] { "ID", "NOME" });
            MontarDataTable(TB_REQUISICAO, new string[] { "ID", "NOME", "DESCRICAO", "ID_TIPO" });
            MontarDataTable(TB_AMBIENTE, new string[] { "ID", "NOME", "INSTANCIAS" });
            salvarXML();
        }
        /// <summary>
        /// Responsável pela montagem das estruturas de DataTable no DataSet
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="colunas"></param>
        private void MontarDataTable(string tableName, string[] colunas)
        {
            schemaXML.Tables.Add(tableName);
            foreach (string coluna in colunas)
            {
                schemaXML.Tables[tableName].Columns.Add(coluna);
            }
        }

        /// <summary>
        /// Configura a pasta de registros.
        /// </summary>
        /// <param name="pasta"></param>
        public void AlterarPastaRegistros(string pasta)
        {
            DataRow row = configXML.Tables["TB_CONFIG"].Select("FolderId = 1").FirstOrDefault();
            row["FolderPath"] = pasta;
            salvarConfigXML();
        }

        /// <summary>
        /// Escreve as modificações no arquivo XML
        /// </summary>
        /// 
        public void salvarConfigXML()
        {
            configXML.WriteXml(configFileXML, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// Escreve as modificações no arquivo XML
        /// </summary>
        /// 
        public void salvarXML()
        {
            schemaXML.WriteXml(FileString, XmlWriteMode.WriteSchema);
        }


        /// <summary>
        /// Exlcui um registro de uma DataTable através de um ID específico.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        public void ExcluirRegistroPorId(DataTable table, int id)
        {
            DataRow row = ObterRegistro(table, id);
            if (row != null)
            {
                table.Rows.Remove(row);
            }
            salvarXML();
        }

        private DataRow ObterRegistro(DataTable table, int id)
        {
            DataRow row = table.Select($@"ID = {id}").FirstOrDefault();
            return row;
        }

        /// <summary>
        /// Obtém o próximo valor em uma primarykey
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private int GerarPrimaryKeyXML(DataTable table)
        {
            int novaPK = 0;
            foreach (DataRow row in table.Rows)
            {
                int idRow = int.Parse(row["ID"].ToString());
                if (idRow > novaPK)
                {
                    novaPK = idRow;
                }
            }
            novaPK += 1;
            return novaPK;
        }

        #region TIPO REQUISIÇÃO
        /// <summary>
        /// Salva no XML o referido Tipo de Requisição, seja um novo ou atualizar um já existente.
        /// </summary>
        /// 
        public void SalvarTipoRequisicao(TipoRequisicao tipoReq)
        {
            if (tipoReq.Id == 0)
            {
                tipoReq.Id = GerarPrimaryKeyXML(tbTipoRequisicao);
                tbTipoRequisicao.Rows.Add(tipoReq.Id.ToString(), tipoReq.Nome);
            }
            else
            {
                DataRow row = ObterRegistro(tbTipoRequisicao, tipoReq.Id);
                if (row != null)
                {
                    row["NOME"] = tipoReq.Nome;
                }
            }
            salvarXML();
        }

        /// <summary>
        /// Obter os Tipos de Requisições persistidos
        /// </summary>
        /// <returns></returns>
        public IList<TipoRequisicao> ListarTiposRequisicao()
        {
            IList<TipoRequisicao> lista = new List<TipoRequisicao>();
            foreach (DataRow row in tbTipoRequisicao.Rows)
            {
                lista.Add(new TipoRequisicao(row));
            }
            return lista;
        }

        /// <summary>
        /// Obter um Tipo de Requisição persistido
        /// </summary>
        /// <returns></returns>
        public TipoRequisicao ObterTipoRequisicao(int id)
        {
            TipoRequisicao tipo = null;
            DataRow row = tbTipoRequisicao.Select($@"ID = {id}").FirstOrDefault();
            if (row != null)
            {
                tipo = new TipoRequisicao(row);
            }
            return tipo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoReq"></param>
        public void ExcluirTipoRequisicao(TipoRequisicao tipoReq)
        {
            ExcluirRegistroPorId(tbTipoRequisicao, tipoReq.Id);
        }
        #endregion

        #region REQUISIÇÃO
        /// <summary>
        /// Salva no XML a referida  Requisição, seja uma nova ou atualizar uma já existente.
        /// </summary>
        /// 
        public void SalvarRequisicao(Requisicao requisicao)
        {
            if (requisicao.Id == 0)
            {
                requisicao.Id = GerarPrimaryKeyXML(tbRequisicao);
                tbRequisicao.Rows.Add(requisicao.Id.ToString(), requisicao.Nome, requisicao.Descricao, requisicao.Tipo.Id.ToString());
            }
            else
            {
                DataRow row = ObterRegistro(tbRequisicao, requisicao.Id);
                if (row != null)
                {
                    row["NOME"] = requisicao.Nome;
                    row["DESCRICAO"] = requisicao.Descricao;
                    row["ID_TIPO"] = requisicao.Tipo.Id.ToString();
                }
            }
            salvarXML();
        }

        /// <summary>
        /// Obter as Requisições persistidas
        /// </summary>
        /// <returns></returns>
        public IList<Requisicao> ListarRequisicoes()
        {
            IList<Requisicao> lista = new List<Requisicao>();
            foreach (DataRow row in tbRequisicao.Rows)
            {
                Requisicao req = new Requisicao(row);
                req.Tipo = ObterTipoRequisicao(req.Tipo.Id);
                lista.Add(req);
            }
            return lista;
        }

        /// <summary>
        /// Obter as Requisições persistidas filtradas pelo seu tipo
        /// </summary>
        /// <returns></returns>
        public IList<Requisicao> ListarRequisicoesPorTipo(int idTipo)
        {
            TipoRequisicao tipo = ObterTipoRequisicao(idTipo);
            IList<Requisicao> lista = new List<Requisicao>();
            foreach (DataRow row in tbRequisicao.Select($"ID_TIPO = {idTipo}"))
            {
                Requisicao req = new Requisicao(row);
                req.Tipo = tipo;
                lista.Add(req);
            }
            return lista;
        }

        /// <summary>
        /// Obtém a Requisicao pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Requisicao ObterRequisicao(int id)
        {
            Requisicao req = new Requisicao();
            DataRow row = tbRequisicao.Select($"ID = {id}").FirstOrDefault();
            if (row != null)
            {
                req = new Requisicao(row);
                req.Tipo = ObterTipoRequisicao(req.Tipo.Id);
            }
            return req;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requisicao"></param>
        public void ExcluirRequisicao(Requisicao requisicao)
        {
            ExcluirRegistroPorId(tbRequisicao, requisicao.Id);
        }
        #endregion

        #region AMBIENTES
        /// <summary>
        /// Salva no XML a referida  Requisição, seja uma nova ou atualizar uma já existente.
        /// </summary>
        /// 
        public void SalvarAmbiente(Ambiente ambiente)
        {
            if (ambiente.Id == 0)
            {
                ambiente.Id = GerarPrimaryKeyXML(tbAmbiente);
                tbAmbiente.Rows.Add(ambiente.Id.ToString(), ambiente.Nome, ambiente.Instancias);
            }
            else
            {
                DataRow row = ObterRegistro(tbAmbiente, ambiente.Id);
                if (row != null)
                {
                    row["NOME"] = ambiente.Nome;
                    row["INSTANCIAS"] = ambiente.Instancias;
                }
            }
            salvarXML();
        }

        /// <summary>
        /// Obter as Requisições persistidas
        /// </summary>
        /// <returns></returns>
        public IList<Ambiente> ListarAmbientes()
        {
            IList<Ambiente> lista = new List<Ambiente>();
            foreach (DataRow row in tbAmbiente.Rows)
            {
                lista.Add(new Ambiente(row));
            }
            return lista;
        }

        /// <summary>
        /// Obtem Ambiente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ambiente ObterAmbiente(int id)
        {
            Ambiente amb = new Ambiente();
            DataRow row = tbAmbiente.Select($"ID = {id}").FirstOrDefault();
            if (row != null)
            {
                amb = new Ambiente(row);
            }
            return amb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requisicao"></param>
        public void ExcluirAmbiente(Ambiente ambiente)
        {
            ExcluirRegistroPorId(tbAmbiente, ambiente.Id);
        }
        #endregion


    }
}
