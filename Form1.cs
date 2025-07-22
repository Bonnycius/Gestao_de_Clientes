using Gestão_de_Clientes.clientes;
using Gestão_de_Clientes.contratos;
using Gestão_de_Clientes.relatorios;
using Gestão_de_Clientes.servicos;
using Gestão_de_Clientes.usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_de_Clientes
{
    public partial class Form1 : Form
    {

        private AgendaControl agendaControl;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            while (CadastroUsuario.UsuarioLogado == null)
            {
                Visible = false;
                f.ShowDialog();
                if (FormLogin.Cancelar)
                {
                    Application.Exit();
                    return;
                }
            }
            Visible = true;

            lbUsuario.Text = $"Usuário: {CadastroUsuario.UsuarioLogado.Usuarios}";

            agendaControl = new AgendaControl();
            agendaControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(agendaControl);
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            visualizacao.FormVisual dashboard = new visualizacao.FormVisual();
            dashboard.Show();
        }

        private void btnServico_Click(object sender, EventArgs e)
        {
            servicos.FormServicos servicos = new FormServicos();            
            servicos.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            clientes.FormClientes clientes = new FormClientes();            
            clientes.Show();
        }

        private void btnContrato_Click(object sender, EventArgs e)
        {
            contratos.FormContratos contratos = new FormContratos();            
            contratos.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            relatorios.FormRelatorios relatorios = new FormRelatorios();            
            relatorios.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            usuarios.FormUsuarios usuarios = new usuarios.FormUsuarios();
            usuarios.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            var form = new FormAdicinarTarefas(DateTime.Today);
            if (form.ShowDialog() == DialogResult.OK)
            {
                agendaControl.AdicionarTarefa(form.DataHora.Date, form.Tarefa);
            }
        }
    }
}
