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
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void aniversarianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroAniversariantes CA = new frmCadastroAniversariantes();
            CA.Show();
        }
    }
}
