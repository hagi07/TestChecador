﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checador
{
    public partial class PanelSeguridad2 : Form
    {
        private string usuario;
        public PanelSeguridad2(string usu)
        {
            InitializeComponent();
            usuario = usu;
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            
        }
    }
}
