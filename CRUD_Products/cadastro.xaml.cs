using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace CRUD_Products
{
    /// <summary>
    /// Lógica interna para cadastro.xaml
    /// </summary>
    public partial class cadastro : Window
    {

        public string connectionString = "Server=localhost;Database=CRUD_PRODUCTS;Uid=root;Pwd=;";

        public void limpar()
        {
            nome.Text = null;
            quantidade.Text = null;
            preco.Text = null;
            classifica.Text = null;
        }

        public cadastro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Nome;
            bool valido = true;


            if (nome.Text.Length < 2)
            {
                MessageBox.Show("nome do jogo deve ser maior que 2 caracteres");
                valido = false;
            }



            if (!int.TryParse(quantidade.Text, out int quantidadee))
            {
                MessageBox.Show("Digite apenas números na quantidade!");
                valido = false;
                return;
            }




            if (!double.TryParse(preco.Text, out double precoo))
            {
                MessageBox.Show("Digite apenas números no preco!");
                valido = false;
                return;
            }


            if (!int.TryParse(classifica.Text, out int clasificacao))
            {
                MessageBox.Show("Digite apenas números na classificação!");
                valido = false;
                return;
            }
            else
            {
                if (clasificacao < 0)
                {
                    MessageBox.Show("classificação deve ser maior que 0");
                    valido = false;
                }

                if (clasificacao > 18)
                {
                    MessageBox.Show("Classificação deve ser 18 ou menos");
                    valido = false;
                }
            }


            string sql = "SELECT COUNT(*) FROM produtos WHERE nome_jogo = @nome_jogo";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome_jogo", nome.Text);

                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                    if (resultado > 0)
                    {
                        MessageBox.Show("Digite novamente, jogo ja cadastrado!!");
                        valido = false;
                        limpar();



                    }
                }
            }


            if (valido)
            {


                Nome = nome.Text.Trim();


                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(connectionString))
                    {
                        conexao.Open();

                        string query = "INSERT INTO produtos (nome_jogo, quantidade, preco_unidade, classificacao) VALUES (@nome, @quantidade, @preco_unidade, @classificacao)";

                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {


                            comando.Parameters.AddWithValue("@nome", nome.Text);
                            comando.Parameters.AddWithValue("@quantidade", quantidadee);
                            comando.Parameters.AddWithValue("@preco_unidade", precoo);
                            comando.Parameters.AddWithValue("@classificacao", clasificacao);

                            comando.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("jogo cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK);


                }
                catch (Exception)
                {
                    throw;
                }


                limpar();



                Window1 telainicial = new Window1();
                telainicial.Show();
                this.Close();


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 telainicial = new Window1();
            telainicial.Show();
            this.Close();
        }

        private void quantidade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}