using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Control
{
    public class Produto
    {
        //atributos produto
        private int codProduto;
        private string nomeProduto;
        private double preco;
        private int qtdEstoque;
        private string pchave;

        public Fornecedor fornecedor;

        public Produto()
        {
            fornecedor = new Fornecedor();
        }

        // getter e setter produto

        public int Id
        {
            get
            {
                return codProduto;
            }

            set
            {
                codProduto = value;
            }
        }

        public string Nome
        {
            get
            {
                return nomeProduto;
            }

            set
            {
                nomeProduto = value;
            }
        }

        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        public int QtdEstoque
        {
            get
            {
                return qtdEstoque;
            }

            set
            {
                qtdEstoque = value;
            }
        }

        public string Pchave
        {
            get
            {
                return pchave;
            }

            set
            {
                pchave = value;
            }
        }

        
        //métodos
        public int Inserir()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();
                cn.CommandText = "INSERT INTO Produto ([nome], [preco], [qtdEstoque], [codFornecedor], [pchave])" +
                    " VALUES (@nome, @preco, @qtdEstoque, @codFornecedor, @pchave)";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = nomeProduto;
                cn.Parameters.Add("preco", SqlDbType.Money).Value = preco;
                cn.Parameters.Add("qtdEstoque", SqlDbType.Int).Value = qtdEstoque;             
                cn.Parameters.Add("codFornecedor", SqlDbType.Int).Value = fornecedor.Id;
                cn.Parameters.Add("pchave", SqlDbType.VarChar).Value = pchave;
                cn.Connection = con;

                return cn.ExecuteNonQuery();
            }
        }

        public DataSet Listar()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();
                cn.CommandText = "SELECT * FROM Produto WHERE codigo = @codProduto";
                cn.Parameters.Add("codProduto", SqlDbType.Int).Value = codProduto;
                cn.Connection = con;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cn;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                return dataSet;
            }
        }
    }  
}
