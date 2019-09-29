using System;
using NUnit.Framework;

namespace HappyFL.DB.Test
{
    [SetUpFixture]
    public class TestSetUp
    {
        [OneTimeSetUp]
        public void SetUpBeforeAnyTests()
        {
            Environment.SetEnvironmentVariable("DB_ENVIRONMENT", "Development");
            DevDBSetup.DevDBSetup.Main();
        }
    }
}
