using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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

namespace CRUD_Products
{
    /// <summary>
    /// Lógica interna para ConfirmacaoID.xaml
    /// </summary>
    public partial class ConfirmacaoID : Window
    {

        public static string conexao = "Server=localhost;Database=CRUD_PRODUCTS;Uid=root;Pwd=;";
        


        public ConfirmacaoID()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string SQL = "SELECT id FROM produtos WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ID.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(ID.Text);

                            Atulizar telauptade = new Atulizar(id);
                            telauptade.Show();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("id não encontrado / incorreto");
                            ID.Clear();
                        }
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 abrir= new Window1();
            abrir.Show();
            this.Close();
        }
    }
}
