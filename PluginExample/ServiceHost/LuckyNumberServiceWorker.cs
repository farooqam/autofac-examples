using System;
using AutofacExamples.Services;

namespace ServiceHost
{
    public class LuckyNumberServiceWorker : IServiceWorker
    {
        private readonly ILuckyNumberService _luckyNumberService;

        public LuckyNumberServiceWorker(ILuckyNumberService luckyNumberService)
        {
            _luckyNumberService = luckyNumberService;
        }
        public void Run()
        {
            int number = _luckyNumberService.GetLuckyNumber();
            OnData?.Invoke(number);
        }

        public Action<object> OnData { get; set; }
    }
}
