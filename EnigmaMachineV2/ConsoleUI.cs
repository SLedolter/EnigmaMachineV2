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
          while ((input = char.ToUpper(Console.ReadKey().KeyChar)) != '-') {
            PrintScreen();

            char result = enigmaMachine.EncodeLetterChained(input);

            if (result == ' ') {
              continue;
            }

            plainMessage += input;
            encodedMessage += result;
          }
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

      Console.CursorLeft = x;
      Console.CursorTop = y;
      Console.WriteLine($"{cylinderName}");

      Console.CursorLeft = x;
      Console.WriteLine(EnigmaConfig.ALPHABET);
      Console.CursorLeft = x;
      Console.WriteLine(cylinder.mapping);
    }
  }
}
