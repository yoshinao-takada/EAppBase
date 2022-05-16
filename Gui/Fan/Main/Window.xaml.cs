using System;

namespace EAppBase.Gui.Fan.Main
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class Window : EAppBase.Gui.FanBase
    {
        public Window() : base()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateWindowSize(e);
        }

        private void OnSizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            UpdateWindowSize(e);
        }
    }
}
