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

      entryWheel = EnigmaMachineFactory.CreatePlainEntryWheel();
      rotors.Add(EnigmaMachineFactory.CreateRotor1('A'));
      reflector = EnigmaMachineFactory.CreateReflectorA();

      entryWheel.ConnectNextCylinder(rotors.First());
      
      foreach(Rotor rotor in rotors) {
        if(rotor == rotors.Last()) {
          rotors.Last().ConnectNextCylinder(reflector);
          break;
        }
        rotor.ConnectNextCylinder(rotors[rotors.IndexOf(rotor)+1]);
      }
    }

    public char EncodeLetterChained(char input) {
      char result;

      result = entryWheel.EncodeLetterChained(input, true);

      return result;
    }
  }
}
