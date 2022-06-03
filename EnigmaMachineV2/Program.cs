﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  class Program {
    static void Main(string[] args) {
      EnigmaMachine enigmaMachine = EnigmaMachineFactory.CreateDay29EnigmaMachine("A");
      ConsoleUI consoleUI = new ConsoleUI(enigmaMachine);

      consoleUI.ShowUI();
    }
  }
}
