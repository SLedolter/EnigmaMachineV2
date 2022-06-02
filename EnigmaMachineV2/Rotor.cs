using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Rotor : Cylinder {
    public string ringPosition;
    public string startPosition;
    public int stepping = 0;

    public Rotor(string name, string mapping, string ringPosition, string startPosition) : base(name, mapping) {
      this.ringPosition = ringPosition;
      this.startPosition = startPosition;
    }

    public override char EncodeLetter(char input, bool beforeReflector) {
      char result = base.EncodeLetter(input, beforeReflector);

      IncreaseStepping();
      
      return result;
    }

    private void IncreaseStepping() {
      stepping = (stepping++) % 26;
    }
  }
}
