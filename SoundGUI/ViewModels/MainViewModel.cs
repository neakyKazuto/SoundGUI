using ReactiveUI.Fody.Helpers;
using SoundGUI.ViewModels.Base;

namespace SoundGUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    [Reactive]
    public string Text { get; set; }
    
}