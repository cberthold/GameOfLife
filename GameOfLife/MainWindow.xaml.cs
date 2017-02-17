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

namespace GameOfLife
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

        private Task generator;
        private CancellationTokenSource tokenSource;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            generator = new TaskFactory().StartNew(async () =>
           {
               var token = tokenSource.Token;
               while (!token.IsCancellationRequested)
               {
                   await ctl1.DrawNextGenerationAsync();

                   await Task.Delay(50);
               }
           }, tokenSource.Token);
        }
    }
}
