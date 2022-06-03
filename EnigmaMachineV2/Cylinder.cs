using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Cylinder {
    public string name;
    public string mapping;

    public Cylinder previousCylinder;
    public Cylinder nextCylinder;

    public Cylinder(string name, string mapping) {
      this.name = name;
      this.mapping = mapping;
    }

    public void ConnectNextCylinder(Cylinder nextCylinder) {
      this.nextCylinder = nextCylinder;
      if(nextCylinder.previousCylinder != this) {
        nextCylinder.ConnectPreviousCylinder(this);
      }
    }

    public void ConnectPreviousCylinder(Cylinder previousCylinder) {
      this.previousCylinder = previousCylinder;
      if(previousCylinder.nextCylinder != this) {
        previousCylinder.nextCylinder = this;
      }
    }

    public virtual char EncodeLetter(char input, bool beforeReflector) {
      char result;
      string inputScheme, outputScheme;

      if (!IsInputLetterValid(input)) {
        return ' ';
      }

      if(beforeReflector) {
        inputScheme = EnigmaConfig.ALPHABET;
        outputScheme = mapping;
      } else {
        inputScheme = mapping;
        outputScheme = EnigmaConfig.ALPHABET;
      }

      result = outputScheme[inputScheme.IndexOf(input)];

      return result;
    }

    public virtual void IncreaseStepping() {
      Debug.WriteLine($"{this.GetType().Name}");
    }

    private bool IsInputLetterValid(char input) {
      if (input >= 'A' && input <= 'Z') {
        return true;
      }
      return false;
    }
  }
}
