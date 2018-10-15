using dotnet_code_challenge.DataProvider;
using dotnet_code_challenge.Helper;
using dotnet_code_challenge.Manager;
using dotnet_code_challenge.Test.Helper;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class RaceDataManagerTests
    {
        private Mock<IServiceProvider> serviceProviderMock;
        private Mock<ILogger> loggerMock;
        private Mock<ISourceProvider> sourceProviderMock;
        private IRaceDataManager manager;

        public RaceDataManagerTests()
        {
            serviceProviderMock = new Mock<IServiceProvider>();
            loggerMock = new Mock<ILogger>();
            sourceProviderMock = new Mock<ISourceProvider>();
            manager = new RaceDataManager(loggerMock.Object, serviceProviderMock.Object, sourceProviderMock.Object);
        }

        [Fact]
        public void GetHorsesFromAllSources_ReturnsEmpty_IfNoContentFound()
        {
            sourceProviderMock.Setup(x => x.GetAllSources()).Returns(new Dictionary<string, string>());

            var result = manager.GetHorsesFromAllSources();

            Assert.Empty(result);
        }

        [Fact]
        public void GetHorsesFromAllSources_LogsAnError_IfNoProviderFound()
        {
            sourceProviderMock.Setup(x => x.GetAllSources()).Returns(new Dictionary<string, string> { { "UnknownSource", "SomeDatatoProcess" } });
            serviceProviderMock.Setup(x => x.GetService(typeof(IEnumerable<IDataProvider>))).Returns(new List<IDataProvider> { new DummyProvider() });

            var result = manager.GetHorsesFromAllSources();

            loggerMock.Verify(x => x.LogError(It.Is<string>(l => l.Contains("Could not find a DataProvider for "))));
        }

        // More unit tests to be written to test the happy path and edge cases, mutiple providers,...
    }
}
