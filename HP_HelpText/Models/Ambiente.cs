using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDescriptionProvider.Models
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Instancias { get; set; }

        public Ambiente()
        {

        }

        public Ambiente(DataRow row)
        {
            this.Id = int.Parse(row["ID"].ToString());
            this.Nome = row["NOME"].ToString();
            this.Instancias = row["INSTANCIAS"].ToString();
        }
    }
}
