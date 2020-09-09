using System.Collections.Generic;

namespace BackgroundOperations
{
    public abstract class Result<T>
    {
    }

    public class CancelledResult<T> : Result<T>
    {
    }

    public class ErrorResult<T> : Result<T>
    {
        public IList<string> Errors { get; }
    }

    public class SuccessResult<T> : Result<T>
    {
        public T Result { get; }

        public SuccessResult(T result)
        {
            Result = result;
        }
    }
}