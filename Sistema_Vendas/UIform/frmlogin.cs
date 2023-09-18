using Sistema_Vendas.BLLClasses;
using Sistema_Vendas.DALdados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.UIform
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        public static string LoggedIn { get; private set; }

        LoginBll l = new LoginBll();
        LoginDal dal = new LoginDal();

        private void bntFecharJanela_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            cmbTypeUser.SelectedIndex = 0;
        }

        private void bntLogin_Click_1(object sender, EventArgs e)
        {
            l.username = txtUsername.Text;
            l.password = txtPassword.Text;
            
            string acesso = cmbTypeUser.Text;

            switch (acesso)
            {
                case "Administrador":
                    {
                        l.user_type = 1;
                    }
                    break;
                case "Usuario":
                    {
                        l.user_type = 0;
                    }
                    break;
                default:
                    {
                        MessageBox.Show("TIPO DE USUÁRIO INVÁLIDO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }

            bool Success = dal.loginCheck(l);

            if (Success)
            {
                switch (l.user_type)
                {
                    case 1:
                        {
                            frmAdminDashboard admin = new frmAdminDashboard();
                            LoggedIn = l.username;
                            admin.Show();
                            this.Hide();
                        }
                        break;
                    case 0:
                        {
                            frmUserDashboard user = new frmUserDashboard();
                            LoggedIn = l.username;
                            user.Show();
                            this.Hide();
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("TIPO DE USUÁRIO INVÁLIDO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                }
            }
            else
            {
                MessageBox.Show("NÃO FOI POSSÍVEL ENCONTRAR ESTE USUÁRIO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBanco_Click_1(object sender, EventArgs e)
        {
            frmConfiguracoesBanco configBanco = new frmConfiguracoesBanco();
            configBanco.ShowDialog();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Impede o caractere Enter de ser inserido no TextBox
                bntLogin.PerformClick(); // Aciona o evento Click do botão "bntLogin"
            }
        }


    }
}