using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_de_Clientes.contratos
{
    public partial class FormContratos : Form
    {
        public FormContratos()
        {
            InitializeComponent();
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione o arquivo PDF";
            openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnUpLoad.Text = openFileDialog.FileName;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salvar no banco de dados
        }
    }
}
