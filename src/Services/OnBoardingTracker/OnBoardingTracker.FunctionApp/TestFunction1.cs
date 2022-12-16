using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace OnBoardingTracker.FunctionApp
{
    public static class TestFunction1
    {
        [FunctionName("TestFunction1")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
