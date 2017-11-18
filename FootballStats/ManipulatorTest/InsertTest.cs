using System;
using DatabaseManipulator;
using DatabaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManipulatorTest
{
    [TestClass]
    public class InsertTest
    {
        [TestMethod]
        public void InesrtTest1()
        {
            Player player = new Player(44, "Football Guy");
            PlayerManipulator manipulator = new PlayerManipulator();
            manipulator.Insert(player);
        }
    }
}
