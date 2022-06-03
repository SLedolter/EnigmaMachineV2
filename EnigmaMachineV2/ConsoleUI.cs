using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class ConsoleUI {
    const int COMMAND_AREA_HEIGHT = 4;
    const int PADDING = 1;
    string plainMessage = "";
    string encodedMessage = "";
    string currentMenuPrefix = "";

    EnigmaMachine enigmaMachine;

    public ConsoleUI(EnigmaMachine enigmaMachine) {
      this.enigmaMachine = enigmaMachine;
    }

    public void ShowUI() {
      string command;
      do {
        PrintScreen();
        command = Console.ReadLine();

        if (command == "1") {
          currentMenuPrefix = "ENC";
          char input;
          PrintScreen();
          while ((input = char.ToUpper(Console.ReadKey().KeyChar)) != '-') {
            char result = enigmaMachine.EncodeLetterChained(input);

            if (result == ' ') {
              continue;
            }

            plainMessage += input;
            encodedMessage += result;
            PrintScreen();
          }
          enigmaMachine.Reset();
          encodedMessage = plainMessage = "";
          currentMenuPrefix = "";
        }

      } while (command != "exit");
      currentMenuPrefix = "";
    }

    private void PrintScreen() {
      Console.Clear();
      PrintTypedAndEncodedMessage(Console.WindowWidth / 2, 0);
      PrintScramblerUnit(0, 0);

      PrintCommandSection(currentMenuPrefix);
    }

    private void PrintCommandSection(string prefix) {
      Console.ForegroundColor = ConsoleColor.White;
      Console.CursorTop = Console.WindowHeight - COMMAND_AREA_HEIGHT;
      for (int i = 0; i < Console.WindowWidth; i++) {
        Console.Write("-");
      }
      Console.CursorTop = Console.WindowHeight - 2;
      Console.CursorLeft = 1;
      Console.Write($"{currentMenuPrefix}>> ");
    }

    private void PrintScramblerUnit(int x, int y) {
      x += PADDING;
      y += PADDING;
   
      DrawCylinder(x, y, enigmaMachine.entryWheel);

      for (int i = 0; i < enigmaMachine.rotors.Count; i++) {
        DrawCylinder(x, ((i + 1) * 5) + y, enigmaMachine.rotors[i]);
        Console.WriteLine();
      }

      DrawCylinder(x, (enigmaMachine.rotors.Count + 1) * 5 + y, enigmaMachine.reflector);
      Console.WriteLine();
    }

    private void PrintTypedAndEncodedMessage(int x, int y) {
      x += PADDING;
      y += PADDING;
      Console.ForegroundColor = ConsoleColor.White;
      Console.CursorTop = y;
      Console.CursorLeft = x;
      Console.WriteLine(plainMessage);
      Console.CursorLeft = x;
      Console.WriteLine(encodedMessage);
    }

    public void DrawCylinder(int x, int y, Cylinder cylinder) {
      string cylinderName = cylinder.name;
      if (cylinder.GetType().Name == "Rotor") {
        cylinderName += $"({cylinder.stepping})";
      }

      Console.ForegroundColor = ConsoleColor.White;
      Console.CursorLeft = x;
      Console.CursorTop = y;
      Console.WriteLine($"{cylinderName}");

      if (cylinder.GetType().Name == "Rotor") {
        Rotor rotor = (Rotor)cylinder;
        Console.CursorLeft = x + EnigmaConfig.ALPHABET.IndexOf(rotor.ringPosition);
        Console.Write("#");
        Console.CursorLeft = x + EnigmaConfig.ALPHABET.IndexOf(rotor.currentPosition);
        Console.WriteLine("V");
      }

      Console.CursorLeft = x;
      Console.Write(EnigmaConfig.ALPHABET);
      if (cylinder.firstIndex > -1 && cylinder.secondIndex > -1) {
        Console.CursorLeft = x + cylinder.firstIndex;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(EnigmaConfig.ALPHABET[cylinder.firstIndex]);
        Console.CursorLeft = x + cylinder.secondIndex;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(EnigmaConfig.ALPHABET[cylinder.secondIndex]);
      }
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.White;
      Console.CursorLeft = x;
      Console.Write(cylinder.mapping);
      if (cylinder.firstIndex > -1 && cylinder.secondIndex > -1) {
        Console.CursorLeft = x + cylinder.firstIndex;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(cylinder.mapping[cylinder.firstIndex]);
        Console.CursorLeft = x + cylinder.secondIndex;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(cylinder.mapping[cylinder.secondIndex]);
      }
      Console.WriteLine();
    }
  }
}
