using System;

namespace AutofacExamples.Services
{
    public interface ILuckyNumberService
    {
        int GetLuckyNumber();
    }

    public class LuckyNumberService : ILuckyNumberService
    {
        public int GetLuckyNumber()
        {
            return new Random().Next(1, 100);
        }
    }
}
