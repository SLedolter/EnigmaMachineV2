using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Rotor : Cylinder {
    public string alphabet;
    public char ringPosition;
    public int markingPoint;
    public char startPosition;
    public char notch;
    public char currentPosition;
    public string originalMapping;

    public Rotor(string name, string mapping, char notch, char ringPosition, char startPosition) : base(name, mapping) {
      this.alphabet = EnigmaConfig.ALPHABET;
      this.originalMapping = mapping;
      this.notch = notch;
      this.markingPoint = mapping.IndexOf('A');
      this.ringPosition = ringPosition;
      this.startPosition = startPosition;
      this.currentPosition = startPosition;

      SetRingposition(ringPosition);
      RotateCompleteRingUp(EnigmaConfig.ALPHABET.IndexOf(startPosition));
    }

    public override char EncodeLetterChained(char input, bool beforeReflector) {
      char result = base.EncodeLetterChained(input, beforeReflector);

      return result;
    }

    private void SetRingposition(char ringPosition) {
      mapping = originalMapping;
      string result = "";
      for (int i = 0; i < mapping.Length; i++) {
        char newChar = mapping[i];
        int charIndex = alphabet.IndexOf(newChar);
        charIndex += alphabet.IndexOf(ringPosition);
        charIndex %= 26;
        result += alphabet[charIndex];
      }
      markingPoint = (markingPoint + alphabet.IndexOf(ringPosition)) % 26;
      Debug.WriteLine($"{name}:{mapping} {result}");
      mapping = result;
      int newMarkingSpot = markingPoint - mapping.IndexOf(ringPosition);
      Debug.WriteLine($"NewMP: {newMarkingSpot}");
      if (newMarkingSpot < 0) {
        RotateRingDown(-newMarkingSpot);
      } else {
        RotateRingUp(newMarkingSpot);
      }

    }


    public override void IncreaseStepping() {
      RotateLettersUp(1);
      RotateCompleteRingUp(1);

      currentPosition++;

      if (currentPosition > 'Z') {
        currentPosition = 'A';
      }

      if (currentPosition == notch && nextCylinder.GetType().Name == "Rotor") {
        nextCylinder.IncreaseStepping();
      }
    }

    private void RotateCompleteRingUp(int count) {
      RotateRingUp(count);
      RotateLettersUp(count);
    }

    private void RotateCompleteRingDown(int count) {
      RotateRingDown(count);
      RotateLettersDown(count);
    }

    private void RotateLettersUp(int count) {
      for (int i = 0; i < count; i++) {
        alphabet = alphabet.Insert(alphabet.Length, alphabet[0].ToString());
        alphabet = alphabet.Remove(0, 1);
      }
      Debug.WriteLine(alphabet);
    }

    private void RotateLettersDown(int count) {
      for (int i = 0; i < count; i++) {
        alphabet = alphabet.Insert(0, alphabet[alphabet.Length - 1].ToString());
        alphabet = alphabet.Remove(alphabet.Length - 1, 1);
      }
      Debug.WriteLine(alphabet);
    }

    private void RotateRingDown(int count) {
      Debug.Write($"{count}: {mapping} -> ");
      for (int i = 0; i < count; i++) {
        mapping = mapping.Insert(mapping.Length, mapping[0].ToString());
        mapping = mapping.Remove(0, 1);
      }
      Debug.WriteLine(mapping);
    }

    private void RotateRingUp(int count) {
      Debug.Write($"{count}: {mapping} -> ");
      for (int i = 0; i < count; i++) {
        mapping = mapping.Insert(0, mapping[mapping.Length - 1].ToString());
        mapping = mapping.Remove(mapping.Length - 1, 1);
      }
      Debug.WriteLine(mapping);
    }

    public override void Reset() {
      base.Reset();
      currentPosition = startPosition;
      mapping = originalMapping;
      markingPoint = mapping.IndexOf('A');
      alphabet = EnigmaConfig.ALPHABET;

      SetRingposition(ringPosition);

      //RotateRingUp(EnigmaConfig.ALPHABET.IndexOf(startPosition));
    }
  }
}
