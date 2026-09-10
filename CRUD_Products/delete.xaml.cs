using MySql.Data.MySqlClient;
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
    /// Lógica interna para delete.xaml
    /// </summary>
    public partial class delete : Window
    {

        public static string conexao = "Server=localhost;Database=CRUD_PRODUCTS;Uid=root;Pwd=;";
        public delete()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 voltar = new Window1();
            voltar.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool valido = true;


            if (!int.TryParse(ID.Text, out int id))
            {
                MessageBox.Show("Digite apenas números no ID!");
                valido = false;
                return;
            }

            if (valido = true)
            {
                string sql = "SELECT id, nome_jogo FROM produtos WHERE id = @id";

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ID.Text);


                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nomeJogo = reader["nome_jogo"].ToString();

                                MessageBoxResult resultado = MessageBox.Show($"Gostaria de remover o jogo {nomeJogo}", "?", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                                if (resultado == MessageBoxResult.OK)
                                {
                                    reader.Close();

                                    string SQL = "DELETE FROM produtos WHERE id = @id";

                           
                                    reader.Close();
                                        

                                        using (MySqlCommand deleteuser = new MySqlCommand(SQL, conn))
                                        {
                                            deleteuser.Parameters.AddWithValue("id", ID.Text);
                                            deleteuser.ExecuteNonQuery();
                                        }

                                        MessageBox.Show("jogo deletado com sucesso!");

                                    

                                }

                                if (resultado == MessageBoxResult.Cancel)
                                {
                                    MessageBox.Show("Operação cancelada :)");
                                }


                            }

                            else
                            {
                                MessageBox.Show("id não encontrado no banco!");
                            }
                        }


                    }
                }
            }
            

        }
    }
}
