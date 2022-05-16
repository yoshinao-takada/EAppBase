using System.Windows;

namespace EAppBase.Gui
{
    public struct SharedGeometryData
    {
        public double WindowHeight { get; set; }
        public double WindowWidthPerWindowHeight { get; set; }
        public double BorderThicknessPerWindowHeight { get; set; }
        public double CornerRadiusPerWindowHeight { get; set; }
        public double FontSizePerLineHeight { get; set; }
        public double HorizontalTextPaddingPerLineHeight { get; set; }

        /// <summary>
        /// Default data set for experiments and development of controls of fan screen size
        /// </summary>
        /// <returns></returns>
        public static SharedGeometryData CreateDefaultFan()
        {
            SharedGeometryData data = new SharedGeometryData();
            data.WindowHeight = 1080.0; // Normal Full-HD height for observing shrinked and 90 deg rotated Full-HD window
            data.WindowWidthPerWindowHeight = 1080.0 / 1920.0; // Full-HD rotated by 90 degs.
            data.BorderThicknessPerWindowHeight = 1.0 / 480.0; // 1 pixel in standard VGA
            data.CornerRadiusPerWindowHeight = 2.0 / 480.0; // 2 pixels in standard VGA
            data.FontSizePerLineHeight = 0.7;
            data.HorizontalTextPaddingPerLineHeight = 0.5;
            return data;
        }
        /// <summary>
        /// Default data set for experiments and development of controls of maintenance screen size
        /// </summary>
        /// <returns></returns>
        public static SharedGeometryData CreateDefaultMnt()
        {
            SharedGeometryData data = new SharedGeometryData();
            data.WindowHeight = 768.0; // Normal Full-HD height for observing shrinked and 90 deg rotated Full-HD window
            data.WindowWidthPerWindowHeight = 1024.0 / 768.0; // Full-HD rotated by 90 degs.
            data.BorderThicknessPerWindowHeight = 1.0 / 480.0; // 1 pixel in standard VGA
            data.CornerRadiusPerWindowHeight = 2.0 / 480.0; // 2 pixels in standard VGA
            data.FontSizePerLineHeight = 0.7;
            data.HorizontalTextPaddingPerLineHeight = 0.5;
            return data;
        }
    }

    public interface ISharedGeometries
    {
        /// <summary>
        /// Window height common to a window group;
        /// e.g. windows shown on a rear display monitor, popup messge boxes, etc.
        /// </summary>
        double SharedWindowHeight { get; }

        /// <summary>
        /// Aspect ratio common to a window group
        /// </summary>
        double SharedWindowWidthPerWindowHeight { get; }

        /// <summary>
        /// Border thickness common to a window group
        /// </summary>
        double SharedBorderThicknessPerWindowHeight { get; }

        /// <summary>
        /// Corner radius common to a window group
        /// </summary>
        double SharedCornerRadiusPerWindowHeight { get; }

        /// <summary>
        /// ((Font size) / (Line height)) commont to a window group
        /// </summary>
        double SharedFontSizePerLineHeight { get; }

        /// <summary>
        /// Horizontal text padding common to a window group
        /// </summary>
        double SharedHorizontalTextPaddingPerLineHeight { get; }

        event DependencyPropertyChangedEventHandler SharedGeometryChanged;
    }
}
