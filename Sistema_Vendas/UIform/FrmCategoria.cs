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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sistema_Vendas.UIform
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        CategoriaBll c = new CategoriaBll();
        CategoriaDal dal = new CategoriaDal();
        UserDal udal = UserDal.Instance;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text != "")
            {
                ///pegando o valor dos nossos campos do formulário para enviar para o banco de dados.
                c.title = txtTitle.Text;
                c.description = txtDescricao.Text;
                c.added_data = DateTime.Now;
                //pegando o valor do id do usuário logado.
                string loggedUser = frmlogin.LoggedIn;
                int userId = udal.GetIDFromUsername(loggedUser);
                UserBll usr = new UserBll();
                usr.id = userId;

                c.added_by = usr.id;
                bool success = dal.Insert(c);
                //inserindo dados no banco de dados
                if (success)
                {
                    MessageBox.Show("CATEGORIA CADASTRADA COM SUCESSO!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("NÃO FOI POSSÍVEL CADASTRAR ESTA CATEGORIA!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable dt = dal.Select();
                dgvCategoria.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Digite o campo Titulo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpar()
        {
            txtCategoriaID.Text = "";
            txtDescricao.Text = "";
            txtSearch.Text = "";
            txtTitle.Text = "";
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvCategoria.DataSource = dt;

            dgvCategoria.Columns[0].HeaderText = "ID da Categoria";
            dgvCategoria.Columns[1].HeaderText = "Título";
            dgvCategoria.Columns[2].HeaderText = "Descrição";
            dgvCategoria.Columns[3].HeaderText = "Data do Cadastro";
            dgvCategoria.Columns[0].HeaderText = "ID do Usuário";

            //Configurar a seleção de linha inteira:
            dgvCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategoria.MultiSelect = false;

            //Personalizar a aparência da DataGridView:
            dgvCategoria.BackgroundColor = Color.White;
            dgvCategoria.BorderStyle = BorderStyle.Fixed3D;
            dgvCategoria.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCategoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvCategoria.EnableHeadersVisualStyles = false;

            //Ajustar a largura das colunas:
            dgvCategoria.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //Adicionar barra de rolagem:
            dgvCategoria.ScrollBars = ScrollBars.Both;

            //Personalizar as cores de seleção:
            dgvCategoria.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgvCategoria.DefaultCellStyle.SelectionForeColor = Color.White;

            //Ajustar a altura das linhas:
            dgvCategoria.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Desabilitar a ordenação das colunas pelo usuário:
            foreach (DataGridViewColumn column in dgvCategoria.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //Desabilitar a edição das células
            dgvCategoria.ReadOnly = true;

            dgvCategoria.AllowUserToAddRows = false; // Impede a exibição da última linha em branco
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dgvCategoria_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtCategoriaID.Text = dgvCategoria.Rows[rowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategoria.Rows[rowIndex].Cells[1].Value.ToString();
            txtDescricao.Text = dgvCategoria.Rows[rowIndex].Cells[2].Value.ToString();

            c.id = Convert.ToInt32(txtCategoriaID.Text);
            c.description = txtDescricao.Text;
            c.title = txtTitle.Text;

        }

        private void dgvCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                int rowIndex = dgvCategoria.SelectedRows[0].Index;

                txtCategoriaID.Text = dgvCategoria.Rows[rowIndex].Cells[0].Value.ToString();
                txtTitle.Text = dgvCategoria.Rows[rowIndex].Cells[1].Value.ToString();
                txtDescricao.Text = dgvCategoria.Rows[rowIndex].Cells[2].Value.ToString();

                c.id = Convert.ToInt32(txtCategoriaID.Text);
                c.description = txtDescricao.Text;
                c.title = txtTitle.Text;

            }
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text != "")
            {
                bool fieldsChanged = false;

                c.id = Convert.ToInt32(txtCategoriaID.Text);

                if(c.title != txtTitle.Text)
                {
                    c.title = txtTitle.Text;
                    fieldsChanged = true;
                }

                if (c.description != txtDescricao.Text)
                {
                    c.description = txtDescricao.Text;
                    fieldsChanged = true;
                }

                if (fieldsChanged)
                {
                    c.title = txtTitle.Text;
                    c.description = txtDescricao.Text;
                    c.added_data = DateTime.Now;

                    string loggedUser = frmlogin.LoggedIn;
                    int userId = udal.GetIDFromUsername(loggedUser);
                    UserBll usr = new UserBll();
                    usr.id = userId;

                    c.added_by = usr.id;

                    bool success = dal.Update(c);

                    if (success)
                    {
                        MessageBox.Show("CATEGORIA ATUALIZADA COM SUCESSO!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpar();
                    }
                    else
                    {
                        MessageBox.Show("NÃO FOI POSSÍVEL ATUALIZAR A CATEGORIA!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DataTable dt = dal.Select();
                    dgvCategoria.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Nenhum campo foi alterado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Não tem campo selecionado para Atualizar");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.id = Convert.ToInt32(txtCategoriaID.Text);
            string categoria = $"{txtTitle.Text}";

            DialogResult result = MessageBox.Show($"Deseja realmente deletar a Categoria '{categoria}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = dal.Delete(c);

                if (success)
                {
                    MessageBox.Show("CATEGORIA DELETADA COM SUCESSO!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("NÃO FOI POSSÍVEL DELETAR ESTA CATEGORIA!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable dt = dal.Select();
                dgvCategoria.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            if(keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvCategoria.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvCategoria.DataSource = dt;
            }
        }
    }
}
