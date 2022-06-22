using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using static System.Net.WebRequestMethods;

namespace StartDock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // https://s-engineer.tistory.com/291
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                //if (false == p.WaitForInputIdle())
                if (p.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                Debug.WriteLine(p.Id + " " + p.ProcessName + " " + p.MainWindowTitle);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}