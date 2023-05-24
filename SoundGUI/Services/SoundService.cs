using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;
using SoundGUI.Stores;


namespace SoundGUI.Services;

public sealed class SoundService : ISoundService
{
    #region Fields

    private string _path = "";

    private TimeSpan _fileDuration;

    private readonly WaveOutEvent _waveOutEvent = new ();
    
    private SettingsStore Settings { get; set; } = SettingsStore.Instanse;

    #endregion

    #region Constructors
    
    public SoundService()
    {
        SetPath(Path.Combine(Directory.GetCurrentDirectory(), "Resources","Sound.mp3"));
    }
    #endregion

    #region Methods

    public async Task PlayTimes(int count, CancellationToken ct = default)
    {
        for (short i = 0; i < count; i++)
        {
            if (i != 0)
                await Task.Delay(_fileDuration, ct);
            
            var soundTask = new Task(() =>
            {
                _waveOutEvent?.Stop();
                _waveOutEvent.Volume = Settings.SoundVolume;
                
                var reader = new Mp3FileReader(_path);
                
                _waveOutEvent?.Init(reader); 
                _waveOutEvent?.Play();
            }, ct);
            
            soundTask.Start();
        }
    }

    public bool SetPath(string path)
    {
        try
        {
            _fileDuration = new AudioFileReader(path).TotalTime;
            
            _path = path;
        }
        catch
        {
            return false;
        }

        return true;
    }

    public void Cancel()
    {
        _waveOutEvent?.Stop();
    }

    #endregion
}