using System.Windows.Media;

namespace EAppBase.Libs
{
    public struct ForegroundAndBackground
    {
        public Color _foreground;
        public Color _background;

        public static ForegroundAndBackground FromColors(Color fore, Color back)
        {
            var fb = new ForegroundAndBackground();
            fb._foreground = fore;
            fb._background = back;
            return fb;
        }
    }
    public class ColorHelper
    {
        public static readonly ForegroundAndBackground ColorsForRaceStateOnSale =
            ForegroundAndBackground.FromColors(Colors.White, Colors.Blue);
        public static readonly ForegroundAndBackground ColorsForRaceStateSaleClosed =
            ForegroundAndBackground.FromColors(Colors.White, Colors.Red);
        public static readonly ForegroundAndBackground ColorsForRaceStateAbsent =
            ForegroundAndBackground.FromColors(
                Color.FromRgb(128, 128, 128), Color.FromRgb(100, 100, 100));
    }
}
