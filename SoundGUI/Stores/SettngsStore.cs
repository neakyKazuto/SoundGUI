using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace SoundGUI.Stores;

public class SettingsStore : ReactiveObject
{

    private static SettingsStore _instanse = new ();
    
    #region Instanse

    public static SettingsStore Instanse => _instanse;

    #endregion

    [Reactive] public float SoundVolume { get; set; } = 1;
}