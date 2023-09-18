using Sistema_Vendas.UIform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        private void frmUserDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exibir a mensagem de confirmação ao fechar o sistema
            DialogResult result = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Cancelar o fechamento do formulário
                e.Cancel = true;
            }

            frmlogin login = new frmlogin();
            login.Show();
        }
    }
}
