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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Sistema_Vendas.UIform
{
    public partial class frmusers : Form
    {
        public frmusers()
        {
            InitializeComponent();
        }

        UserBll u = new UserBll();
        UserDal dal = new UserDal();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFistName.Text != "")
            {
                if (txtLastName.Text != "")
                {
                    if (txtEmail.Text != "")
                    {
                        u.fist_name = txtFistName.Text;
                        u.last_name = txtLastName.Text;
                        u.email = txtEmail.Text;
                        u.username = txtUsername.Text;
                        u.password = txtPassword.Text;
                        u.contact = txtContact.Text;
                        u.address = txtAdress.Text;
                        u.gender = cmbGender.Text;
                        u.user_type = cmbTypeUser.Text;
                        u.added_date = DateTime.Now;
                        u.added_by = 1;

                        bool success = dal.Insert(u);

                        if (success)
                        {
                            MessageBox.Show("USUÁRIO CADASTRADO COM SUCESSO!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpar();
                        }
                        else
                        {
                            MessageBox.Show("NÃO FOI POSSÍVEL CADASTRAR ESTE USUÁRIO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        DataTable dt = dal.Select();
                        dgvUser.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Digite o campo Email", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite o campo Sobrenome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Digite o campo Primeiro Nome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void frmusers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUser.DataSource = dt;
            dgvUser.Columns[0].HeaderText = "ID Usuário";
            dgvUser.Columns[1].HeaderText = "Nome";
            dgvUser.Columns[2].HeaderText = "Sobrenome";
            dgvUser.Columns[3].HeaderText = "EMail";
            dgvUser.Columns[4].HeaderText = "Usuário";
            dgvUser.Columns[5].HeaderText = "Senha";
            dgvUser.Columns[6].HeaderText = "Telefone";
            dgvUser.Columns[7].HeaderText = "Endereço";
            dgvUser.Columns[8].HeaderText = "Sexo";
            dgvUser.Columns[9].HeaderText = "Tipo de Usuário";
            dgvUser.Columns[10].HeaderText = "Data do Cadastro";
            dgvUser.Columns[11].HeaderText = "Cadastrado Por";

            //Configurar a seleção de linha inteira:
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.MultiSelect = false;

            //Personalizar a aparência da DataGridView:
            dgvUser.BackgroundColor = Color.White;
            dgvUser.BorderStyle = BorderStyle.Fixed3D;
            dgvUser.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvUser.EnableHeadersVisualStyles = false;

            //Ajustar a largura das colunas:
            dgvUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //Adicionar barra de rolagem:
            dgvUser.ScrollBars = ScrollBars.Both;

            //Personalizar as cores de seleção:
            dgvUser.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgvUser.DefaultCellStyle.SelectionForeColor = Color.White;

            //Ajustar a altura das linhas:
            dgvUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Desabilitar a ordenação das colunas pelo usuário:
            foreach (DataGridViewColumn column in dgvUser.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //Desabilitar a edição das células
            dgvUser.ReadOnly = true;

            dgvUser.AllowUserToAddRows = false; // Impede a exibição da última linha em branco
            
        }

        private void Limpar()
        {
            txtUserID.Text = "";
            txtFistName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAdress.Text = "";
            cmbGender.Text = "";
            cmbTypeUser.Text = "";
        }

        private void dgvUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUser.Rows[rowIndex].Cells[0].Value.ToString();
            txtFistName.Text = dgvUser.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUser.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUser.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUser.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUser.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUser.Rows[rowIndex].Cells[6].Value.ToString();
            txtAdress.Text = dgvUser.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUser.Rows[rowIndex].Cells[8].Value.ToString();
            cmbTypeUser.Text = dgvUser.Rows[rowIndex].Cells[9].Value.ToString();

            u.id = Convert.ToInt32(txtUserID.Text);
            u.fist_name = txtFistName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAdress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbTypeUser.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            if (txtFistName.Text != "")
            {
                if (txtLastName.Text != "")
                {
                    if (txtEmail.Text != "")
                    {
                        // Variável de controle para verificar se houve alteração
                        bool fieldsChanged = false;

                        u.id = Convert.ToInt32(txtUserID.Text);

                        // Verificar se os campos foram alterados
                        if (u.fist_name != txtFistName.Text)
                        {
                            u.fist_name = txtFistName.Text;
                            fieldsChanged = true;
                        }

                        if (u.last_name != txtLastName.Text)
                        {
                            u.last_name = txtLastName.Text;
                            fieldsChanged = true;
                        }

                        if (u.email != txtEmail.Text)
                        {
                            u.email = txtEmail.Text;
                            fieldsChanged = true;
                        }

                        // Verificar se houve alguma alteração
                        if (fieldsChanged)
                        {
                            u.username = txtUsername.Text;
                            u.password = txtPassword.Text;
                            u.contact = txtContact.Text;
                            u.address = txtAdress.Text;
                            u.gender = cmbGender.Text;
                            u.user_type = cmbTypeUser.Text;
                            u.added_date = DateTime.Now;

                            bool success = dal.Update(u);

                            if (success)
                            {
                                MessageBox.Show("USUÁRIO ATUALIZADO COM SUCESSO!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpar();
                            }
                            else
                            {
                                MessageBox.Show("NÃO FOI POSSÍVEL ATUALIZAR ESTE USUÁRIO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            DataTable dt = dal.Select();
                            dgvUser.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Nenhum campo foi alterado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite o campo Email");
                    }
                }
                else
                {
                    MessageBox.Show("Digite o campo Sobrenome");
                }
            }
            else
            {
                MessageBox.Show("Digite o campo Primeiro Nome");
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtUserID.Text);

            // Obter o nome do usuário
            string userName = $"{txtFistName.Text} {txtLastName.Text}";

            // Exibir a mensagem de confirmação com o nome do usuário
            DialogResult result = MessageBox.Show($"Deseja realmente deletar o usuário '{userName}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = dal.Delete(u);

                if (success)
                {
                    MessageBox.Show("USUÁRIO DELETADO COM SUCESSO!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("NÃO FOI POSSÍVEL DELETAR ESTE USUÁRIO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable dt = dal.Select();
                dgvUser.DataSource = dt;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            if(keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvUser.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvUser.DataSource = dt;
            }
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                int rowIndex = dgvUser.SelectedRows[0].Index;
                txtUserID.Text = dgvUser.Rows[rowIndex].Cells[0].Value.ToString();
                txtFistName.Text = dgvUser.Rows[rowIndex].Cells[1].Value.ToString();
                txtLastName.Text = dgvUser.Rows[rowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dgvUser.Rows[rowIndex].Cells[3].Value.ToString();
                txtUsername.Text = dgvUser.Rows[rowIndex].Cells[4].Value.ToString();
                txtPassword.Text = dgvUser.Rows[rowIndex].Cells[5].Value.ToString();
                txtContact.Text = dgvUser.Rows[rowIndex].Cells[6].Value.ToString();
                txtAdress.Text = dgvUser.Rows[rowIndex].Cells[7].Value.ToString();
                cmbGender.Text = dgvUser.Rows[rowIndex].Cells[8].Value.ToString();
                cmbTypeUser.Text = dgvUser.Rows[rowIndex].Cells[9].Value.ToString();

                u.id = Convert.ToInt32(txtUserID.Text);
                u.fist_name = txtFistName.Text;
                u.last_name = txtLastName.Text;
                u.email = txtEmail.Text;
                u.username = txtUsername.Text;
                u.password = txtPassword.Text;
                u.contact = txtContact.Text;
                u.address = txtAdress.Text;
                u.gender = cmbGender.Text;
                u.user_type = cmbTypeUser.Text;
                u.added_date = DateTime.Now;
                u.added_by = 1;
            }
        }

        private void frmusers_Resize(object sender, EventArgs e)
        {
            panelHeader.Size = this.ClientSize;
        }
    }
}
