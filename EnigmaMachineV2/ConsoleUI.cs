using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class ConsoleUI {
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
          string plainMessage = "";
          string encodedMessage = "";
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

            Console.CursorTop = 1;
            Console.CursorLeft = 1;
            Console.WriteLine(plainMessage);
            Console.CursorLeft = 1;
            Console.WriteLine(encodedMessage);

            Console.CursorTop = Console.WindowHeight - 2;
            Console.CursorLeft = 1;
            Console.Write("ENC>> ");
          }
        }

      } while (command != "exit");
    }
  }
}
