using EasyDescriptionProvider.Models;
using EasyDescriptionProvider.Repos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyDescriptionProvider
{
    public partial class AmbienteForm : Form
    {
        public AmbienteForm()
        {
            InitializeComponent();
            PreencherAmbientes();
        }

        public AmbienteForm(ConsultaForm consultaForm)
        {
            this.FormPrincipal = consultaForm;
            InitializeComponent();
            PreencherAmbientes();
        }

        private ConsultaForm FormPrincipal;

        private void PreencherAmbientes()
        {
            try
            {
                IList<Ambiente> ambientes = FormPrincipal.AmbiRepo.ListarAmbientes();
                lvAmbientes.Items.Clear();
                foreach (Ambiente ambiente in ambientes)
                {
                    lvAmbientes.Items.Add(ambiente.Id.ToString()).SubItems.AddRange(new string[] { ambiente.Nome, ambiente.Instancias });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LimparCamposTexto()
        {
            txtNomeAmbiente.Text =
            txtEndereco.Text = string.Empty;
        }

        private void lvTipoRequisicao_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtNomeAmbiente.Text = e.Item.SubItems[1].Text;
            txtEndereco.Text = e.Item.SubItems[2].Text;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Ambiente tipo = new Ambiente();
                if (lvAmbientes.SelectedItems.Count > 0)
                {
                    tipo.Id = int.Parse(lvAmbientes.SelectedItems[0].Text);
                }
                tipo.Nome = txtNomeAmbiente.Text;
                tipo.Instancias = txtEndereco.Text;
                FormPrincipal.AmbiRepo.SalvarAmbiente(tipo);
                MessageBox.Show($@"Ambiente '{tipo.Nome}' salvo com Êxito.", "SALVAR AMBIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PreencherAmbientes();
                LimparCamposTexto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AmbienteForm_Load(object sender, EventArgs e)
        {

        }

        private void AmbienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            FormPrincipal.AtualizarTodosOsCampos();
            FormPrincipal.Show();
        }

        private void lvAmbientes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) 
            {
                ExcluirAmbiente();
            }
        }

        private void ExcluirAmbiente() 
        {
            int id = 0;
            if(lvAmbientes.Items.Count > 0 && lvAmbientes.SelectedItems.Count > 0) 
            {
                int.TryParse(lvAmbientes.SelectedItems[0].Text, out id);
                Ambiente amb = FormPrincipal.AmbiRepo.ObterAmbiente(id);
                DialogResult decisao = MessageBox.Show($"Deseja remover o Ambiente abaixo?\n{amb.Nome}", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (decisao == DialogResult.OK)
                {

                    FormPrincipal.AmbiRepo.ExcluirAmbiente(amb);
                    MessageBox.Show($"Requisição exlcuída com sucesso.", "AÇÃO CONCLUÍDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCamposTexto();
                    PreencherAmbientes();
                }
            }
        
        }

    }
}
