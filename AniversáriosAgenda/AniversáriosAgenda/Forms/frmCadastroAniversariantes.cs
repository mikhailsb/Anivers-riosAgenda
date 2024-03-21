using AniversáriosAgenda.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AniversáriosAgenda.Forms
{
    public partial class frmCadastroAniversariantes : Form
    {
        public frmCadastroAniversariantes()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Incluir atualização do DataGrid no Form principal
            this.FindForm().Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var niver = LeituraFormulario();
            ApagarCampos();
            MessageBox.Show($"Nome: {niver.Nome}\n Niver: {niver.DataNacimento.ToString("dd/MM/yyyy")}\n Descricação: {niver.Descricao}");
        }

        private void ApagarCampos()
        {
            txtNome.Text = null;
            dtpData.Value = DateTime.Today;
            txtDrescricao.Text = null;
        }
        Aniversariante LeituraFormulario()
        {
            Aniversariante A = new Aniversariante();
            if (dtpData.Value.Date != DateTime.Today)
            {
                A.Nome = txtNome.Text;
                A.DataNacimento = dtpData.Value;
                A.Descricao = txtDrescricao.Text;
            }
            else
            {
                MessageBox.Show("A data do aniversariante deve ser diferênte da data atual.");
                return A;
            }

            return A;
        }
    }
}
