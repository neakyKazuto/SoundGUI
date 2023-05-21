using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using SoundGUI.ViewModels;
using SoundGUI.Views;

namespace SoundGUI.Infrastructure;

public class ViewLocator : IDataTemplate
{
    private readonly Dictionary<Type, Type> _vmdToViewTypes = new()
    {
        {typeof(MainViewModel), typeof(Main)},
        {typeof(SettingsViewModel), typeof(SettingsView)}
    };
    
    
    public IControl Build(object vmd)
    {
        IControl? view = (Control)Activator.CreateInstance(typeof(NoDataView))!;

        try
        {
            var viewType = _vmdToViewTypes[vmd.GetType()];

            view = (Control)Activator.CreateInstance(viewType)!;
        }
        catch(Exception)
        {
            // TODO logger
        }
        
        return view;
    }

    public bool Match(object data) => data is ReactiveObject;
}