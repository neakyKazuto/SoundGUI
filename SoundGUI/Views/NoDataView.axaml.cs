using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SoundGUI.Views;

public partial class NoDataView : UserControl
{
    public NoDataView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}