using System.Text.RegularExpressions;
namespace CodeWars {

  class Program {

    static void Main() {
      string snd = Kata.Soundex("Robert"); //R163
      string input = "T5220000";
      string pattern = @"(\w{4})\w*\1";
      string replacement = "$1";
      string result = Regex.Replace(input, pattern, replacement);
    }

  }

}
