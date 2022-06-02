using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Cylinder {
    public string name;
    public char ringPosition;
    public char startPosition;
    public int stepping = 0;
    public string mapping;

    public Cylinder(string name, char startPosition, char ringPosition, string mapping) {
      this.name = name;
      this.startPosition = startPosition;
      this.ringPosition = ringPosition;
      this.mapping = mapping;
    }

    public char EncodeLetter(char input, bool beforeReflector) {
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

    private bool IsInputLetterValid(char input) {
      if (input < 'A' && input > 'Z') {
        return false;
      }
      return true;
    }
  }
}
