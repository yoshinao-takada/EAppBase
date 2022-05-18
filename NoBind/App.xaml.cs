using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        public void ButtonAction(object sender, RoutedEventArgs e)
        {
            int i = _windowAPI.Counter;
            i++;
            _windowAPI.Counter = i;
        }
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
