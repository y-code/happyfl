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
            DevDBSetup.DevDBSetup.Main();
        }
    }
}
