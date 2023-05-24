using ReactiveUI.Fody.Helpers;
using SoundGUI.Stores;
using SoundGUI.ViewModels.Base;

namespace SoundGUI.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    [Reactive] public SettingsStore Settings { get; set; } = SettingsStore.Instanse;
}