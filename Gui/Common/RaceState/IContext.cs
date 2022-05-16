namespace EAppBase.Gui.Common.RaceState
{
    public enum RaceState
    {
        OnSale, // voting tickets are on sale
        SaleClosed, // voting ticket sales are closed.
        Absent // The race does not exist.
    }

    /// <summary>
    /// Business logic data consumed by XAML objects and/or their code behind.
    /// </summary>
    public interface IVariableConsumer
    {
        System.Windows.Media.Brush Foreground { get; }
        System.Windows.Media.Brush Background { get; }
    }

    /// <summary>
    /// Business logic dataa provided by external business logic controllers.
    /// </summary>
    public interface IVariableProvider
    {
        RaceState RaceState { set; }
    }

    /// <summary>
    /// Auxilliary settings consumed by XAML objects and/or their code behind.
    /// </summary>
    public interface ISemifixedConsumer
    {
        /// <summary>
        /// Object outline width
        /// </summary>
        double Width { get; }
        /// <summary>
        /// Object outline height
        /// </summary>
        double Height { get; }
        /// <summary>
        /// Object caption font size
        /// </summary>
        double FontSize { get; }
        /// <summary>
        /// Special corner radius applied only to this control
        /// </summary>
        System.Windows.CornerRadius CornerRadius { get; }
    }

    /// <summary>
    /// Auxilliary settings controlled by externa initializers
    /// </summary>
    public interface ISemifixedProvider
    {
        /// <summary>
        /// A parameter defining the object height.
        /// For example, Window height = 480, LinesPerWindowHeight = 48, then Height = 10.
        /// i.e. (Window height) = LinesPerWindowHeight * ISemifixedConsumer.Height
        /// </summary>
        int LinesPerWindowHeight { set; }
        /// <summary>
        /// Caption text displayed on the object face.
        /// </summary>
        string Caption { get; set; }
    }

    public interface IContext
        : IVariableConsumer, IVariableProvider, ISemifixedConsumer, ISemifixedProvider
    {
    }
}
