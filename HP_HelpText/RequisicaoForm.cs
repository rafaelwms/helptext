using EasyDescriptionProvider.Models;
using EasyDescriptionProvider.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDescriptionProvider
{
    public partial class RequisicaoForm : Form
    {
        public RequisicaoForm()
        {
            InitializeComponent();
            PreencherComboTipoRequisicao();
            ExibirRequisicoes();
        }

        public RequisicaoForm(ConsultaForm consultaForm)
        {
            this.FormPrincipal = consultaForm;
            InitializeComponent();
            PreencherComboTipoRequisicao();
            ExibirRequisicoes();
        }


        private ConsultaForm FormPrincipal;

        private void PreencherComboTipoRequisicao() 
        {
          
            try
            {

                IList<TipoRequisicao> tipos = new List<TipoRequisicao>();
                tipos.Add(new TipoRequisicao() { Id = 0, Nome = "Tipos de Requisição" });
                foreach(TipoRequisicao tipo in FormPrincipal.TipoRepo.ListarTiposRequisicao())
                {
                    tipos.Add(tipo);
                }
                cbTipoRequisicao.Items.Clear();
                cbTipoRequisicao.DataSource = tipos;
                cbTipoRequisicao.DisplayMember = "Nome";
                cbTipoRequisicao.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ExibirRequisicoes() 
        {
            try
            {

                lvRequisicoes.Items.Clear();
                IList<Requisicao> requisicoes = FormPrincipal.ReqRepo.ListarRequisicaos();
                int idTipoRequisicao = int.Parse(cbTipoRequisicao.SelectedValue.ToString());
                if (idTipoRequisicao > 0) 
                {
                    requisicoes = requisicoes.Where(req => req.Tipo.Id == idTipoRequisicao).ToList();
                }
                foreach(Requisicao requisicao in requisicoes) 
                {
                    lvRequisicoes.Items.Add(requisicao.Id.ToString()).SubItems.AddRange(new string[] { requisicao.Tipo.Nome, requisicao.Nome});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos() 
        {
            txtDescricao.Text =
            txtNome.Text = string.Empty;
        }

        private void SalvarRequisicao() 
        {
            try
            {

                Requisicao requisicao = new Requisicao();
                if(lvRequisicoes.SelectedItems.Count > 0) 
                {
                    requisicao.Id = int.Parse(lvRequisicoes.SelectedItems[0].Text);
                }
                int idTipoRequisicao = int.Parse(cbTipoRequisicao.SelectedValue.ToString());
                if(idTipoRequisicao <= 0) 
                {
                    MessageBox.Show("É Necessário escolher um Tipo de Requisição.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbTipoRequisicao.Focus();
                    return;
                }
                requisicao.Tipo = new TipoRequisicao();
                requisicao.Tipo.Id = idTipoRequisicao;
                requisicao.Nome = txtNome.Text;
                requisicao.Descricao = txtDescricao.Text;
                FormPrincipal.ReqRepo.SalvarRequisicao(requisicao);
                MessageBox.Show($@"Requisição '{requisicao.Nome}' salva com Êxito.", "SALVAR REQUISIÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExibirRequisicoes();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarRequisicao();
        }

        private void lvRequisicoes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                int id = 0;
                if (lvRequisicoes.Items.Count > 0 && lvRequisicoes.SelectedItems.Count > 0)
                {
                    int.TryParse(lvRequisicoes.SelectedItems[0].Text, out id);
                    Requisicao requisicao = FormPrincipal.ReqRepo.ObterRequisicao(id);
                    txtDescricao.Text = requisicao.Descricao;
                    txtNome.Text = requisicao.Nome;
                    cbTipoRequisicao.SelectedValue = requisicao.Tipo.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RequisicaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            FormPrincipal.AtualizarTodosOsCampos();
            FormPrincipal.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RequisicaoForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void RequisicaoForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ExcluirRequisicao();

            }
        }

        private void ExcluirRequisicao()
        {
            int id = 0;
            if (lvRequisicoes.Items.Count > 0 && lvRequisicoes.SelectedItems.Count > 0)
            {
                int.TryParse(lvRequisicoes.SelectedItems[0].Text, out id);
                Requisicao requisicao = FormPrincipal.ReqRepo.ObterRequisicao(id);

                DialogResult decisao = MessageBox.Show($"Deseja remover a Requisição abaixo?\n{requisicao.Nome}", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (decisao == DialogResult.OK)
                {
                    FormPrincipal.ReqRepo.ExlcuirRequisicao(requisicao);
                    MessageBox.Show($"Requisição exlcuída com sucesso.", "AÇÃO CONCLUÍDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    ExibirRequisicoes();
                }

            }
        }

        private void RequisicaoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) 
            {
                ExcluirRequisicao();
            }
        }

        private void lvRequisicoes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lvRequisicoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ExcluirRequisicao();
            }
        }
    }
}
