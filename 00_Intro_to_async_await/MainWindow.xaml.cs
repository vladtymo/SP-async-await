using System;
using System.Collections.Generic;
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

namespace _00_Intro_to_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await MakeProgressAsync(); // async
            //t.Wait(); // freeze

            progressBar.Value++;
            listBox.Items.Add(await GenerateValueAsync()); // async
        }

        private Task MakeProgressAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                MessageBox.Show("Done!");
            });
        }

        private Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(random.Next(2000));
                return random.Next(100);
            });
        }
    }
}
