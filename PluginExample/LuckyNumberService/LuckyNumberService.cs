using System;

namespace AutofacExamples.Services
{
    public interface ILuckyNumberService
    {
        int GetLuckyNumber();
    }

    public class LuckyNumberService : ILuckyNumberService
    {
        private readonly LuckyNumberServiceSettings _settings;

        public LuckyNumberService(LuckyNumberServiceSettings settings)
        {
            _settings = settings;
        }
        public int GetLuckyNumber()
        {
            return new Random().Next(_settings.Min, _settings.Max);
        }
    }

    public class LuckyNumberServiceSettings
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
