using System.Threading;
using System.Threading.Tasks;

namespace SoundGUI.Services;

public interface ISoundService
{
    Task PlayTimes(int count, CancellationToken ct = default);

    bool SetPath(string path);

    void Cancel();
}