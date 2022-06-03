using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class ConsoleUI {
    const int MESSAGE_AREA_HEIGHT = 5;
    const int COMMAND_AREA_HEIGHT = 5;
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
      PrintTypedAndEncodedMessage();
      PrintScramblerUnit();

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

    private void PrintScramblerUnit() {
      Console.CursorTop = 5;

      DrawCylinder(1, MESSAGE_AREA_HEIGHT, enigmaMachine.entryWheel);

      for(int i = 0; i < enigmaMachine.rotors.Count; i++) {
        DrawCylinder(1, ((i+1)*5) + MESSAGE_AREA_HEIGHT, enigmaMachine.rotors[i]);  
        Console.WriteLine();
      }

      DrawCylinder(1, (enigmaMachine.rotors.Count + 1) * 5 + MESSAGE_AREA_HEIGHT, enigmaMachine.reflector);
      Console.WriteLine();
    }

    private void PrintTypedAndEncodedMessage() {
      Console.CursorTop = 1;
      Console.CursorLeft = 1;
      Console.WriteLine(plainMessage);
      Console.CursorLeft = 1;
      Console.WriteLine(encodedMessage);
    }

    public void DrawCylinder(int x, int y, Cylinder cylinder) {
      Console.CursorLeft = x;
      Console.CursorTop = y;
      Console.WriteLine(cylinder.name);
      Console.CursorLeft = x;
      Console.WriteLine(EnigmaConfig.ALPHABET);
      Console.CursorLeft = x;
      Console.WriteLine(cylinder.mapping);
    }
  }
}
