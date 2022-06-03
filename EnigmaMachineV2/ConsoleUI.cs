using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class ConsoleUI {
    const int MESSAGE_AREA_HEIGHT = 5;
    string plainMessage = "";
    string encodedMessage = "";

    EnigmaMachine enigmaMachine;

    public ConsoleUI(EnigmaMachine enigmaMachine) {
      this.enigmaMachine = enigmaMachine;
    }

    public void ShowUI() {
      string command;
      do {
        Console.CursorTop = Console.WindowHeight - 2;
        Console.CursorLeft = 1;
        Console.Write(">> ");
        command = Console.ReadLine();

        if (command == "1") {
          char input;
          Console.CursorTop = Console.WindowHeight - 2;
          Console.CursorLeft = 1;
          Console.Write("ENC>> ");
          while ((input = char.ToUpper(Console.ReadKey().KeyChar)) != '-') {
            char result = enigmaMachine.EncodeLetter(input);

            if (result == ' ') {
              continue;
            }

            plainMessage += input;
            encodedMessage += result;

            PrintScreen();
          }
        }

      } while (command != "exit");
    }

    private void PrintScreen() {
      PrintTypedAndEncodedMessage();
      PrintScramblerUnit();

      PrintCommandSecction();
    }

    private void PrintCommandSecction() {
      Console.CursorTop = Console.WindowHeight - 2;
      Console.CursorLeft = 1;
      Console.Write("ENC>> ");
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
