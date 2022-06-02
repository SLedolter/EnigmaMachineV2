using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  class Program {
    static void Main(string[] args) {
      string command;
      do {
        Console.CursorTop = Console.WindowHeight - 2;
        Console.CursorLeft = 1;
        Console.Write(">> ");
        command = Console.ReadLine();
        
        if(command == "1") {
          char input;
          string message = "";
          Console.CursorTop = Console.WindowHeight - 2;
          Console.CursorLeft = 1;
          Console.Write("ENC>> ");
          while ((input = Console.ReadKey().KeyChar) != '-'){
            message += char.ToUpper(input);
            Console.CursorTop = 1;
            Console.CursorLeft = 1;
            Console.Write(message);

            Console.CursorTop = Console.WindowHeight - 2;
            Console.CursorLeft = 1;
            Console.Write("ENC>> ");
          }
        }

      } while (command != "exit");
    }
  }
}
