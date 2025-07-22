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
    public partial class AgendaControl : UserControl
    {
        private Dictionary<DateTime, List<string>> tarefasPorData = new Dictionary<DateTime, List<string>>();

        public AgendaControl()
        {
            InitializeComponent(); 
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            listBoxTarefas.MouseDoubleClick += listBoxTarefas_MouseDoubleClick;
        }
        private void AtualizarListaTarefas(DateTime data)
        {
            listBoxTarefas.Items.Clear();

            if (tarefasPorData.ContainsKey(data))
            {
                foreach (var tarefa in tarefasPorData[data])
                    listBoxTarefas.Items.Add(tarefa);
            }
            else
            {
                listBoxTarefas.Items.Add("Sem tarefas para esta data.");
            }
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            AtualizarListaTarefas(e.Start.Date);
        }
        public void AdicionarTarefa(DateTime data, string tarefa)
        {
            if (!tarefasPorData.ContainsKey(data))
                tarefasPorData[data] = new List<string>();

            tarefasPorData[data].Add(tarefa);

            // Atualiza visual se a data adicionada for a selecionada
            if (monthCalendar1.SelectionStart.Date == data)
                AtualizarListaTarefas(data);

        }

        private void listBoxTarefas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxTarefas.SelectedItem == null) return;

            string tarefaSelecionada = listBoxTarefas.SelectedItem.ToString();

            using (var popup = new FormOpcoes(tarefaSelecionada))
            {
                var resultado = popup.ShowDialog();

                if (resultado == DialogResult.Yes)
                {
                    // Editar a tarefa
                    var partes = tarefaSelecionada.Split(new[] { " - " }, 2, StringSplitOptions.None);
                    DateTime hora = DateTime.ParseExact(partes[0], "HH:mm", null);
                    string descricao = partes.Length > 1 ? partes[1] : "";

                    DateTime dataSelecionada = monthCalendar1.SelectionStart.Date.AddHours(hora.Hour).AddMinutes(hora.Minute);

                    var editarForm = new FormAdicinarTarefas(dataSelecionada, descricao);
                    if (editarForm.ShowDialog() == DialogResult.OK)
                    {
                        tarefasPorData[monthCalendar1.SelectionStart.Date].Remove(tarefaSelecionada);
                        AdicionarTarefa(editarForm.DataHora.Date, editarForm.Tarefa);
                    }
                }
                else if (resultado == DialogResult.No)
                {
                    // Deletar a tarefa
                    DateTime dataSelecionada = monthCalendar1.SelectionStart.Date;

                    if (tarefasPorData.ContainsKey(dataSelecionada))
                    {
                        tarefasPorData[dataSelecionada].Remove(tarefaSelecionada);
                        AtualizarListaTarefas(dataSelecionada);
                    }
                }
                // Cancel: faz nada
            }


        }
    }
}
