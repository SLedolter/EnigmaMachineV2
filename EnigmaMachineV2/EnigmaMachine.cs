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

    public EnigmaMachine(string name, string plugboardConfig, string[] usedRotors) {
      this.name = name;

      entryWheel = new Cylinder("Entry Wheel", plugboardConfig);

      for(int i = 0; i < usedRotors.Length; i++) {
        rotors.Add(
          new Rotor(
            $"Rotor{usedRotors[i]}", 
            (string)typeof(EnigmaConfig).GetField("ROTOR_"+usedRotors[i]).GetValue(null),
            (char)typeof(EnigmaConfig).GetField("TURNOVER_1_ROTOR_" + usedRotors[i]).GetValue(null),
            'A'));
      }

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
