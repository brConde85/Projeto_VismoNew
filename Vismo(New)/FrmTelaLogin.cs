﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Vismo_New_
{
    public partial class FrmTelaLogin : Form
    {
        Funcionario funcionario = new Funcionario();
        public FrmTelaLogin()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            FrmCadFuncionario TelaFunc = new FrmCadFuncionario();
            TelaFunc.Show();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
                        
            funcionario.Acessar(txtLogin.Text, txtSenha.Text);
            if (funcionario.ConfirmCadast)
            {
                MessageBox.Show("Logado com Sucesso!","Entrando",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if(funcionario.Tipo == "Gerente")
                {
                    FrmLogGerente frmGer = new FrmLogGerente();
                    frmGer.Show();
                }
                else 
                {
                    FrmLogOpCaixa frmCx = new FrmLogOpCaixa();
                    frmCx.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Login não encontrado, verifique login e senha!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }
    }
}
