using System.Threading.Tasks;

namespace HabiticaPetFeeder.Logic.Proxy.Interface;

public interface IThreadingProxy
{
    Task WaitForSecondsAsync(int seconds);
}
