﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachineV2 {
  public class Rotor : Cylinder {
    public char ringPosition;
    public char startPosition;
    public int stepping = 0;

    public Rotor(string name, string mapping, char ringPosition, char startPosition) : base(name, mapping) {
      this.ringPosition = ringPosition;
      this.startPosition = startPosition;
    }

    public override char EncodeLetter(char input, bool beforeReflector) {
      char result = base.EncodeLetter(input, beforeReflector);

      return result;
    }

    public override void IncreaseStepping() {
      stepping++;
      startPosition++;

      if(startPosition == ringPosition) {
        //(Rotor)nextCylinder.IncreaseStepping();
      }
    }
  }
}