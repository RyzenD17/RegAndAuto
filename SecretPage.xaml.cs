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
    /// Логика взаимодействия для SecretPage.xaml
    /// </summary>
    public partial class SecretPage : Page
    {
        List<Orders> Order = new List<Orders>();
        List<Orders> ListSearch = new List<Orders>();
        public SecretPage()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Base.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] Arr = sr.ReadLine().Split(';');
                    Order.Add(new Orders() { Name = Arr[0], Phone = Arr[1], Type = Arr[2], Date = Arr[3], Time = Arr[4], Pets=Arr[5] });
                }
            }
            DGOrders.ItemsSource = Order;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new FirtsPage());
        }

        private void CbName_Checked(object sender, RoutedEventArgs e)
        {
            DGOrders.Visibility = Visibility.Visible;
            cName.Visibility = Visibility.Visible;
        }

        private void CbName_Unchecked(object sender, RoutedEventArgs e)
        {
            cName.Visibility = Visibility.Hidden;
            if (CbPhone.IsChecked==false && CbType.IsChecked == false && CbDate.IsChecked == false && CbTime.IsChecked == false && CbPets.IsChecked == false)
            {
                DGOrders.Visibility = Visibility.Hidden;
            }
        }

        private void CbPhone_Checked(object sender, RoutedEventArgs e)
        {
            DGOrders.Visibility = Visibility.Visible;
            cPhone.Visibility = Visibility.Visible;
        }

        private void CbPhone_Unchecked(object sender, RoutedEventArgs e)
        {
            cPhone.Visibility = Visibility.Hidden;
            if (CbName.IsChecked == false && CbType.IsChecked == false && CbDate.IsChecked == false && CbTime.IsChecked == false && CbPets.IsChecked == false)
            {
                DGOrders.Visibility = Visibility.Hidden;
            }
        }

        private void CbType_Checked(object sender, RoutedEventArgs e)
        {
            DGOrders.Visibility = Visibility.Visible;
            cType.Visibility = Visibility.Visible;
        }

        private void CbType_Unchecked(object sender, RoutedEventArgs e)
        {
            cType.Visibility = Visibility.Hidden;
            if (CbPhone.IsChecked == false && CbName.IsChecked == false && CbDate.IsChecked == false && CbTime.IsChecked == false && CbPets.IsChecked == false)
            {
                DGOrders.Visibility = Visibility.Hidden;
            }
        }

        private void CbDate_Checked(object sender, RoutedEventArgs e)
        {
            DGOrders.Visibility = Visibility.Visible;
            cDate.Visibility = Visibility.Visible;
        }

        private void CbDate_Unchecked(object sender, RoutedEventArgs e)
        {
            cDate.Visibility = Visibility.Hidden;
            if (CbPhone.IsChecked == false && CbType.IsChecked == false && CbName.IsChecked == false && CbTime.IsChecked == false && CbPets.IsChecked == false)
            {
                DGOrders.Visibility = Visibility.Hidden;
            }
        }

        private void CbTime_Checked(object sender, RoutedEventArgs e)
        {
            DGOrders.Visibility = Visibility.Visible;
            cTime.Visibility = Visibility.Visible;
        }

        private void CbTime_Unchecked(object sender, RoutedEventArgs e)
        {
            cTime.Visibility = Visibility.Hidden;
            if (CbPhone.IsChecked == false && CbType.IsChecked == false && CbDate.IsChecked == false && CbName.IsChecked == false && CbPets.IsChecked == false)
            {
                DGOrders.Visibility = Visibility.Hidden;
            }
        }

        private void CbPets_Checked(object sender, RoutedEventArgs e)
        {
            DGOrders.Visibility = Visibility.Visible;
            cPets.Visibility = Visibility.Visible;
        }

        private void CbPets_Unchecked(object sender, RoutedEventArgs e)
        {
            cPets.Visibility = Visibility.Hidden;
            if (CbPhone.IsChecked == false && CbType.IsChecked == false && CbDate.IsChecked == false && CbTime.IsChecked == false && CbName.IsChecked == false)
            {
                DGOrders.Visibility = Visibility.Hidden;
            }
        }

        private void DGOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            if (RBSearchType.IsChecked == true)

            {
                for (int i = 0; i < Order.Count; i++)
                {
                    if (TBSearch.Text == Order[i].Type)
                    {
                        Orders p = new Orders
                        {
                            Name = Order[i].Name,
                            Phone = Order[i].Phone,
                            Type = Order[i].Type,
                            Date = Order[i].Date,
                            Time = Order[i].Time,
                            Pets = Order[i].Pets
                        };
                        ListSearch.Add(p);
                    }
                }
                DGOrders.ItemsSource = ListSearch;
            }

            if (RBSearchPets.IsChecked == true)

            {
                for (int i = 0; i < Order.Count; i++)
                {
                    if (TBSearch.Text == Order[i].Pets)
                    {
                        Orders p = new Orders
                        {
                            Name = Order[i].Name,
                            Phone = Order[i].Phone,
                            Type = Order[i].Type,
                            Date = Order[i].Date,
                            Time = Order[i].Time,
                            Pets = Order[i].Pets
                        };
                        ListSearch.Add(p);
                    }
                }
                DGOrders.ItemsSource = ListSearch;
            }


        }

        private void RBSearchType_Checked(object sender, RoutedEventArgs e)
        {
            BSearch.IsEnabled = true;
        }

        private void RBSearchType_Unchecked(object sender, RoutedEventArgs e)
        {
            BSearch.IsEnabled = false;
        }

        private void RBSearchPets_Checked(object sender, RoutedEventArgs e)
        {
            BSearch.IsEnabled = true;
        }

        private void RBSearchPets_Unchecked(object sender, RoutedEventArgs e)
        {
            BSearch.IsEnabled = false;
        }

        private void BSearchClear_Click(object sender, RoutedEventArgs e)
        {
            RBSearchType.IsChecked = false;
            RBSearchPets.IsChecked = false;
            TBSearch.Text = "";
            ListSearch.Clear();
            DGOrders.ItemsSource = Order;
        }
    }
}
