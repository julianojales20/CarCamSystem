using Sistema_Vendas.BLLClasses;
using Sistema_Vendas.DALdados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.UIform
{
    public partial class frmConfiguracoesBanco : Form
    {
        public frmConfiguracoesBanco()
        {
            InitializeComponent();
        }

        private void bntFecharJanela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguracoesBanco_Load(object sender, EventArgs e)
        {
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@Environment.MachineName));
            cboServer.SelectedIndex = 3;

            try
            {
                // Recuperar a string de conexão da configuração
                string connectionString = ConfigurationManager.AppSettings["connstring"];

                // Extrair os valores da string de conexão
                var connectionValues = connectionString.Split(';')
                    .Select(part => part.Split('='))
                    .ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());

                // Carregar os valores nos campos
                cboServer.Text = connectionValues["Data Source"];
                txtData.Text = connectionValues["Initial Catalog"];
                txtUsername.Text = connectionValues["User ID"];
                txtPassword.Text = connectionValues["Password"];
            }
            catch (ConfigurationErrorsException ex)
            {
                // Lidar com erros de configuração
                MessageBox.Show("Erro ao carregar a string de conexão: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Lidar com outros erros
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void bntLogin_Click_1(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtData.Text, txtUsername.Text, txtPassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Teste de Conexão realizado com Sucesso.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtData.Text, txtUsername.Text, txtPassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("connstring", connectionString);
                    MessageBox.Show("Sua Conexão foi salva com Sucesso.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
