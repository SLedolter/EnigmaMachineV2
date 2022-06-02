using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public static class EnigmaMachineFactory {
    public static EnigmaMachine CreateSimpleRotor1ReflectorEnigmaMachine(string startPosition) {
      return new EnigmaMachine("Simple Rotor1 - Reflector A");
    }

    public static Cylinder CreateRotor1(string startPosition) {
      return new Cylinder("Rotor_I", startPosition, EnigmaConfig.TURNOVER_1_CYLINDER_1, EnigmaConfig.CYLINDER_1);
    }

    public static Cylinder CreateReflectorA() {
      return new Cylinder("Reflector", "A", "A", EnigmaConfig.TransformSwitchedPlugsToAlphabet(EnigmaConfig.REFLECTOR_A));
    }
  }
}
