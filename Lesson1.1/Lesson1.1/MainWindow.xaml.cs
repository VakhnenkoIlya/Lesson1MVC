using Newtonsoft.Json.Serialization;
using NPOI.SS.Formula.Functions;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Lesson1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread;
        public MainWindow()
        {
            InitializeComponent();
            thread = new(Fibonachi);
            thread.Start();

        }

        public void Fibonachi()
        {
            try
            {
                int prev = 1;
                int current = 1;
                int temp;
                while (current < 6000)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                    new Action(() =>
                    {
                        TextBox1.Text = current.ToString();
                        temp = current;
                        current = current + prev;
                        prev = temp;
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.ContextIdle,
                        new Action(() =>
                        {
                            Regulate();
                        }));
                    }));
                }
            }
            catch (ThreadInterruptedException e)
            {
                MessageBox.Show($"{e}");
            }
        }

        private void Regulate()
        {

            Application.Current.Dispatcher.Invoke(DispatcherPriority.ContextIdle,
            new Action(() =>
            {
                TimeTextBox.Text = "1";

            }));
            Thread.Sleep(1000);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.ContextIdle,
            new Action(() =>
            {
                TimeTextBox.Text = "2";

            }));
            Thread.Sleep(1000);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.ContextIdle,
            new Action(() =>
            {
                TimeTextBox.Text = "3";
            }));
            Thread.Sleep(1000);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thread.Interrupt();
        }
    }
}



