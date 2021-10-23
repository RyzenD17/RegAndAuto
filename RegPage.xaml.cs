using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace RegAndAuto
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        string path = "UsersData.csv";
        int id = 1;
        public RegPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new FirtsPage());
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(Convert.ToString(id) + ";");
                sw.Write(TBName.Text + ";");
                sw.Write(TBLogin.Text + ";");
                sw.Write(TBPassword.Password + "\n");
                id++;
                MessageBox.Show("Вы зарегистрированы");
                FrameClass.mainFrame.Navigate(new AutoPage());
            }
        }
    }
}
