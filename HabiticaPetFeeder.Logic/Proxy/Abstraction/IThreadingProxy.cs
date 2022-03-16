using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Proxy.Abstraction;

public interface IThreadingProxy
{
    Task WaitForSecondsAsync(int seconds);
}
