using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Formula1.CoreTest
{
    [TestClass()]
    public class ResultCalculatorTests
    {
        [TestMethod()]
        public void R01_GetDriverWmTableTest()
        {
            var driverResults = ResultCalculator.GetDriverWmTable().ToArray();
            Assert.AreEqual("Hamilton Lewis", driverResults[0].Competitor.Name);
            Assert.AreEqual(281, driverResults[0].Points);
            Assert.AreEqual("Stroll Lance", driverResults[11].Competitor.Name);
            Assert.AreEqual(32, driverResults[11].Points);
        }

        [TestMethod()]
        public void R02_GetTeamWmTableTest()
        {
            var teamResults = ResultCalculator.GetTeamWmTable().ToArray();
            Assert.AreEqual("Mercedes", teamResults[0].Competitor.Name);
            Assert.AreEqual(503, teamResults[0].Points);
            Assert.AreEqual("Haas F1 Team", teamResults[7].Competitor.Name);
            Assert.AreEqual(37, teamResults[7].Points);
        }

    }
}