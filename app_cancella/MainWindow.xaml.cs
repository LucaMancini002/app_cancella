using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace app_cancella
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool stop = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        //bottone 1
        private void Btn_start1_Click(object sender, RoutedEventArgs e)
        {
            stop = false;
            Task.Factory.StartNew(() => DoWork(100, 1000, lbl_count1));
        }


        //bottone 2
        private void Btn_start2_Click(object sender, RoutedEventArgs e)
        {
            stop = false;
            int max = Convert.ToInt32(txt_max2.Text);
            Task.Factory.StartNew(() => DoWork(max, 1000, lbl_count2));
        }

        //bottone 3
        private void Btn_start3_Click(object sender, RoutedEventArgs e)
        {
            stop = false;
            int delay = Convert.ToInt32(txt_max2.Text);
            int max = Convert.ToInt32(txt_max2.Text);
            Task.Factory.StartNew(() => DoWork(max, delay, lbl_count3));
        }
        private void DoWork(int max, int delay, Label lbl)
        {
            for (int i = 0; i < max; i++)
            {
                Dispatcher.Invoke(() => UpdateUI(i, lbl));
                Thread.Sleep(delay);


                if (stop)
                    break;
            }
        }
        private void UpdateUI(int i, Label lbl)
        {
            lbl.Content = i.ToString();
        }
        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            stop = true;
        }
    }
}
