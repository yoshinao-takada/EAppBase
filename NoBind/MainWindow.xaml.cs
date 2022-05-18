using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoBind
{
    public interface IMainWindowExports
    {
        event RoutedEventHandler ButtonAction;

        int Counter { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowExports
    {
        Random rand;
        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();
        }


        Label[] Labels = new Label[6];

        #region IMainWindowExports_Impl
        event RoutedEventHandler IMainWindowExports.ButtonAction
        {
            add
            {
                MyButton.Click += value;
            }
            remove
            {
                MyButton.Click -= value;
            }
        }


        private int _counter = 0;
        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                int _counterMod6 = _counter % 6;
                byte[] byteBuffer = new byte[3];
                rand.NextBytes(byteBuffer);
                var _color = System.Windows.Media.Color.FromRgb(byteBuffer[0], byteBuffer[1], byteBuffer[2]);
                Labels[_counterMod6].Background = new SolidColorBrush(_color);
                ShowCounter.Content = _counter.ToString();
            }
        }
        #endregion

        public IMainWindowExports MyInterface
        {
            get => this as IMainWindowExports;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Labels[0] = Label0;
            Labels[1] = Label1;
            Labels[2] = Label2;
            Labels[3] = Label3;
            Labels[4] = Label4;
            Labels[5] = Label5;
        }
    }
}
