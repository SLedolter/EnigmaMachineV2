using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Reflector : Cylinder {
    public Reflector(string name, string mapping) : base(name, mapping) { }

    public override char EncodeLetterChained(char input, bool beforeReflector) {
      char result = base.EncodeLetterChained(input, beforeReflector);

      secondIndex = firstIndex;

      return result;
    }
  }
}
