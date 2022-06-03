using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public static class EnigmaMachineFactory {
    public static EnigmaMachine CreateSimpleRotor1ReflectorEnigmaMachine(string startPositions) {
      EnigmaMachine enigmaMachine = 
        new EnigmaMachine(
          "Unencoded Plugboard - Simple Rotor1 - Reflector A", 
          EnigmaConfig.TransformSwitchedPlugsToAlphabet(EnigmaConfig.PLUGBOARD_UNENCODED),
          new string[] {"1"}
        );
      return enigmaMachine;
    }

    public static EnigmaMachine CreateDay29EnigmaMachine(string startPositions) {
      EnigmaMachine enigmaMachine =
        new EnigmaMachine(
          "Unencoded Plugboard - Rotor1,2,3 - Reflector A",
          EnigmaConfig.TransformSwitchedPlugsToAlphabet(EnigmaConfig.PLUGBOARD_DAY_29),
          new string[] { "1", "2", "3" }
        );
      return enigmaMachine;
    }

    public static Rotor CreateRotor1(char startPosition) {
      return new Rotor("Rotor_I", EnigmaConfig.ROTOR_1, startPosition, EnigmaConfig.TURNOVER_1_ROTOR_1);
    }

    internal static Cylinder CreatePlainEntryWheel() {
      return new Cylinder("Entry Wheel", EnigmaConfig.ALPHABET);
    }

    public static Cylinder CreateReflectorA() {
      return new Cylinder("Reflector", EnigmaConfig.TransformSwitchedPlugsToAlphabet(EnigmaConfig.REFLECTOR_A));
    }
  }
}
