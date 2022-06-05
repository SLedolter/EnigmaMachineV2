using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Rotor : Cylinder {
    public char ringPosition;
    public char startPosition;
    public char notch;
    public char currentPosition;
    public string originalMapping;

    public Rotor(string name, string mapping, char notch, char ringPosition, char startPosition) : base(name, mapping) {
      this.originalMapping = mapping;
      this.notch = notch;
      this.ringPosition = ringPosition;
      this.startPosition = startPosition;
      this.currentPosition = startPosition;

      SetRingposition(ringPosition);
      RotateRing(EnigmaConfig.ALPHABET.IndexOf(startPosition));
    }

    private void SetRingposition(char ringPosition) {
      string result = "";
      for (int i = 0; i < mapping.Length; i++) {
        char newChar = mapping[i];
        int charIndex = EnigmaConfig.ALPHABET.IndexOf(newChar);
        charIndex += EnigmaConfig.ALPHABET.IndexOf(ringPosition);
        charIndex %= 26;
        result += EnigmaConfig.ALPHABET[charIndex];
      }
      Debug.WriteLine($"{name}:{mapping} {result}");
      mapping = result;
    }

    public override char EncodeLetterChained(char input, bool beforeReflector) {
      char result = base.EncodeLetterChained(input, beforeReflector);

      return result;
    }

    public override void Reset() {
      base.Reset();
      currentPosition = startPosition;
      mapping = originalMapping;
      SetRingposition(ringPosition);
      RotateRing(EnigmaConfig.ALPHABET.IndexOf(startPosition));
    }

    public override void IncreaseStepping() {
      RotateRing(1);

      currentPosition++;

      if (currentPosition > 'Z') {
        currentPosition = 'A';
      }

      if (currentPosition == notch && nextCylinder.GetType().Name == "Rotor") {
        nextCylinder.IncreaseStepping();
      }
    }

    private void RotateRing(int count) {
      for(int i = 0; i < count; i++) {
        mapping = mapping.Insert(mapping.Length, mapping[0].ToString());
        mapping = mapping.Remove(0, 1);
      }
    }
  }
}
