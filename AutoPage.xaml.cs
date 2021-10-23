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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        List<DataClass> Users = new List<DataClass>();
        public AutoPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new FirtsPage());
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("UsersData.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] sArr = sr.ReadLine().Split(';');
                    Users.Add(new DataClass() { Id = sArr[0], Name = sArr[1], Login = sArr[2], Password = sArr[3] });
                }
            }
            DataClass User = Users.FirstOrDefault(x => x.Login == TBAutoLogin.Text && x.Password == PBAutoPassword.Password);
            if (User != null)
            {
                MessageBox.Show("Вы успешно авторизировались!");
                FrameClass.mainFrame.Navigate(new SecretPage());
            }
            else
            {
                MessageBox.Show("Пользователь не зарегистрирован", "Авторизация");
                MessageBoxResult result = MessageBox.Show("Хотите зарегистрироваться", "Регистрация", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        FrameClass.mainFrame.Navigate(new RegPage());
                        break;
                    case MessageBoxResult.No:
                        FrameClass.mainFrame.Navigate(new FirtsPage());
                        break;
                }

            }


        }
    }
}
