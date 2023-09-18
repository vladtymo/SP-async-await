using System;
using System.Collections.Generic;
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

namespace _01_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // ----- async - allow to use await in method
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // types: double = Task<double>

            //double result = HardWork();             // freeze
            //double result = HardWorkAsync().Result;  // freeze

            // ------ await - can wait for the task asynchronouslly
            double result = await HardWorkAsync(); // asynchonous waiting for 2s>
         
            listBox.Items.Add(result);
        }

        private Task<double> HardWorkAsync()
        {
            return Task.Run(() =>
            {
                var number = new Random().Next(100);
                Thread.Sleep(2000);
                var result = Math.Pow(number, number);
                //MessageBox.Show($"Result: {result}");
                return result;
            });
        }
        private double HardWork()
        {
            var number = new Random().Next(100);
            Thread.Sleep(2000);
            var result = Math.Pow(number, number);
            //MessageBox.Show($"Result: {result}");
            return result;
        }
    }
}
