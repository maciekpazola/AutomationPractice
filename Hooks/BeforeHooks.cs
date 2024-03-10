using NUnit.Framework;
using TestUtilities.Logs;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class BeforeHooks
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly Logger _logger;
        public BeforeHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _logger = new(_featureContext, _scenarioContext);
        }
    }
}
