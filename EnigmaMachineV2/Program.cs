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
        Console.Write(">> ");
        command = Console.ReadLine();
      } while (command != "exit");
    }
  }
}
