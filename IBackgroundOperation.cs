using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundOperations
{
    public interface IBackgroundOperation<TInput, TOutput, TProgress>
    {
        string DisplayName { get; }
        string Description { get; }

        Task<Result<TOutput>> RunAsync(
            TInput input, 
            IProgress<TProgress> progress, 
            CancellationToken cancellationToken);
    }
}