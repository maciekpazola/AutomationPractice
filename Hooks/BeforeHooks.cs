using NUnit.Framework;
using TestUtilities.Logs;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class BeforeHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        private readonly FeatureContext _featureContext = featureContext;
        private readonly ScenarioContext _scenarioContext = scenarioContext;
        private readonly Logger _logger = new(scenarioContext.ScenarioInfo.Title);
    }
}
