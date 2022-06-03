using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public static class EnigmaMachineFactory {
    public static EnigmaMachine CreateSimpleRotor1ReflectorEnigmaMachine(string startPositions) {
      return new EnigmaMachine("Simple Rotor1 - Reflector A");
    }

    public static Rotor CreateRotor1(char startPosition) {
      return new Rotor("Rotor_I", EnigmaConfig.CYLINDER_1, startPosition, EnigmaConfig.TURNOVER_1_CYLINDER_1);
    }

    internal static Cylinder CreatePlainEntryWheel() {
      return new Cylinder("Entry Wheel", EnigmaConfig.ALPHABET);
    }

    public static Cylinder CreateReflectorA() {
      return new Cylinder("Reflector", EnigmaConfig.TransformSwitchedPlugsToAlphabet(EnigmaConfig.REFLECTOR_A));
    }
  }
}
