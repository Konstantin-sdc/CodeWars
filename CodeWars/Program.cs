using System.Text;

namespace CodeWars {
  class Program {
    static void Main() {
      //Kata.SquareDigits(1234);
      //Kata.Maskify("Qwertyuiopasdf");
      //bool res = Kata.IsIsogram("QwEr");
      //int qqq = Kata.Persistence(103);
      string[] arr = { "qq", "dddd", "hhhh", "yy", "aaaaa", "s" };
      string[] arr2 = new string[0];
      //Kata.LongestConsec(arr2, 12);
      //Kata.NbYear(10, 2, 5, 20);
      string[] names = { "Ryan", "Kieran", "Jason", "Yous" };
      //Kata.FriendOrFoe(names);
      //Kata.RowSumOddNumbers(-42);
      //Kata.SumDigPow(0, 10000000);
      //Kata.Order("qw2fd kh3ikh hgh5ug yfu1hf");
      //Kata.Solution(int.MaxValue);
      //Kata.FindNb(91716553919377);
      //Kata.ListSquared(2, 250);
      //Xbonacci xbonacci = new Xbonacci();
      // 1,1,1,3,5,9,17,31,57,105
      //double[] d0 = xbonacci.Tribonacci(new double[] { 1, 1, 1 }, 10);
      // 
      string rgbHex00 = Kata.HEXfromRGB(-300, 128, 300);
    }
  }

  public class Xbonacci {
    // signature всегда должна содержать 3 числа
    public double[] Tribonacci(double[] signature, int n) {
      // hackonacci me
      // if n==0, then return an array of length 1, containing only a 0
      if(n < 1 || signature.Length != 3) return new double[] { 0 };
      double[] result = new double[n];
      int sc = (n <= signature.Length) ? n : signature.Length;
      // Запись сигнатуры
      for(int i = 0; i < sc; i++) {
        result[i] = signature[i];
      }
      if(n <= signature.Length) return result;
      for(int i = sc; i < n; i++) {
        result[i] = result[i - 1] + result[i - 2] + result[i - 3];
      }
      return result;
    }
  }
}
