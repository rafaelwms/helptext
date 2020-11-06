namespace EasyDescriptionProvider
{
    partial class ConsultaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaForm));
            this.cbTipoRequisicao = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvRequisicoes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbAmbiente = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btCopiarAreaTransf = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gerenciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeRequisiçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ambienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisiçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTipoRequisicao
            // 
            this.cbTipoRequisicao.FormattingEnabled = true;
            this.cbTipoRequisicao.Location = new System.Drawing.Point(18, 49);
            this.cbTipoRequisicao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoRequisicao.Name = "cbTipoRequisicao";
            this.cbTipoRequisicao.Size = new System.Drawing.Size(291, 28);
            this.cbTipoRequisicao.TabIndex = 0;
            this.cbTipoRequisicao.SelectedValueChanged += new System.EventHandler(this.cbTipoRequisicao_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvRequisicoes);
            this.groupBox1.Controls.Add(this.cbAmbiente);
            this.groupBox1.Controls.Add(this.cbTipoRequisicao);
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(660, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Requisicao";
            // 
            // lvRequisicoes
            // 
            this.lvRequisicoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvRequisicoes.FullRowSelect = true;
            this.lvRequisicoes.GridLines = true;
            this.lvRequisicoes.HideSelection = false;
            this.lvRequisicoes.Location = new System.Drawing.Point(18, 118);
            this.lvRequisicoes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvRequisicoes.MultiSelect = false;
            this.lvRequisicoes.Name = "lvRequisicoes";
            this.lvRequisicoes.Size = new System.Drawing.Size(620, 158);
            this.lvRequisicoes.TabIndex = 2;
            this.lvRequisicoes.UseCompatibleStateImageBehavior = false;
            this.lvRequisicoes.View = System.Windows.Forms.View.Details;
            this.lvRequisicoes.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvRequisicoes_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Título";
            this.columnHeader2.Width = 333;
            // 
            // cbAmbiente
            // 
            this.cbAmbiente.FormattingEnabled = true;
            this.cbAmbiente.Location = new System.Drawing.Point(348, 49);
            this.cbAmbiente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAmbiente.Name = "cbAmbiente";
            this.cbAmbiente.Size = new System.Drawing.Size(291, 28);
            this.cbAmbiente.TabIndex = 1;
            this.cbAmbiente.SelectedValueChanged += new System.EventHandler(this.cbAmbiente_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btCopiarAreaTransf);
            this.groupBox2.Controls.Add(this.txtDescricao);
            this.groupBox2.Location = new System.Drawing.Point(12, 510);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(660, 518);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Requisição";
            // 
            // btCopiarAreaTransf
            // 
            this.btCopiarAreaTransf.Location = new System.Drawing.Point(261, 475);
            this.btCopiarAreaTransf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCopiarAreaTransf.Name = "btCopiarAreaTransf";
            this.btCopiarAreaTransf.Size = new System.Drawing.Size(124, 38);
            this.btCopiarAreaTransf.TabIndex = 1;
            this.btCopiarAreaTransf.Text = "Copiar";
            this.btCopiarAreaTransf.UseVisualStyleBackColor = true;
            this.btCopiarAreaTransf.Click += new System.EventHandler(this.btCopiarAreaTransf_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(18, 50);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescricao.Size = new System.Drawing.Size(620, 419);
            this.txtDescricao.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gerenciarToolStripMenuItem
            // 
            this.gerenciarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoDeRequisiçãoToolStripMenuItem,
            this.ambienteToolStripMenuItem,
            this.requisiçãoToolStripMenuItem});
            this.gerenciarToolStripMenuItem.Name = "gerenciarToolStripMenuItem";
            this.gerenciarToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            this.gerenciarToolStripMenuItem.Text = "Gerenciar";
            // 
            // tipoDeRequisiçãoToolStripMenuItem
            // 
            this.tipoDeRequisiçãoToolStripMenuItem.Name = "tipoDeRequisiçãoToolStripMenuItem";
            this.tipoDeRequisiçãoToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.tipoDeRequisiçãoToolStripMenuItem.Text = "Tipo de Requisição";
            this.tipoDeRequisiçãoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeRequisiçãoToolStripMenuItem_Click);
            // 
            // ambienteToolStripMenuItem
            // 
            this.ambienteToolStripMenuItem.Name = "ambienteToolStripMenuItem";
            this.ambienteToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.ambienteToolStripMenuItem.Text = "Ambiente";
            this.ambienteToolStripMenuItem.Click += new System.EventHandler(this.ambienteToolStripMenuItem_Click);
            // 
            // requisiçãoToolStripMenuItem
            // 
            this.requisiçãoToolStripMenuItem.Name = "requisiçãoToolStripMenuItem";
            this.requisiçãoToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.requisiçãoToolStripMenuItem.Text = "Requisição";
            this.requisiçãoToolStripMenuItem.Click += new System.EventHandler(this.requisiçãoToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(14, 45);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(659, 80);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aqruivo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pasta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(464, 26);
            this.textBox1.TabIndex = 0;
            // 
            // folderDialog
            // 
            this.folderDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // ConsultaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 1041);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(708, 1097);
            this.MinimumSize = new System.Drawing.Size(708, 1097);
            this.Name = "ConsultaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HP_HelpText";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoRequisicao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbAmbiente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btCopiarAreaTransf;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ListView lvRequisicoes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gerenciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeRequisiçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ambienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requisiçãoToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}