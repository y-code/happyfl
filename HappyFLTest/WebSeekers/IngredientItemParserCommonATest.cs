using System;
using System.Collections.Generic;
using System.Linq;
using HappyFL.Services.WebSeekers;
using NUnit.Framework;

namespace HappyFL.Test.WebSeekers
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public partial class IngredientItemParserCommonATest
    {
        public class TestCommonATestCase
        {
            public class ExpectedResult
            {
                public string Name { get; set; }
                public float Amount { get; set; }
                public string Unit { get; set; }
                public string Note { get; set; }
            }
            public string Input { get; set; }
            public List<ExpectedResult> Expected { get; } = new List<ExpectedResult>();
            public int ExpectedCount => Expected.Count;

            public override string ToString()
                => Input ?? "null";
        }

        public void TestCommonA(TestCommonATestCase testCase)
        {
            var parser = new IngredientItemParserCommonA();
            var result = parser.Parse(testCase.Input);

            Assert.That(result.Candidates, Has.Count.EqualTo(testCase.ExpectedCount));
            for (var i = 0; i < result.Candidates.Count(); i++)
            {
                Assert.That(result.Candidates.ElementAt(i).Name, Is.EqualTo(testCase.Expected[i].Name), "Ingredient name did not match.");
                Assert.That(result.Candidates.ElementAt(i).Amount, Is.EqualTo(testCase.Expected[i].Amount), "Ingredient amount did not match.");
                Assert.That(result.Candidates.ElementAt(i).Unit, Is.EqualTo(testCase.Expected[i].Unit), "Ingredient unit did not match");
                Assert.That(result.Candidates.ElementAt(i).Note, Is.EqualTo(testCase.Expected[i].Note), "Ingredient note did not match");
            }
        }

        [TestCaseSource(nameof(TestCaseSourceForUnit))]
        public void TestCommonAUnit(TestCommonATestCase testCase)
            => TestCommonA(testCase);

        [TestCaseSource(nameof(TestCaseSourceForAmount))]
        public void TestCommonAAmount(TestCommonATestCase testCase)
            => TestCommonA(testCase);

        [TestCaseSource(nameof(TestCaseSourceForRandom))]
        public void TestCommonARandom(TestCommonATestCase testCase)
            => TestCommonA(testCase);
    }
}
