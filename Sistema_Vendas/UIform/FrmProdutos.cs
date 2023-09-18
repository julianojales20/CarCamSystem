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
    public partial class FrmProdutos : Form
    {
        public TabPage AbaPrincipal { get; set; }

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            //DataTable dt = dal.Select();
            //dgvProdutos.DataSource = dt;

            //dgvProdutos.Columns[0].HeaderText = "ID da Categoria";
            //dgvProdutos.Columns[1].HeaderText = "Título";
            //dgvProdutos.Columns[2].HeaderText = "Descrição";
            //dgvProdutos.Columns[3].HeaderText = "Data do Cadastro";
            //dgvProdutos.Columns[0].HeaderText = "ID do Usuário";

            //Configurar a seleção de linha inteira:
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.MultiSelect = false;

            //Personalizar a aparência da DataGridView:
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.Fixed3D;
            dgvProdutos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvProdutos.EnableHeadersVisualStyles = false;

            //Ajustar a largura das colunas:
            dgvProdutos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //Adicionar barra de rolagem:
            dgvProdutos.ScrollBars = ScrollBars.Both;

            //Personalizar as cores de seleção:
            dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgvProdutos.DefaultCellStyle.SelectionForeColor = Color.White;

            //Ajustar a altura das linhas:
            dgvProdutos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Desabilitar a ordenação das colunas pelo usuário:
            foreach (DataGridViewColumn column in dgvProdutos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //Desabilitar a edição das células
            dgvProdutos.ReadOnly = true;

            dgvProdutos.AllowUserToAddRows = false; // Impede a exibição da última linha em branco
        }
    }
}
