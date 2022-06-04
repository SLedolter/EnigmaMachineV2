using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class EnigmaMachine {
    public string name;
    public string plugboardConfig;
    public string wheelOrder;
    public string ringPosition;
    public string ringStance;

    public EntryWheel entryWheel;
    public List<Rotor> rotors = new List<Rotor>();
    public Reflector reflector;

    public EnigmaMachine(string name, string plugboardConfig, string[] usedRotors, string reflectorConfig, string ringPosition, string ringStance) {
      this.name = name;
      this.plugboardConfig = plugboardConfig;
      this.wheelOrder = String.Join(" ", usedRotors);
      this.ringPosition = ringPosition;
      this.ringStance = ringStance;

      entryWheel = new EntryWheel("Entry Wheel", EnigmaConfig.TransformSwitchedPlugsToAlphabet(plugboardConfig));

      for (int i = usedRotors.Length - 1; i >= 0; i--) {
        rotors.Add(
          new Rotor(
            $"Rotor{usedRotors[i]}",
            (string)typeof(EnigmaConfig).GetField("ROTOR_" + usedRotors[i]).GetValue(null),
            (char)typeof(EnigmaConfig).GetField("TURNOVER_1_ROTOR_" + usedRotors[i]).GetValue(null),
            ringPosition[i],
            ringStance[i]));
      }

      reflectorConfig = "REFLECTOR_" + reflectorConfig;
      reflector = new Reflector(
        reflectorConfig,
        EnigmaConfig.TransformSwitchedPlugsToAlphabet((string)typeof(EnigmaConfig).GetField(reflectorConfig).GetValue(null))
      );

      entryWheel.ConnectNextCylinder(rotors.First());

      foreach (Rotor rotor in rotors) {
        if (rotor == rotors.Last()) {
          rotors.Last().ConnectNextCylinder(reflector);
          break;
        }
        rotor.ConnectNextCylinder(rotors[rotors.IndexOf(rotor) + 1]);
      }
    }

    private string Reverse(string s) {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }

    public void Reset() {
      entryWheel.Reset();
    }

    public char EncodeLetterChained(char input) {
      char result;

      if (!IsInputLetterValid(input)) {
        return ' ';
      }

      rotors.First().IncreaseStepping();
      result = entryWheel.EncodeLetterChained(input, true);

      return result;
    }

    private bool IsInputLetterValid(char input) {
      if (input >= 'A' && input <= 'Z') {
        return true;
      }
      return false;
    }
  }
}
