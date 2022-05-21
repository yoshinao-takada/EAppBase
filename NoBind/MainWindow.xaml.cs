using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoBind
{
    /// <summary>
    /// The interface exported by MainWindow. External code accesses MainWindow via the
    /// initerface. The interface does not contain anything directly related GUI;
    /// e.g. Brush, Label, Thickness, etc.
    /// </summary>
    public interface IMainWindowExports
    {
        /// <summary>
        /// This event triggers any external action by clicking the button at the bottom-left
        /// of MainWindow.
        /// </summary>
        event RoutedEventHandler ButtonAction;

        /// <summary>
        /// Incremented or decremented by external code. UI elements in MainWindow are
        /// automatically updated.
        /// </summary>
        int Counter { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowExports
    {
        Random rand;

        /// <summary>
        /// MainWindow keeps a random number generator to create a color on each
        /// click of the button. The random number generator is initialized here.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();
        }


        Label[] Labels = new Label[6];

        #region IMainWindowExports_Impl
        /// <summary>
        /// ButtonAction wraps the button click event of MyButton.
        /// MyButton is a button declared in the XAML code, MyWindow.xaml.
        /// </summary>
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

        /// <summary>
        /// Counter.set automatically render ShowCounter and Labels.
        /// </summary>
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

        /// <summary>
        /// It export MainWindow itself as an instance of an interface of IMainWindowExports.
        /// </summary>
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
