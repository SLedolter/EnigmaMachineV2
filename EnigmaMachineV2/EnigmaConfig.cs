using System;
using System.Collections.Generic;
using System.Text;

namespace EnigmaMachineV2 {
  public static class EnigmaConfig {
    public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public const string PLUGBOARD_DAY_29 = "AD CN ET FL GI JV KZ PU QY WX";
    public const string PLUGBOARD_UNENCODED = "AA";
    public const string PLUGBOARD_ENIGMA_INSTRUCTION_MANUAL = "AM FI NV PS TU WZ";

    public const string ROTOR_1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
    public const char TURNOVER_1_ROTOR_1 = 'Q';
    
    public const string ROTOR_2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
    public const char TURNOVER_1_ROTOR_2 = 'E';

    public const string ROTOR_3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
    public const char TURNOVER_1_ROTOR_3 = 'V';

    public const string ROTOR_4 = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
    public const int TURNOVER_1_ROTOR_4 = 10;

    public const string ROTOR_5 = "VZBRGITYUPSDNHLXAWMJQOFECK";
    public const int TURNOVER_1_ROTOR_5 = 26;

    public const string ROTOR_6 = "JPGVOUMFYQBENHZRDKASXLICTW";
    public const int TURNOVER_1_ROTOR_6 = 26;
    public const int TURNOVER_2_ROTOR_6 = 13;

    public const string ROTOR_7 = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
    public const int TURNOVER_1_ROTOR_7 = 26;
    public const int TURNOVER_2_ROTOR_7 = 13;

    public const string ROTOR_8 = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
    public const int TURNOVER_1_ROTOR_8 = 26;
    public const int TURNOVER_2_ROTOR_8 = 13;

    public const string ROTOR_BETA_M4 = "LEYJVCNIXWPBQMDRTAKZGFUHOS";
    public const string ROTOR_GAMMA_M4 = "FSOKANUERHMBTIYCWLQPZXVGJD";

    public const string REFLECTOR_A = "AE BJ CM DZ FL GY HX IV KW NR OQ PU ST";
    public const string REFLECTOR_A_SOLUTION = "EJMZALYXVBWFCRQUONTSPIKHGD";

    public const string REFLECTOR_B = "AY BR CU DH EQ FS GL IP JX KN MO TZ VW";
    public const string REFLECTOR_B_SOLUTION = "YRUHQSLDPXNGOKMIEBFZCWVJAT";

    public const string REFLECTOR_C = "AF BV CP DJ EI GO HY KR LZ MX NW QT SU";
    public const string REFLECTOR_C_SOLUTION = "FVPJIAOYEDRZXWGCTKUQSBNMHL";

    public const string REFLECTOR_B_NARROW_SOLUTION = "ENKQAUYWJICOPBLMDXZVFTHRGS";

    public const string REFLECTOR_C_NARROW_SOLUTION = "RDOBJNTKVEHMLFCWZAXGYIPSUQ";

    public static string TransformSwitchedPlugsToAlphabet(string plugboardOrder) {
      if(plugboardOrder == null) {
        return ALPHABET;
      }
      string result = EnigmaConfig.ALPHABET;
      int index1, index2;
      char char1, char2;

      foreach (string pair in plugboardOrder.Trim().Split(' ')) {
       index1 = result.IndexOf(pair[0]);
        char1 = result[index1];
        index2 = result.IndexOf(pair[1]);
        char2 = result[index2];
        result = result
          .Remove(index1, 1)
          .Insert(index1, char2.ToString())
          .Remove(index2, 1)
          .Insert(index2, char1.ToString());
      }

      return result;
    }
  }
}
