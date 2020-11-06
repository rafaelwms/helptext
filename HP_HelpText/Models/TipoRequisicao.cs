using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDescriptionProvider.Models
{
    public class TipoRequisicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public TipoRequisicao(DataRow dataRow) 
        {
            this.Id = int.Parse(dataRow["ID"].ToString());
            this.Nome = dataRow["NOME"].ToString();
        }

        public TipoRequisicao()
        {

        }

    }
}
