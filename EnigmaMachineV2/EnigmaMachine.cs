using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class EnigmaMachine {
    public string name;
    public Cylinder entryWheel;
    public List<Rotor> rotors = new List<Rotor>();
    public Cylinder reflector;

    public EnigmaMachine(string name) {
      this.name = name;

      rotors.Add(EnigmaMachineFactory.CreateRotor1('A'));
      reflector = EnigmaMachineFactory.CreateReflectorA();

      rotors.Last().ConnectNextCylinder(reflector);
    }

    public char EncodeLetter(char input) {
      char result = input;
      bool beforeReflector = true;

      for(int i = 0; i < rotors.Count; i++) {
        result = rotors[i].EncodeLetter(result, beforeReflector);
      }

      result = reflector.EncodeLetter(result, beforeReflector);

      for(int i = rotors.Count-1; i >= 0; i--) {
        result = rotors[i].EncodeLetter(result, !beforeReflector);
      }

      rotors[0].IncreaseStepping();

      return result;
    }
  }
}
