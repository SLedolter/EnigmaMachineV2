using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EnigmaMachineV2;

namespace EnigmaMachineV2Tests {
  [TestClass]
  public class EnigmaMachineTests {
    [TestMethod]
    public void Test_Simple_Enigma_Rotor1_Reflector_No_Stepping_With_A() {
      EnigmaMachine enigmaMachine = new EnigmaMachine("Rotor 1 - Reflector");

      char result = enigmaMachine.EncodeLetter('A');
      char expected = 'U';

      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Simple_Enigma_Rotor1_Reflector_No_Stepping_With_X() {
      EnigmaMachine enigmaMachine = new EnigmaMachine("Rotor 1 - Reflector");

      char result = enigmaMachine.EncodeLetter('X');
      char expected = 'K';

      Assert.AreEqual(expected, result);
    }
  }
}

