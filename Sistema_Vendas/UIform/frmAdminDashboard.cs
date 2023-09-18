using Sistema_Vendas.UIform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Vendas
{
    public partial class frmAdminDashboard : Form
    {
        private Dictionary<string, TabPage> abasAbertas; // Dicionário para armazenar as abas abertas

        public frmAdminDashboard()
        {
            InitializeComponent();
            abasAbertas = new Dictionary<string, TabPage>(); // Inicializar o dicionário
        }

        private void AbrirFormulario(Form formulario, string nomeAba)
        {
            if (abasAbertas.ContainsKey(nomeAba))
            {
                // Se a aba já estiver aberta, trazê-la para frente
                tabControlPrincipal.SelectedTab = abasAbertas[nomeAba];
                return;
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            TabPage novaAba = new TabPage(nomeAba);
            novaAba.Controls.Add(formulario);

            tabControlPrincipal.TabPages.Add(novaAba);
            abasAbertas.Add(nomeAba, novaAba);

            AdicionarBotaoFecharAba(novaAba); // Adiciona o botão de fechamento à aba

            formulario.Show();

            tabControlPrincipal.SelectedTab = novaAba;
        }

        public void RemoverAba(TabPage aba)
        {
            tabControlPrincipal.TabPages.Remove(aba);
            abasAbertas.Remove(aba.Text);
        }

        private Form ObterFormularioExistente(string nomeAba)
        {
            foreach (TabPage aba in tabControlPrincipal.TabPages)
            {
                if (aba.Text == nomeAba)
                {
                    if (aba.Controls.Count > 0 && aba.Controls[0] is Form formulario)
                    {
                        return formulario;
                    }
                }
            }

            return null;
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nomeAba = "Usuários";
            Form formulario = ObterFormularioExistente(nomeAba);

            if (formulario == null)
            {
                formulario = new frmusers();
                AbrirFormulario(formulario, nomeAba);
            }
            else
            {
                tabControlPrincipal.SelectedTab = abasAbertas[nomeAba];
            }
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nomeAba = "Categoria";
            Form formulario = ObterFormularioExistente(nomeAba);

            if (formulario == null)
            {
                formulario = new FrmCategoria();
                AbrirFormulario(formulario, nomeAba);
            }
            else
            {
                tabControlPrincipal.SelectedTab = abasAbertas[nomeAba];
            }
        }

        private void frmAdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            frmlogin login = new frmlogin();
            login.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nomeAba = "Produtos";
            Form formulario = ObterFormularioExistente(nomeAba);

            if (formulario == null)
            {
                formulario = new FrmProdutos();
                AbrirFormulario(formulario, nomeAba);
            }
            else
            {
                tabControlPrincipal.SelectedTab = abasAbertas[nomeAba];
            }
        }

        private void AdicionarBotaoFecharAba(TabPage tabPage)
        {
            // Cria um botão para fechar a aba
            Button closeButton = new Button();
            closeButton.Text = "X";
            closeButton.Size = new Size(30, 30);
            closeButton.Location = new Point(tabPage.Width - closeButton.Width - 10, 10);
            closeButton.Font = new Font(closeButton.Font, FontStyle.Bold);
            closeButton.BackColor = Color.Red;
            closeButton.ForeColor = Color.White;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (sender, e) =>
            {
                // Remove a aba do controle TabControl quando o botão é clicado
                RemoverAba(tabPage);
            };

            // Adiciona o botão à aba
            tabPage.Controls.Add(closeButton);
            tabPage.Controls.SetChildIndex(closeButton, 0); // Define a ordem z do botão para que fique na frente dos outros controles da aba
        }

    }
}
