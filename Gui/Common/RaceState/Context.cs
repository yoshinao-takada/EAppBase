using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAppBase.Libs;

namespace EAppBase.Gui.Common.RaceState
{
    public class Context : ObservableObject, IDepends, IContext
    {
        static ForegroundAndBackground[] _colors = new ForegroundAndBackground[3]
        {
            ColorHelper.ColorsForRaceStateOnSale,
            ColorHelper.ColorsForRaceStateSaleClosed,
            ColorHelper.ColorsForRaceStateAbsent
        };

        #region private_back_data_of_Properties
        System.Windows.Media.Brush _foreground;
        System.Windows.Media.Brush _background;
        double _rcpLinesPerWindowHeight;
        string _caption;
        #endregion

        #region IDepends_Impl
        ISharedGeometries _sharedGeometries;
        public ISharedGeometries SharedGeometries
        {
            get => _sharedGeometries;
            set => _sharedGeometries = value;
        }
        #endregion

        #region IVariableConsumer_Impl
        public System.Windows.Media.Brush Foreground
        {
            get => _foreground;
        }
        public System.Windows.Media.Brush Background
        {
            get => _background;
        }

        #endregion

        #region IVariableProvider_Impl
        public RaceState RaceState
        {
            set
            {
                var colorPair = _colors[(int)value];
                _foreground = new System.Windows.Media.SolidColorBrush(colorPair._foreground);
                _background = new System.Windows.Media.SolidColorBrush(colorPair._background);
                OnPropertyChanged(nameof(Foreground));
                OnPropertyChanged(nameof(Background));
            }
        }
        #endregion

        #region ISemifixedConsumer_Impl
        public double Width
        {
            get => Height;
        }
        public double Height
        {
            get => (_sharedGeometries == null) ? 
                10.0 :
                (_sharedGeometries.SharedWindowHeight * _rcpLinesPerWindowHeight);
        }
        public double FontSize
        {
            get => 0.7 * Height;
        }
        public System.Windows.CornerRadius CornerRadius
        {
            get => new System.Windows.CornerRadius(0.5 * Height);
        }
        #endregion

        #region ISemifixedProvider_Impl
        void OnAllSemifixedGeometriesChanged()
        {
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(FontSize));
            OnPropertyChanged(nameof(CornerRadius));
        }
        public int LinesPerWindowHeight
        {
            set
            {
                _rcpLinesPerWindowHeight = 1.0 / (double)value;
                OnAllSemifixedGeometriesChanged();
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                if (value.Length == 0 || value.Length > 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                SetProperty(ref _caption, value);
            }
        }
        #endregion
    }
}
