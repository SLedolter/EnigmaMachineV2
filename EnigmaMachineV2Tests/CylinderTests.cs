using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EnigmaMachineV2;

namespace EnigmaMachineV2Tests {
  [TestClass]
  public class CylinderTests {
    [TestMethod]
    public void Test_CylinderConstructor() {
      Cylinder cylinder = new Cylinder("I", "A", EnigmaConfig.TURNOVER_1_CYLINDER_1, EnigmaConfig.CYLINDER_1);
    }
  }
}
