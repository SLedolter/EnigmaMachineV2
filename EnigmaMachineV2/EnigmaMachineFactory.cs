using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public static class EnigmaMachineFactory {
    public static Cylinder CreateRotor1(string startPosition) {
      return new Cylinder("Rotor_I", startPosition, EnigmaConfig.TURNOVER_1_CYLINDER_1, EnigmaConfig.CYLINDER_1);
    }
  }
}
