namespace SoundGUI.Services;

public interface ISoundService
{
    void PlayTimes(short count);

    bool SetPath(string path);
}