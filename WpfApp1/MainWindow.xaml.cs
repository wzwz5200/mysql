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
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using System.Windows.Shapes;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        static String connetStr = "server=192.168.10.240;port=3306;user=wzwz5200;password=wzwz5200; database=wzwz5200;";
        MySqlConnection conn = new MySqlConnection(connetStr);
        private bool check()
        {
            bool result = false;
            string sql = "select * from c_key where kami = @para1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("para1", _6.Text);


            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = true;
            }

            return result;
        }
        private void _6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                if (check())
                {
                    Window1 Mn = new Window1();
                    Mn.Show();
                  
                    this.Close();
                }
                else
                {
                    MessageBox.Show("卡密错误");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void VK_tab(object sender, KeyEventArgs e)
        {

        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private void VK_RETURN(object sender, KeyEventArgs e)
        {

        }
        public class ButtonBrush
        {
            public static readonly DependencyProperty ButtonPressBackgroundProperty = DependencyProperty.RegisterAttached(
                "ButtonPressBackground", typeof(Brush), typeof(ButtonBrush), new PropertyMetadata(default(Brush)));

            public static void SetButtonPressBackground(DependencyObject element, Brush value)
            {
                element.SetValue(ButtonPressBackgroundProperty, value);
            }

            public static Brush GetButtonPressBackground(DependencyObject element)
            {
                return (Brush)element.GetValue(ButtonPressBackgroundProperty);
            }




       
        
       
        }
    }
}
