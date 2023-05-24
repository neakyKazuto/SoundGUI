using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SoundGUI.Extensions;
using SoundGUI.Services;
using SoundGUI.ViewModels.Base;

namespace SoundGUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Properties

    [Reactive] public string Text { get; set; } = "";

    #endregion
    
    #region Fields

    private readonly ISoundService _soundService;

    #endregion

    #region Constructors
    public MainViewModel()
    {
        _soundService = new SoundService();
        
        Start = ReactiveCommand.CreateFromObservable(()=>
            Observable.StartAsync(ct => _soundService.PlayTimes(Text.LineCount(),ct)).TakeUntil(Cancel));
        
        Cancel = ReactiveCommand.Create(() => { }, CanCancel);
    }
    #endregion
    
    #region Commands
    
    public IReactiveCommand Start { get; }
    
    public ReactiveCommand<Unit, Unit> Cancel { get; }

    private IObservable<bool> CanCancel => this.WhenAnyObservable(x => x.Start.IsExecuting);
    
    #endregion
}