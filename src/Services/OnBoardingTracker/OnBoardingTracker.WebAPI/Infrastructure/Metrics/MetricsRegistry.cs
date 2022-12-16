using App.Metrics;
using App.Metrics.Counter;

namespace OnBoardingTracker.WebApi.Infrastructure.Metrics
{
    public static class MetricsRegistry
    {
        public static CounterOptions CreatedJobType => new CounterOptions
        {
            Name = "Job Type Created",
            Context = "onboardingtracker-api",
            MeasurementUnit = Unit.Calls
        };
    }
}
