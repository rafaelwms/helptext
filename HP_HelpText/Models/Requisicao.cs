using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDescriptionProvider.Models
{
    public class Requisicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoRequisicao Tipo { get; set; }
        public Requisicao() { }

        public Requisicao(int id, string nome, string descricao, TipoRequisicao tipo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Tipo = tipo;
        }

        public Requisicao(DataRow row) 
        {
            this.Id = int.Parse(row["ID"].ToString());
            this.Nome = row["NOME"].ToString();
            this.Descricao = row["DESCRICAO"].ToString();
            this.Tipo = new TipoRequisicao();
            this.Tipo.Id = int.Parse(row["ID_TIPO"].ToString());
        }
    }
}
