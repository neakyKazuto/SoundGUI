using SoundGUI.ViewModels.Base;

namespace SoundGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region VMDS

    public MainViewModel MainVMD { get; } = new();
    
    public SettingsViewModel SettingsVMD { get; } = new();
    
    #endregion

    #region Constructos

    public MainWindowViewModel()
    { }

    #endregion
}