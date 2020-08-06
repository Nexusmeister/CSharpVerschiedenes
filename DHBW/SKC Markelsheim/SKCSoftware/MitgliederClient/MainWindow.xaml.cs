using MitgliederClient.Klassen.Helper;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace MitgliederClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test";
        private string query = "SELECT * FROM user";
        public MainWindow()
        {
            InitializeComponent();
            Title += Applikation.GetVersion();
            Test();
            
        }

        private async Task Test()
        {
            var sql = "select * from mitglieder";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var t = reader.GetSchemaTable();
                while (reader.Read())
                {
                    //string[] test = { reader.GetString(0), reader.GetString(1) };
                    //gridMitglieder.Items.Add(test);
                    gridMitglieder.Items.Insert(0, reader.GetString(0));
                    gridMitglieder.Items.Insert(1, reader.GetString(1));
                    gridMitglieder.Items.Refresh();
                    gridMitglieder.UpdateLayout();
                    
                    //reader.NextResult();
                }
            }

            con.Close();
        }
    }
}
