using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundOperations
{
    public static class Program
    {
        static async Task Main()
        {
            var operation = new TimerOperation("Timer", "Does stuff in the background");
            var tokenSource = new CancellationTokenSource();

            tokenSource.CancelAfter(5500);

            Console.WriteLine($"Running operation {operation.DisplayName}");

            var result = await operation.RunAsync(10, new ConsoleProgress<int>(), tokenSource.Token);
           
            switch (result)
            {
                case SuccessResult<int> sr:
                    Console.WriteLine($"Success! Result = {sr.Result}");
                    break;

                case CancelledResult<int> _:
                    Console.WriteLine($"Cancelled");
                    break;

                case ErrorResult<int> er:
                    Console.WriteLine("Error");
                    foreach(var e in er.Errors)
                    {
                        Console.WriteLine($"\t{e}");
                    }
                    break;

                default:
                    Console.WriteLine("Unknown error");
                    break;
            }
        }
    }
}