using AniversáriosAgenda.BancoDeDados;
using AniversáriosAgenda.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AniversáriosAgenda
{
    public partial class frmPrincipal : Form
    {
        int _indice;
        public frmPrincipal()
        {
            InitializeComponent();
            CarregarDataGrid();
        }

        private void aniversarianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroAniversariantes CA = new frmCadastroAniversariantes();
            CA.Show();
        }

        //private void frmPrincipal_Load(object sender, EventArgs e)
        //{
        //    InitializeComponent();
        //    // TODO: esta linha de código carrega dados na tabela 'aniversariantesDataSet.Aniversariante'. Você pode movê-la ou removê-la conforme necessário.
        //    //this.aniversarianteTableAdapter.Fill(this.aniversariantesDataSet.Aniversariante);
        //    CarregarDataGrid();
        //    //this.aniversarianteTableAdapter.Fill(aniversariantes);
        //}

        public void CarregarDataGrid()
        {
            CadastrarCliente cliente = new CadastrarCliente();
            var aniversariantes = cliente.RetornarClientes();
            dataGridView1.DataSource = aniversariantes;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (_indice == -1)
                return;

            DataGridViewRow rowData = dataGridView1.Rows[_indice];
            Classe.Aniversariante objNiver = new Classe.Aniversariante()
            {
                Id = int.Parse(rowData.Cells[0].Value.ToString()),
                Nome = rowData.Cells[1].Value.ToString(),
                DataNacimento = DateTime.Parse(rowData.Cells[2].Value.ToString()),
                Descricao = rowData.Cells[3].Value.ToString()
            };

            frmCadastroAniversariantes form = new frmCadastroAniversariantes(objNiver);
            form.BringToFront();
            form.ShowDialog();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _indice = e.RowIndex;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
    }
}
