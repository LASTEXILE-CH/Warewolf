using System;
using Dev2.Data.Decision;
using NUnit.Framework;
using Warewolf.Storage;

namespace Dev2.Data.Tests.PathOperations
{
    [TestFixture]
    public class Dev2DataListDecisionHandlerTests
    {
        [Test]
        public void Dev2DataListDecisionHandler_ShouldHaveInstance()
        {
            Assert.IsNotNull(Dev2DataListDecisionHandler.Instance);
        }

        [Test]
        public void Dev2DataListDecisionHandler_AssEnvironment_ShouldIncreaseEnvironmentsCount()
        {
            var instance = Dev2DataListDecisionHandler.Instance;
            Assert.IsNotNull(instance);
            instance.AddEnvironment(Guid.NewGuid(), new ExecutionEnvironment());
        }
    }
}
