namespace Core.Helpers
{
    public static class WaitHelper
    {
        public static TimeSpan DefaultTimeStep = TimeSpan.FromMilliseconds(100);

        public static bool WaitForCondition(Func<bool> condition, int timeoutInSeconds = 15, bool throwTimeoutException = false, string errorMessage = null)
        {
            var stopDate = DateTime.Now.Add(TimeSpan.FromSeconds(timeoutInSeconds));

            while (stopDate > DateTime.Now)
            {
                try
                {
                    if (condition.Invoke())
                    {
                        return true;
                    }

                    if (DefaultTimeStep.TotalSeconds > timeoutInSeconds)
                    {
                        break;
                    }

                    Thread.Sleep(DefaultTimeStep);
                }
                catch (Exception e)
                {
                    if (errorMessage == null)
                    {
                        errorMessage = e.Message;
                    }
                }
            }

            if (throwTimeoutException)
            {
                throw new TimeoutException(errorMessage);
            }

            return false;
        }

        public static bool WaitNoError(Action action, int timeoutInSec = 10, string errorMessage = null, bool throwTimeoutException = true)
        {
            return WaitForCondition(() =>
            {
                action();
                return true;
            }, timeoutInSec, throwTimeoutException, errorMessage: errorMessage);
        }
    }
}
