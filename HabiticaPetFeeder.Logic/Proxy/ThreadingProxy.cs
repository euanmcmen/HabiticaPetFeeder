using HabiticaPetFeeder.Logic.Proxy.Abstraction;
using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Proxy;

public class ThreadingProxy : IThreadingProxy
{
    public async Task WaitForSecondsAsync(int seconds)
    {
        await Task.Delay(seconds * 1000);
    }
}
