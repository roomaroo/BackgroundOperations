using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundOperations
{
    public class TimerOperation : IBackgroundOperation<int, int, int>
    {
        public string DisplayName { get; }
        public string Description { get; }

        public TimerOperation(string displayName, string description)
        {
            DisplayName = displayName;
            Description = description;
        }


        public async Task<Result<int>> RunAsync(int input, IProgress<int> progress, CancellationToken cancellationToken)
        {
            try
            {
                var result = await Task.Run(() => DoWork(input, progress, cancellationToken));
                return new SuccessResult<int>(result);
            }
            catch (OperationCanceledException)
            {
                return new CancelledResult<int>();
            }
        }

        private int DoWork(int numberOfLoops, IProgress<int> progress, CancellationToken cancellationToken)
        {
            var start = Environment.TickCount;

            foreach(var i in Enumerable.Range(0, numberOfLoops))
            {
                cancellationToken.ThrowIfCancellationRequested();
                Thread.Sleep(1000);
                progress.Report((int)(100.0 * i / numberOfLoops));
            }

            return Environment.TickCount - start;
        }
    }
}