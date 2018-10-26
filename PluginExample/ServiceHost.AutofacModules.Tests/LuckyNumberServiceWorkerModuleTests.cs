using Autofac;
using AutofacExamples.ServiceHost.Workers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutofacExamples.ServiceHost.AutofacModules.Tests
{
    [TestClass]
    public class LuckyNumberServiceWorkerModuleTests
    {
        [TestMethod]
        public void ShouldRegisterServiceWorker()
        {
            // Arrange
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<LuckyNumberServiceWorkerModule>();
            IContainer container = builder.Build();

            // Act
            IServiceWorker worker = container.Resolve<IServiceWorker>();

            // Assert
            worker.Should().NotBeNull();

        }
    }
}
