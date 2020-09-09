using System;

namespace BackgroundOperations
{
    public class ConsoleProgress<T> : IProgress<T>
    {
        public void Report(T value)
        {
            Console.WriteLine($"Progress: {value}");
        }
    }
}