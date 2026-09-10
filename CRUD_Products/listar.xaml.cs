using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CRUD_Products
{
    /// <summary>
    /// Lógica interna para listar.xaml
    /// </summary>
    public partial class listar : Window
    {

        public static string conexao = "Server=localhost;Database=CRUD_PRODUCTS;Uid=root;Pwd=;";
        public listar()
        {
            InitializeComponent();
            carregarTabela();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 abrir = new Window1();
            abrir.Show();
            this.Close();
        }


        private void carregarTabela()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sql = "SELECT id, nome_jogo, quantidade, preco_unidade, classificacao FROM produtos";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable tabelaa = new DataTable();

                            adapter.Fill(tabelaa);

                            tabela.ItemsSource = tabelaa.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
