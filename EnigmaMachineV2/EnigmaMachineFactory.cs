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
          EnigmaConfig.PLUGBOARD_UNENCODED,
          new string[] {"1"},
          "A",
          "AAA",
          "AAA"
        );
      return enigmaMachine;
    }

    public static EnigmaMachine CreateSimplePlugboardRotor1ReflectorEnigmaMachine(string startPositions) {
      EnigmaMachine enigmaMachine =
        new EnigmaMachine(
          "Unencoded Plugboard - Simple Rotor1 - Reflector A",
          EnigmaConfig.PLUGBOARD_DAY_29,
          new string[] { "1" },
          "B",
          "AAA",
          "AAA"
        );
      return enigmaMachine;
    }

    public static EnigmaMachine CreateEnigmaInstructionManual1930Machine() {
      EnigmaMachine enigmaMachine =
        new EnigmaMachine(
          "Enigma Instruction Manual 1930",
          EnigmaConfig.PLUGBOARD_ENIGMA_INSTRUCTION_MANUAL,
          new string[] { "2", "1", "3" },
          "A",
          "XMV",
          "ABL"
        );
      return enigmaMachine;
    }

    public static EnigmaMachine CreateDay29EnigmaMachine(string startPositions) {
      EnigmaMachine enigmaMachine =
        new EnigmaMachine(
          "Unencoded Plugboard - Rotor1,2,3 - Reflector A",
          EnigmaConfig.PLUGBOARD_DAY_29,
          new string[] { "1", "2", "3" },
          "A",
          "AAA",
          "AAA"
        );
      return enigmaMachine;
    }

    public static Rotor CreateRotor1(char ringPosition, char startPosition) {
      return new Rotor("Rotor_I", EnigmaConfig.ROTOR_1, EnigmaConfig.TURNOVER_1_ROTOR_1, ringPosition, startPosition);
    }

    internal static EntryWheel CreatePlainEntryWheel() {
      return new EntryWheel("Entry Wheel", EnigmaConfig.ALPHABET);
    }

    public static Reflector CreateReflectorA() {
      return new Reflector("Reflector", EnigmaConfig.TransformSwitchedPlugsToAlphabet(EnigmaConfig.REFLECTOR_A));
    }
  }
}
