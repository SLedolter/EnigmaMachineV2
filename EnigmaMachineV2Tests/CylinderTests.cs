using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EnigmaMachineV2;

namespace EnigmaMachineV2Tests {
  [TestClass]
  public class CylinderTests {
    [TestMethod]
    public void Test_Rotor1_Encoding_Before_Reflector_With_A() {
      Cylinder rotor1 = EnigmaMachineFactory.CreateRotor1('A', 'A');

      char expected = 'E';
      char result = rotor1.EncodeLetterChained('A', true);

      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Rotor1_Encoding_After_Reflector_With_A() {
      Cylinder rotor1 = EnigmaMachineFactory.CreateRotor1('A', 'A');

      char expected = 'U';
      char result = rotor1.EncodeLetterChained('A', false);

      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Rotor1_Stepping_Last_Of_4_A() {
      Cylinder rotor1 = EnigmaMachineFactory.CreateRotor1('A', 'A');

      char expected = 'F';
      char input = 'A';
      char result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();
      result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();
      result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();
      result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();

      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Rotor1_Stepping_Last_Of_4_X() {
      Cylinder rotor1 = EnigmaMachineFactory.CreateRotor1('A', 'A');

      char expected = 'E';
      char input = 'X';
      char result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();
      result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();
      result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();
      result = rotor1.EncodeLetterChained(input, true);
      rotor1.IncreaseStepping();

      Assert.AreEqual(expected, result);
    }
  }
}
