using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EnigmaMachineV2;

namespace EnigmaMachineV2Tests {
  [TestClass]
  public class CylinderTests {
    [TestMethod]
    public void Test_Rotor1_Encoding_Before_Reflector_With_A() {
      Cylinder rotor1 = EnigmaMachineFactory.CreateRotor1('A');

      char expected = 'E';
      char result = rotor1.EncodeLetter('A', true);

      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Rotor1_Encoding_After_Reflector_With_A() {
      Cylinder rotor1 = EnigmaMachineFactory.CreateRotor1('A');

      char expected = 'U';
      char result = rotor1.EncodeLetter('A', false);

      Assert.AreEqual(expected, result);
    }
  }
}
