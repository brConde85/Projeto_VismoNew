﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vismo_New_
{
    public partial class FrmLogOpCaixa : Form
    {
        public FrmLogOpCaixa()
        {
            InitializeComponent();
        }

        private void ProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void realizarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNovaVenda tela = new frmNovaVenda();
            tela.Show();

            Close();
        }
    }
}
