using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAppBase.Gui
{
    public class ControlBase : UserControl, EAppBase.Gui.Common.IDepends
    {
        #region IDepends_Impl
        public ISharedGeometries SharedGeometries
        {
            get
            {
                var context = DataContext as EAppBase.Gui.Common.IDepends;
                if (context == null)
                {
                    throw new NullReferenceException();
                }
                return context.SharedGeometries;
            }
            set
            {
                var context = DataContext as EAppBase.Gui.Common.IDepends;
                if (context == null)
                {
                    throw new NullReferenceException();
                }
                context.SharedGeometries = value;
            }
        }
        #endregion
    }
}
