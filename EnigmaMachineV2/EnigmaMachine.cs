using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class EnigmaMachine {
    public string name;
    public List<Cylinder> scramblerUnit = new List<Cylinder>();

    public EnigmaMachine(string name) {
      this.name = name;

      scramblerUnit.Add(EnigmaMachineFactory.CreateRotor1("A"));
      scramblerUnit.Add(EnigmaMachineFactory.CreateReflectorA());
      scramblerUnit[0].ConnectNextCylinder(scramblerUnit[1]);
    }

    public char EncodeLetter(char input) {
      char result = ' ';
      bool beforeReflector = true;

      for(int i = 0; i < scramblerUnit.Count; i++) {
        result = scramblerUnit[i].EncodeLetter(input, beforeReflector);
      }

      for(int i = scramblerUnit.Count-2; i >= 0; i--) {
        result = scramblerUnit[i].EncodeLetter(input, !beforeReflector);
      }

      return result;
    }
  }
}
