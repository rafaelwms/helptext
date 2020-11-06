using EasyDescriptionProvider.Models;
using EasyDescriptionProvider.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDescriptionProvider
{
    public partial class ConsultaForm : Form
    {
        XMLRepo XMLRepo;
        public TipoRequisicaoRepo TipoRepo { get; set; }
        public AmbienteRepo AmbiRepo { get; set; }
        public RequisicaoRepo ReqRepo { get; set; }

        public string PastaArquivo { get; set; }

        public ConsultaForm()
        {
            XMLRepo = new XMLRepo();
            if (!string.IsNullOrEmpty(XMLRepo.DirData.FullName)) 
            {
                PastaArquivo = XMLRepo.DirData.FullName;                
            }
            TipoRepo = new TipoRequisicaoRepo(XMLRepo);
            ReqRepo = new RequisicaoRepo(XMLRepo);
            AmbiRepo = new AmbienteRepo(XMLRepo);
            InitializeComponent();
            textBox1.Text = PastaArquivo;
            cbTipoRequisicao.DisplayMember = "Nome";
            cbTipoRequisicao.ValueMember = "Id";
            cbAmbiente.DisplayMember = "Nome";
            cbAmbiente.ValueMember = "Id";
            PreencherComboTipoRequisicao();
            PreencherComboAmbiente();
            PreencherRequisicoes();
        }
        private IList<Ambiente> ambientes = new List<Ambiente>();
        IList<TipoRequisicao> tipos = new List<TipoRequisicao>();

        public void AtualizarTodosOsCampos() 
        {
            PreencherComboTipoRequisicao();
            PreencherComboAmbiente();
            PreencherRequisicoes();
        }

        private void PreencherComboTipoRequisicao() 
        {
            try
            {
                tipos = new List<TipoRequisicao>();
                tipos.Add(new TipoRequisicao() { Id = 0, Nome = "Tipo de Requisição" });

                foreach (TipoRequisicao tipo in TipoRepo.ListarTiposRequisicao())
                {
                    tipos.Add(tipo);
                }
                cbTipoRequisicao.DataSource = tipos;
  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherComboAmbiente()
        {
            try
            {

                ambientes = new List<Ambiente>();
                ambientes.Add(new Ambiente() { Id = 0, Nome = "Ambiente" });
                foreach (Ambiente ambiente in AmbiRepo.ListarAmbientes())
                {
                    ambientes.Add(ambiente);
                }
                cbAmbiente.DataSource = ambientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherRequisicoes()
        {
            try
            {

                lvRequisicoes.Items.Clear();
                IList<Requisicao> requisicoes = ReqRepo.ListarRequisicaos();

                int idTipoRequisicao = 0;
                if (cbTipoRequisicao.Items.Count > 0 && cbTipoRequisicao.SelectedIndex > 0)
                {
                    int.TryParse(cbTipoRequisicao.SelectedValue.ToString(), out idTipoRequisicao);
                }
                if (idTipoRequisicao > 0)
                {
                    requisicoes = requisicoes.Where(req => req.Tipo.Id == idTipoRequisicao).ToList();
                }
                foreach (Requisicao requisicao in requisicoes)
                {
                    lvRequisicoes.Items.Add(requisicao.Id.ToString()).SubItems.AddRange(new string[] { requisicao.Nome });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarDescricao()
        {
            try
            {
                string texto = string.Empty;
                int idRequisicao = 0;
                int idAmbiente = 0;
                if ((lvRequisicoes.Items.Count > 0  &&  lvRequisicoes.SelectedItems.Count > 0) && cbAmbiente.Items.Count > 0)
                {

                    int.TryParse(lvRequisicoes.SelectedItems[0].Text, out idRequisicao);
                    int.TryParse(cbAmbiente.SelectedValue.ToString(), out idAmbiente);
                }
                if (idRequisicao > 0)
                {
                    Requisicao req = ReqRepo.ObterRequisicao(idRequisicao);
                    texto = req.Descricao;
                }
                if (idAmbiente > 0)
                {
                    Ambiente amb = AmbiRepo.ObterAmbiente(idAmbiente);
                    if (texto.Contains("@ambiente"))
                    {
                        texto = texto.Replace("@ambiente", amb.Nome);
                    }
                    if (texto.Contains("@instancias"))
                    {
                        texto = texto.Replace("@instancias", amb.Instancias);
                    }
                }
                txtDescricao.Text = texto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCopiarAreaTransf_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDescricao.Text);
        }

        private void cbTipoRequisicao_SelectedValueChanged(object sender, EventArgs e)
        {
            PreencherRequisicoes();
            AtualizarDescricao();
        }

        private void cbAmbiente_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizarDescricao();
        }

        private void lvRequisicoes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            AtualizarDescricao();
        }

        private void tipoDeRequisiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TipoRequisicaoForm(this).Show();            
        }

        private void ambienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AmbienteForm(this).Show();
        }

        private void requisiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RequisicaoForm(this).Show();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                var arquivoDados = new FileInfo(XMLRepo.FileString);
                if (arquivoDados.Exists) 
                {
                    DialogResult resultArq = MessageBox.Show("Deseja mover o arquivo base?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(DialogResult.Yes == resultArq) 
                    {
                        PastaArquivo = folderDialog.SelectedPath;
                        arquivoDados.MoveTo($@"{PastaArquivo}\hp_helptext_db.xml");
                        textBox1.Text = PastaArquivo;
                        XMLRepo.AlterarPastaRegistros(PastaArquivo);
                        XMLRepo = new XMLRepo();
                    }
                }

            }
        }
    }
}
