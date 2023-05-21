using ReactiveUI.Fody.Helpers;
using SoundGUI.ViewModels.Base;

namespace SoundGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region VMDS

    [Reactive]
    public MainViewModel MainVMD { get; set; } = new();
    
    [Reactive]
    public SettingsViewModel SettingsVMD { get; set; } = new();
    
    #endregion

    #region Constructos

    public MainWindowViewModel()
    { }

    #endregion
}