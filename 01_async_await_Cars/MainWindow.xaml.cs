using Car.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _01_async_await_Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarQueries queries = new CarQueries();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await queries.GetAllCars();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await queries.GetFilteredCars();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //int a = await HardWork();
            MessageBox.Show("Cars Count: " + await queries.GetCarsCount());
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            await queries.CreateRandomData(int.Parse(countTB.Text));
        }
    }
}
