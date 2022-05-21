using System.Windows;

namespace NoBind
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IMainWindowExports _windowAPI = null;
        MainWindow _mainWindow;
        /// <summary>
        /// It is registered to ButtonAction of MainWindow.
        /// This event handler only increment the counter but causes
        /// many actions in MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonAction(object sender, RoutedEventArgs e)
        {
            int i = _windowAPI.Counter;
            i++;
            _windowAPI.Counter = i;
        }

        /// <summary>
        /// Create a new instance of MainWindow and register this own event handler to
        /// the instance.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            _windowAPI = _mainWindow.MyInterface; // Get the published interface of MainWindow class.
            _windowAPI.ButtonAction += ButtonAction; // register my own button action to the main window.
        }
    }


}
