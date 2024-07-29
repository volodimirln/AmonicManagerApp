using AmonicManagerApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestsAmonicManagerApp
{
    [TestClass]
    public class StatisticTests
    {
        [TestMethod]
        public void TestFlyingCount_Execute()
        {
            int result = StartViewModel.ViewModel.FlyingCount;
            Assert.AreEqual(result, 15);
        }
        [TestMethod]
        public void TestTicketCount_Execute()
        {
            int result = StartViewModel.ViewModel.TicketCount;
            Assert.AreEqual(result, 5);
        }
    }
}
