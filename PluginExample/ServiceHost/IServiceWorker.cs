using System;

namespace ServiceHost
{
    public interface IServiceWorker
    {
        void Run();

        Action<object> OnData { get; set; }
    }
}
