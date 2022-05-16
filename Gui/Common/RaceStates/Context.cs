using Microsoft.Toolkit.Mvvm.ComponentModel;
using EAppBase.Gui.Common;
using EAppBase.Gui;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using EAppBase.Libs;

namespace Gui.Common.RaceStates
{
    public class Context : ObservableObject, IDepends, IContext
    {
        #region private_data_backing_published_properties
        BeginAndCount _beginAndCount;
        int _linesPerWindowHeight;
        List<EAppBase.Gui.Common.RaceState.RaceState> _items;
        ForegroundAndBackground[] _colors;
        #endregion

        public Context() : base()
        {
            _items = new List<EAppBase.Gui.Common.RaceState.RaceState>();
            _colors = new ForegroundAndBackground[3]
            {
                ColorHelper.ColorsForRaceStateOnSale,
                ColorHelper.ColorsForRaceStateSaleClosed,
                ColorHelper.ColorsForRaceStateAbsent
            };
        }

        #region IDepnds_Impl
        ISharedGeometries _sharedGeometries;
        public ISharedGeometries SharedGeometries
        {
            get => _sharedGeometries;
            set
            {
                _sharedGeometries = value;
            }
        }
        #endregion

        #region IVariableConsumer_Impl
        public Brush Foreground(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            var raceState = _items[index];
            int colorIndex = (raceState == EAppBase.Gui.Common.RaceState.RaceState.Absent) ? 2 :
                (raceState == EAppBase.Gui.Common.RaceState.RaceState.OnSale) ? 0 : 1;
            return new SolidColorBrush(_colors[colorIndex]._foreground);
        }
        public Brush Background(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            var raceState = _items[index];
            int colorIndex = (raceState == EAppBase.Gui.Common.RaceState.RaceState.Absent) ? 2 :
                (raceState == EAppBase.Gui.Common.RaceState.RaceState.OnSale) ? 0 : 1;
            return new SolidColorBrush(_colors[colorIndex]._background);
        }
        #endregion

        #region IVariableProvider_Impl
        public void SetRaceState(int index, EAppBase.Gui.Common.RaceState.RaceState state)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            _items[index].RaceState = state;
        }
        #endregion

        #region ISemifixedConsumer_Impl
        public int Count
        {
            get => _beginAndCount.Count;
        }
        public string Caption(int index)
        {
            return (index + _beginAndCount.Begin).ToString();
        }
        public double LineHeight
        {
            get => _sharedGeometries.SharedWindowHeight / _linesPerWindowHeight;
        }
        #endregion

        #region ISemifixedProvider_Impl
        public BeginAndCount CaptionSequence
        {
            set
            {
                _beginAndCount = value;
            }
        }
        public int LinesPerWindowHeight
        {
            set
            {
                _linesPerWindowHeight = value;
                OnPropertyChanged(nameof(LineHeight));
            }
        }
        #endregion
    }
}
