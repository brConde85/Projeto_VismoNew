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
    public partial class FrmCadFuncionario : Form
    {
        Funcionario funcionario = new Funcionario();

        public FrmCadFuncionario()
        {
            InitializeComponent();
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if ((!textNome.Text.Equals("")) &&
                    (!textCpf.Text.Equals("")) &&
                    (!texLogin.Text.Equals("")) &&
                    (!textSenha.Text.Equals("")) &&
                    (!textSenhaAux.Text.Equals("")) &&
                    (!comboTipo.Text.Equals("")))
            {
                funcionario.Senha = textSenha.Text;
                funcionario.SenhaAux = textSenhaAux.Text;

                if (funcionario.Senha == funcionario.SenhaAux)
                {
                    try
                    {
                        funcionario.Login = texLogin.Text;
                        funcionario.Senha = textSenha.Text;
                        funcionario.Nome = textNome.Text;
                        funcionario.Cpf = textCpf.Text;
                        funcionario.Status = "0";
                        funcionario.Tipo = comboTipo.Text;

                        int x = funcionario.Inserir(funcionario);

                        if (x > 0)
                        {
                            MessageBox.Show(String.Format("Funcionário: {0} inserido com sucesso.", textNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Dado não inserido!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro, cadastro não efetuado!" + ex.Message);
                        throw;
                    }

                }
                else
                {
                    MessageBox.Show("Senhas cadastradas não conferem, favor conferir a senha digitada.", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos antes de continuar.");
            }        
        }
    }
}
