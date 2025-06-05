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
using System.Windows.Shapes;
using YORDER.AppData;
using YORDER.Model;
using YORDER.Views.Pages;

namespace YORDER
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameHelper.selectedFrame = MainFrm;
            MainFrm.Navigate(new OrdersPage());

        }

        private void NewOrdersHl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllOrdersHl_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new OrdersPage());
        }

        private void WIPOrdersHL_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FinishedOrdersHl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new NewOrderPage());
            //MainFrm.Content = new TextBlock { Text = "Тестовая страница" };

        }
    }
}
