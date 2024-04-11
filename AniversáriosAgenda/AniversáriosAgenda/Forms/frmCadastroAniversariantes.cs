using AniversáriosAgenda.BancoDeDados;
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
        Aniversariante oNiver;
        public frmCadastroAniversariantes()
        {
            InitializeComponent();
            btnCadastrar.Text = "Cadastrar";
        }

        public frmCadastroAniversariantes(Aniversariante objNiver)
        {
            InitializeComponent();
            oNiver = objNiver;
            btnCadastrar.Text = "Salvar";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Incluir atualização do DataGrid no Form principal
            this.FindForm().Close();
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCadastrar.Text == "Cadastrar")
                {
                    var niver = LeituraFormulario();

                    if (!string.IsNullOrEmpty(niver.Nome))
                    {
                        CadastrarCliente CadNiver = new CadastrarCliente();
                        CadNiver.IncluirCliente(niver);

                        ApagarCampos();
                        frmPrincipal frmPrin = new frmPrincipal();
                        frmPrin.CarregarDataGrid();
                    }
                    else
                    {
                        MessageBox.Show($"Os campos devem ser preenchidos para cadastrar o Aniversariante.");
                    }
                }
                else
                {
                    var niver = LeituraFormulario();
                    niver.Id = oNiver.Id;

                    if (!string.IsNullOrEmpty(niver.Nome))
                    {
                        CadastrarCliente CadNiver = new CadastrarCliente();
                        CadNiver.AlterarCliente(niver);

                        ApagarCampos();
                        frmPrincipal frmPrin = new frmPrincipal();
                        frmPrin.CarregarDataGrid();
                    }
                    else
                    {
                        MessageBox.Show($"Os campos devem ser preenchidos para cadastrar o Aniversariante.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no cadastro do Aniversariante. \n {ex.Message}");
            }
        }

        private void ApagarCampos()
        {
            txtNome.Text = null;
            dtpData.Value = DateTime.Today;
            txtDescricao.Text = null;
        }
        Aniversariante LeituraFormulario()
        {
            Aniversariante A = new Aniversariante();
            if (dtpData.Value.Date != DateTime.Today)
            {
                A.Nome = txtNome.Text;
                A.DataNacimento = dtpData.Value;
                A.Descricao = txtDescricao.Text;
            }
            else
            {
                MessageBox.Show("A data do aniversariante deve ser diferênte da data atual.");
                return A;
            }

            return A;
        }

        private void frmCadastroAniversariantes_Load(object sender, EventArgs e)
        {
            if (btnCadastrar.Text == "Cadastrar")
                return;
            else
            {
                txtNome.Text = oNiver.Nome;
                dtpData.Value = DateTime.Parse(oNiver.DataNacimento.ToString());
                txtDescricao.Text = oNiver.Descricao;
            }
        }
    }
}
