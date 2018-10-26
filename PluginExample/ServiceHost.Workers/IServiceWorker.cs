using System;

namespace AutofacExamples.ServiceHost.Workers
{
    public interface IServiceWorker
    {
        void Run();

        Action<object> OnData { get; set; }
    }
}
