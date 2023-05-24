using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace SoundGUI.Stores;

public class SettingsStore : ReactiveObject
{

    #region Instanse

    public static SettingsStore Instanse => _instanse;
    
    private static SettingsStore _instanse = new ();
    
    #endregion

    [Reactive] public float SoundVolume { get; set; } = 0.5f;
}