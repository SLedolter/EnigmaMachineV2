using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EnigmaMachineV2;

namespace EnigmaMachineV2Tests {
  [TestClass]
  public class CylinderTests {
    [TestMethod]
    public void Test_Roto1_Encoding() {
      Cylinder rotor1 = new Cylinder("I", "A", EnigmaConfig.TURNOVER_1_CYLINDER_1, EnigmaConfig.CYLINDER_1);

      char expected = 'E';
      char result = rotor1.EncodeLetter('A', true);

      Assert.AreEqual(expected, result);
    }
  }
}
