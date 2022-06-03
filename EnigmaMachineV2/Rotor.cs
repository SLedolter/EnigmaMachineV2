using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Rotor : Cylinder {
    public char ringPosition;
    public char startPosition;
    public char notch;
    public char currentPosition;

    public Rotor(string name, string mapping, char notch, char ringPosition, char startPosition) : base(name, mapping) {
      this.notch = notch;
      this.ringPosition = ringPosition;
      this.startPosition = startPosition;
      this.currentPosition = startPosition;
    }

    public override char EncodeLetterChained(char input, bool beforeReflector) {
      char result = base.EncodeLetterChained(input, beforeReflector);

      return result;
    }

    public override void Reset() {
      base.Reset();
      currentPosition = startPosition;
    }

    public override void IncreaseStepping() {
      stepping++;
      stepping %= 26;

      currentPosition++;

      if(currentPosition > 'Z') {
        currentPosition = 'A';
      }

      if(currentPosition == ringPosition && nextCylinder.GetType().Name == "Rotor") {
        nextCylinder.IncreaseStepping();
      }
    }
  }
}
