using System;
using System.Collections.Generic;
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
    /// Lógica interna para Atulizar.xaml
    /// </summary>
    public partial class Atulizar : Window
    {

        public static string conexao = "Server=localhost;Database=CRUD_PRODUCTS;Uid=root;Pwd=;";
        private int _idUsuario;
        public Atulizar(int id)
        {
            InitializeComponent();
            _idUsuario = id;
            carregarTudo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 abrir = new Window1();
            abrir.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = "INSERT INTO produtos (nome_jogo, quantidade, preco_unidade) VALUES (@nome_jogo, @quantiade, @preco_unidade)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome_jogo", nome.Text);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade.Text);
                    cmd.Parameters.AddWithValue("@preco", preco.Text);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void carregarTudo()
        {

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();
                string sql = @"SELECT nome_jogo, quantidade, preco_unidade FROM produtos WHERE id=@id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _idUsuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nome.Text = reader["nome_jogo"].ToString();
                            preco.Text = reader["preco_unidade"].ToString();
                            quantidade.Text = reader["quantidade"].ToString();


                        }
                    }
                }
            }

        }

        private void nome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void quantidade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
