using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_de_Clientes.clientes
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtRazaoSocial.Text = "";
            txtCnpj.Text = "";
            txtInscEstadual.Text = "";
            txtEmail.Text = "";
            txtWhatsApp.Text = "";
            txtTelefone.Text ="";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtCep.Text = "";
            txtResponsavel.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar no banco de dados
        }
    }
}
