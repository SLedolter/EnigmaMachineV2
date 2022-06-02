using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  class EnigmaMachine {
    public string name;
    public List<Cylinder> scramblerUnit;

    public EnigmaMachine(string name) {
      this.name = name;
    }
  }
}
