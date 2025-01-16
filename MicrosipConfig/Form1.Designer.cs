namespace MicrosipConfig
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboSetor;
        private System.Windows.Forms.TextBox txtRamal;
        private System.Windows.Forms.RadioButton radioInterno;
        private System.Windows.Forms.RadioButton radioExterno;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label labelSetor;
        private System.Windows.Forms.Label labelRamal;
        private System.Windows.Forms.Label labelAplicacao;


        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboSetor = new ComboBox();
            txtRamal = new TextBox();
            radioInterno = new RadioButton();
            radioExterno = new RadioButton();
            btnGerar = new Button();
            labelSetor = new Label();
            labelRamal = new Label();
            labelAplicacao = new Label();
            SuspendLayout();
            // 
            // comboSetor
            // 
            comboSetor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSetor.FormattingEnabled = true;
            comboSetor.Items.AddRange(new object[] { "CALL_CENTER", "CC_ATENDIMENTO", "LOGISTICA" });
            comboSetor.Location = new Point(20, 40);
            comboSetor.Name = "comboSetor";
            comboSetor.Size = new Size(200, 23);
            comboSetor.TabIndex = 0;
            // 
            // txtRamal
            // 
            txtRamal.Location = new Point(20, 100);
            txtRamal.Name = "txtRamal";
            txtRamal.Size = new Size(100, 23);
            txtRamal.TabIndex = 1;
            // 
            // radioInterno
            // 
            radioInterno.AutoSize = true;
            radioInterno.Location = new Point(20, 155);
            radioInterno.Name = "radioInterno";
            radioInterno.Size = new Size(63, 19);
            radioInterno.TabIndex = 2;
            radioInterno.TabStop = true;
            radioInterno.Text = "Interno";
            radioInterno.UseVisualStyleBackColor = true;
            // 
            // radioExterno
            // 
            radioExterno.AutoSize = true;
            radioExterno.Location = new Point(89, 155);
            radioExterno.Name = "radioExterno";
            radioExterno.Size = new Size(65, 19);
            radioExterno.TabIndex = 3;
            radioExterno.TabStop = true;
            radioExterno.Text = "Externo";
            radioExterno.UseVisualStyleBackColor = true;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(20, 195);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(75, 23);
            btnGerar.TabIndex = 4;
            btnGerar.Text = "Gerar Configuração";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // labelSetor
            // 
            labelSetor.AutoSize = true;
            labelSetor.Location = new Point(12, 22);
            labelSetor.Name = "labelSetor";
            labelSetor.Size = new Size(100, 15);
            labelSetor.TabIndex = 5;
            labelSetor.Text = "Selecione o Setor:";
            // 
            // labelRamal
            // 
            labelRamal.AutoSize = true;
            labelRamal.Location = new Point(12, 82);
            labelRamal.Name = "labelRamal";
            labelRamal.Size = new Size(90, 15);
            labelRamal.TabIndex = 6;
            labelRamal.Text = "Digite o Ramal: ";
            // 
            // labelAplicacao
            // 
            labelAplicacao.Location = new Point(14, 139);
            labelAplicacao.Name = "labelAplicacao";
            labelAplicacao.Size = new Size(88, 13);
            labelAplicacao.TabIndex = 7;
            labelAplicacao.Text = "IP: ";
            // 
            // Form1
            // 
            ClientSize = new Size(250, 230);
            Controls.Add(labelSetor);
            Controls.Add(labelRamal);
            Controls.Add(labelAplicacao);
            Controls.Add(btnGerar);
            Controls.Add(radioExterno);
            Controls.Add(radioInterno);
            Controls.Add(txtRamal);
            Controls.Add(comboSetor);
            Name = "Form1";
            Text = "Configuração Microsip";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
