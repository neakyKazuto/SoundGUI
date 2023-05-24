using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;


namespace SoundGUI.Services;

public sealed class SoundService : ISoundService
{
    #region Fields

    private string _path = "";

    private TimeSpan _fileDuration;

    private readonly WaveOutEvent _waveOutEvent = new ();

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
            await Task.Delay(_fileDuration*i, ct).ContinueWith(_ =>
            {
                _waveOutEvent?.Stop();
                
                var reader = new Mp3FileReader(_path);
                
                _waveOutEvent?.Init(reader); 
                _waveOutEvent?.Play();
                
            },ct).ConfigureAwait(false);
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