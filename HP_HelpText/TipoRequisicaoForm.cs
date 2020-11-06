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
    public partial class TipoRequisicaoForm : Form
    {


        public TipoRequisicaoForm()
        {
            InitializeComponent();
            PreencherTiposRequisicao();
            lvTipoRequisicao.Columns[1].Width = 300;
        }

        private ConsultaForm FormPrincipal;

        public TipoRequisicaoForm(ConsultaForm formPrincipal)
        {
            this.FormPrincipal = formPrincipal;
            InitializeComponent();
            PreencherTiposRequisicao();
            lvTipoRequisicao.Columns[1].Width = 300;
        }

        private void PreencherTiposRequisicao() 
        {
            try
            {
                IList<TipoRequisicao> tipos = FormPrincipal.TipoRepo.ListarTiposRequisicao();
                lvTipoRequisicao.Items.Clear();
                foreach(TipoRequisicao tipo in tipos)
                {
                    lvTipoRequisicao.Items.Add(tipo.Id.ToString()).SubItems.AddRange(new string[] { tipo.Nome });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimparCamposTexto()
        {
            txtNomeTipoRequisicao.Text = string.Empty;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoRequisicao tipo = new TipoRequisicao();
                if (lvTipoRequisicao.SelectedItems.Count > 0) 
                {
                    tipo.Id = int.Parse(lvTipoRequisicao.SelectedItems[0].Text);
                }
                tipo.Nome = txtNomeTipoRequisicao.Text;
                FormPrincipal.TipoRepo.SalvarTipoRequisicao(tipo);
                MessageBox.Show($@"Tipo Requisição '{tipo.Nome}' salvo com Êxito.", "SALVAR TIPO REQUISIÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PreencherTiposRequisicao();
                LimparCamposTexto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvTipoRequisicao_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtNomeTipoRequisicao.Text = e.Item.SubItems[1].Text;
        }

        private void TipoRequisicaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.AtualizarTodosOsCampos();
            FormPrincipal.Show();
        }

        private void TipoRequisicaoForm_Load(object sender, EventArgs e)
        {

        }

        private void lvTipoRequisicao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) 
            {
                ExcluirTipoRequisicao();
            }
        }

        private void ExcluirTipoRequisicao() 
        {
            int id = 0;
            if (lvTipoRequisicao.Items.Count > 0 && lvTipoRequisicao.SelectedItems.Count > 0)
            {
                int.TryParse(lvTipoRequisicao.SelectedItems[0].Text, out id);
                TipoRequisicao tipo = FormPrincipal.TipoRepo.ObterTipoRequisicao(id);
                IList<Requisicao> requisicoes = FormPrincipal.ReqRepo.ListarRequisicoesPorTipo(id);
                string nomesReq = string.Empty;
                if (requisicoes != null && requisicoes.Count > 0)
                {
                    foreach (Requisicao rq in requisicoes)
                    {
                        nomesReq += $"\n{rq.Nome}";
                    }
                    DialogResult exclusao = MessageBox.Show($"O Tipo de Requisição está vinculado as seguintes Requisições abaixo:{nomesReq}\n" +
                        $"DESEJA REALMENTE EXCLUIR AS REQUISIÇÕES ACIMA, MAIS O TIPO: {tipo.Nome}??", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (exclusao == DialogResult.OK)
                    {
                        ExcluirRequisicoes(requisicoes.ToList());
                        ExcluirTipoRequisicao(tipo);
                        MessageBox.Show($"Tipo de Requisição e Requisições dependentes exlcuídos com sucesso.", "AÇÃO CONCLUÍDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCamposTexto();
                        PreencherTiposRequisicao();
                    }
                }
                else
                {
                    DialogResult decisao = MessageBox.Show($"Deseja remover o Tipo de Requisição abaixo?\n{tipo.Nome}", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (decisao == DialogResult.OK)
                    {
                        ExcluirTipoRequisicao(tipo);
                        MessageBox.Show($"Tipo de Requisição exlcuído com sucesso.", "AÇÃO CONCLUÍDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCamposTexto();
                        PreencherTiposRequisicao();
                    }
                }
            }

        }

        private void ExcluirTipoRequisicao(TipoRequisicao tipo) 
        {
            FormPrincipal.TipoRepo.ExcluirTipoRequisicao(tipo);
        }

        private void ExcluirRequisicoes(List<Requisicao> lista) 
        {
            foreach (Requisicao rq in lista)
            {
                FormPrincipal.ReqRepo.ExlcuirRequisicao(rq);
            }
        }

    }
}
