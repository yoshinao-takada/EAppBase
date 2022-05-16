using System;
using System.Windows;

namespace EAppBase.Gui
{
    public class FanBase : System.Windows.Window, ISharedGeometries
    {
        protected static DependencyProperty SharedGeometriesProperty =
            DependencyProperty.Register("SharedGeometries", typeof(ISharedGeometries), typeof(FanBase));
        public FanBase() : base()
        {
            _sharedGeometryData = SharedGeometryData.CreateDefaultFan(); // experimental test data
            SetValue(SharedGeometriesProperty, this);
            Height = SharedWindowHeight;
            Width = SharedWindowHeight * SharedWindowWidthPerWindowHeight;
            WindowStyle = WindowStyle.None;
        }

        protected void UpdateWindowSize(EventArgs e)
        {
            if ((WindowState == WindowState.Maximized) || (WindowState == WindowState.Minimized))
            {
                return; // does nothing when the window is maximized or minimized.
            }
            double oldHeight = SharedWindowHeight;
            double newHeight = ActualHeight;
            SetSharedWindowHeight(ActualHeight);
            Width = SharedWindowWidthPerWindowHeight * SharedWindowHeight;
            if (SharedGeometryChanged != null)
            {
                var eDPChgd = new DependencyPropertyChangedEventArgs(SharedGeometriesProperty, (object)oldHeight, (object)newHeight);
                SharedGeometryChanged.Invoke(this, eDPChgd);
            }
        }

        #region ISharedGeometries_impl
        private SharedGeometryData _sharedGeometryData;
        public double SharedWindowHeight
        {
            get => _sharedGeometryData.WindowHeight;
        }
        public double SharedWindowWidthPerWindowHeight
        {
            get => _sharedGeometryData.WindowWidthPerWindowHeight;
        }
        public double SharedBorderThicknessPerWindowHeight
        {
            get => _sharedGeometryData.BorderThicknessPerWindowHeight;
        }
        public double SharedCornerRadiusPerWindowHeight
        {
            get => _sharedGeometryData.CornerRadiusPerWindowHeight;
        }
        public double SharedFontSizePerLineHeight
        {
            get => _sharedGeometryData.FontSizePerLineHeight;
        }
        public double SharedHorizontalTextPaddingPerLineHeight
        {
            get => _sharedGeometryData.HorizontalTextPaddingPerLineHeight;
        }
        public event DependencyPropertyChangedEventHandler SharedGeometryChanged;
        #endregion

        protected void SetSharedWindowHeight(double h)
        {
            _sharedGeometryData.WindowHeight = h;
        }
    }
}
