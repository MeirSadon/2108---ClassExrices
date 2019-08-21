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
using System.Windows.Threading;

namespace _2108___ClassExrices___2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string NumberAsString { get; set; }
        public int NumberAsInt { get; set; }
        DispatcherTimer t = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            NumberAsString = "50";
            t.Interval = TimeSpan.FromSeconds(0.25);
            t.Tick += ChangeNumberWithDispatcherTimer;
        }

        private void myBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void myBtn_Click_1(object sender, RoutedEventArgs e)
        {
            //Way 1.
            //ChangeNumberWithAsyncAwait();

            //Way 2.
            //Task.Run(() => { ChangeNumberWithDispatcher(() => { myTxtBlock.Text = NumberAsString; }); });

            //Way 3.
            t.Start();//
        }
        private async void ChangeNumberWithAsyncAwait()
        {
            NumberAsInt = Convert.ToInt32(NumberAsString);
            while (NumberAsInt > 0)
            {
                NumberAsInt = Convert.ToInt32(NumberAsString);
                NumberAsInt--;
                NumberAsString = NumberAsInt.ToString();
                myTxtBlock.Text = NumberAsString;
                await Task.Run(() => { Thread.Sleep(250); });
            }
        }
        private void ChangeNumberWithDispatcher(Action a)
        {
            NumberAsInt = Convert.ToInt32(NumberAsString);
            while (NumberAsInt > 0)
            {
                NumberAsInt = Convert.ToInt32(NumberAsString);
                NumberAsInt--;
                NumberAsString = NumberAsInt.ToString();
                if (Dispatcher.CheckAccess())
                    a.Invoke();
                else
                    Dispatcher.Invoke(a);
                Thread.Sleep(250);
            }
        }

        private void ChangeNumberWithDispatcherTimer(object sender, EventArgs e)
        {
            NumberAsInt = Convert.ToInt32(NumberAsString);
            if (NumberAsInt > 0)
            {
                NumberAsInt = Convert.ToInt32(NumberAsString);
                NumberAsInt--;
                NumberAsString = NumberAsInt.ToString();
                myTxtBlock.Text = NumberAsString;
                Task.Run(() => { Thread.Sleep(250); });
            }
            if (NumberAsInt == 0)
                t.Stop();
        }

    }
}
