using ReactiveUI.Fody.Helpers;
using SoundGUI.ViewModels.Base;

namespace SoundGUI.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    [Reactive]
    public float SoundVolume{ get; set; }
}