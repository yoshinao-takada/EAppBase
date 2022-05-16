using System.Windows.Media;
using EAppBase.Gui.Common.RaceState;

namespace Gui.Common.RaceStates
{
    public interface IVariableConsumer
    {
        Brush Foreground(int index);
        Brush Background(int index);
    }
    public interface IVariableProvider
    {
        void SetRaceState(int index, RaceState state);
    }
    public interface ISemifixedConsumer
    {
        int Count { get; }
        string Caption(int index);
        double LineHeight { get; }
    }

    public class BeginAndCount
    {
        public int Begin { get; set; }
        public int Count { get; set; }
    }

    public interface ISemifixedProvider
    {
        BeginAndCount CaptionSequence { set; }
        int LinesPerWindowHeight { set; }
    }
    public interface IContext : IVariableConsumer, IVariableProvider, ISemifixedConsumer, ISemifixedProvider
    {
    }
}
