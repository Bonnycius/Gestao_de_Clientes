﻿using System;
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
    public partial class FormOpcoes : Form
    {
        public FormOpcoes(string tarefa)
        {
            InitializeComponent();
            label1.Text = tarefa;

        }
    }
}
