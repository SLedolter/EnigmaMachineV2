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
    public int firstIndex = -1, secondIndex = -1;

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

    public virtual char EncodeLetterChained(char input, bool beforeReflector) {
      char result;
      string inputScheme, outputScheme;

      if (beforeReflector) {
        inputScheme = EnigmaConfig.ALPHABET;
        outputScheme = mapping;
      } else {
        inputScheme = mapping;
        outputScheme = EnigmaConfig.ALPHABET;
      }

      int indexInInputScheme = inputScheme.IndexOf(input);
      result = outputScheme[indexInInputScheme];

      if(beforeReflector && nextCylinder != null) {
        result = nextCylinder.EncodeLetterChained(result, true);
      }

      if((nextCylinder == null || !beforeReflector) && previousCylinder != null) {
        result = previousCylinder.EncodeLetterChained(result, false);
      }

      if(beforeReflector) {
        firstIndex = indexInInputScheme;
      } else {
        secondIndex = indexInInputScheme;
      }

      return result;
    }

    public virtual void Reset() {
      firstIndex = secondIndex = -1;
      if(nextCylinder != null) {
        nextCylinder.Reset();
      }
    }

    public virtual void IncreaseStepping() {
      Debug.WriteLine($"{this.GetType().Name}");
    }
  }
}
