using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;
using System.Data.SqlClient;

namespace Vismo_New_
{
    public partial class frmNovaVenda : Form
    {
        Produto produto = new Produto();

        public frmNovaVenda()
        {
            InitializeComponent();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (!txtCod.Text.Equals(""))
            {
                produto.Id = Convert.ToInt32(txtCod.Text);

                try
                {
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = produto.Listar();
                    dataGridView2.DataMember = produto.Listar().Tables[0].TableName;
                }

                catch (Exception ex)
                {
                    //exibe mensagem em caso de erro
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            //a variável "preco" recebe o valor do produto e é multiplicada pela quantidade que será vendida
            double preco = Convert.ToDouble(dataGridView2.Rows[0].Cells[2].Value);
            preco *= Convert.ToDouble(txtQtd.Text);

            //a variável "soma" soma o valor presente no campo de Total com o preço do novo produto 
            double soma = Convert.ToDouble(txtTotal.Text) + preco;
            txtTotal.Text = soma.ToString("N2");

            txtQtd.Text = "1"; //resseta a quantidade de produto a ser vendida
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            //calculo do troco da venda
            double x = Convert.ToDouble(txtPago.Text) - Convert.ToDouble(txtTotal.Text);

            txtTroco.Text = x.ToString("N2");
        }
    }
}
