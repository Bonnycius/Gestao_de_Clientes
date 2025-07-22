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
    public partial class FormAdicinarTarefas : Form
    {
        public string Tarefa { get; private set; }
        public DateTime DataHora { get; private set; }
        public FormAdicinarTarefas()
        {
            InitializeComponent();
        }
        public FormAdicinarTarefas(DateTime dataBase) : this()
        {
            dataCadastro.Value = dataBase.Date.AddHours(8); // você pode ajustar o horário inicial se quiser
        }

        public FormAdicinarTarefas(DateTime dataHora, string descricao) : this()
        {
            dataCadastro.Value = dataHora;
            txtTarefa.Text = descricao;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string descricao = txtTarefa.Text.Trim();

            if (string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Por favor, insira a descrição da tarefa.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Formata a tarefa com hora + descrição
            Tarefa = $"{dataCadastro.Value:HH:mm} - {descricao}";
            DataHora = dataCadastro.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
       
