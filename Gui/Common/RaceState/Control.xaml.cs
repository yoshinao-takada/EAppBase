using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace EAppBase.Gui.Common.RaceState
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : ControlBase, IVariableProvider, ISemifixedProvider
    {
        public Control()
        {
            InitializeComponent();
        }

        #region IVariableProvider_Impl
        public RaceState RaceState
        {
            set
            {
                var context = DataContext as IVariableProvider;
                if (context == null)
                {
                    throw new NullReferenceException();
                }
                context.RaceState = value;
            }
        }
        #endregion

        #region ISemifixedProvider_Impl
        public int LinesPerWindowHeight
        {
            set
            {
                var context = DataContext as ISemifixedProvider;
                if (context == null)
                {
                    throw new NullReferenceException();
                }
                context.LinesPerWindowHeight = value;
            }
        }
        public string Caption
        {
            get
            {
                var context = DataContext as ISemifixedProvider;
                if (context == null)
                {
                    throw new NullReferenceException();
                }
                return context.Caption;
            }
            set
            {
                var context = DataContext as ISemifixedProvider;
                if (context == null)
                {
                    throw new NullReferenceException();
                }
                context.Caption = value;
            }
        }
        #endregion
    }
}
