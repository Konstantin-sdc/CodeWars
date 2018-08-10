using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CodeWars.Tests {

  [TestClass()]
  public class KataTests {
    public TestContext TestContext { get; set; }

    /// <summary>Делегат для вызова методов с аргументами одного типа</summary>
    /// <typeparam name="Tr">Возвращаемый тип</typeparam>
    /// <typeparam name="Ta">Тип аргумента</typeparam>
    /// <param name="s">Имя аргумента</param>
    /// <returns>Экземпляр делегата</returns>
    delegate Tr OneTypeDlg<Tr, Ta>(params Ta[] s);

    void TestOneTypeArgs<Tr, Ta>(IDictionary<Ta[], Tr> dic, OneTypeDlg<Tr, Ta> dlg) {
      foreach(var item in dic) {
        Tr returned = dlg.Invoke(item.Key);
        AssertCheck(item.Key, item.Value, returned);        
      }
    }

    void AssertCheck<Tin, Tout>(Tin input, Tout exp, Tout returned) {
      try { Assert.AreEqual(exp, returned); }
      catch(UnitTestAssertException) {
        string inp = input.ToString();
        if(input is System.Collections.IEnumerable) {
          inp = string.Join(Environment.NewLine, k);
        }
        string message =
$@"
Input: 
{inp} 

Expected: 
{exp.ToString()} 

Returned: 
{returned}
";
        ConsoleTraceListener traceListener = new ConsoleTraceListener();
        traceListener.WriteLine(message);
        throw new Exception(message);
      }
    }

    [TestMethod()]
    public void SoundexTest() {
      Dictionary<string, string> inputResult = new Dictionary<string, string>() {
        {"Sarah", "S600" },
        {"Connor", "C560" },
        { "ammonium", "A555" },
        { "implementation", "I514" },
        { "Robert", "R163" },
        { "Rupert", "R163" },
        { "Rubin", "R150" },
        { "Ashcraft", "A261" },
        { "Ashcroft", "A261" },
        { "Tymczak", "T522" },
        {"Sarah Connor ammonium implementation Robert Rupert Rubin Ashcraft Ashcroft Tymczak",
          "S600 C560 A555 I514 R163 R163 R150 A261 A261 T522" }
      };
      OneTypeDlg<string, string> soundex = Kata.Soundex;
      TestOneTypeArgs(inputResult, soundex);
    }

    [TestMethod()]
    public void ToBase64Test() {
      string testSring = "M";
      string returned = Kata.ToBase64(testSring); // dGhpcyBpcyBhIHN0cmluZyEh
      byte[] testBytes = Encoding.UTF8.GetBytes(testSring);
      string expected = Convert.ToBase64String(testBytes);
      bool q = returned.Equals(expected);
      //throw new NotImplementedException();
    }

    [TestMethod()]
    public void FromBase64Test() {
      // Знаков должно быть минимум 4
      // Знаков равно в конце должно быть не больше двух

      //string input = "dGhpcyBpcyBhIHN0cmluZyEh";
      //string returned = Kata.FromBase64(input);

      // Недопустимая длина строки или массива знаков Base-64
      // byte[] bytes9 = Convert.FromBase64String("123");
      // byte[] bytes5 = Convert.FromBase64String("1234=");
      // byte[] bytes12 = Convert.FromBase64String("12345");
      // byte[] bytes13 = Convert.FromBase64String("12345=");
      // byte[] bytes14 = Convert.FromBase64String("12345==");
      // byte[] bytes0 = Convert.FromBase64String("123456");
      // byte[] bytes1 = Convert.FromBase64String("123456=");
      byte[] bytes2 = Convert.FromBase64String("123456==");
      // Входные данные не являются действительной строкой Base-64, поскольку содержат символ в кодировке, 
      // отличной от Base 64, больше двух символов заполнения или недопустимый символ среди символов заполнения. 
      // byte[] bytes7 = Convert.FromBase64String("1234===");
      // byte[] bytes15 = Convert.FromBase64String("12345===");

      byte[] bytes4 = Convert.FromBase64String("1234");
      byte[] bytes10 = Convert.FromBase64String("123=");
      byte[] bytes11 = Convert.FromBase64String("123==");
      // byte[] bytes15 = Convert.FromBase64String("12");
      // byte[] bytes16 = Convert.FromBase64String("12=");
      byte[] bytes17 = Convert.FromBase64String("12==");
    }

    [TestMethod()]
    public void CharByteTest() {
      string s = "CyberMadnes";
      byte[] b = Encoding.UTF8.GetBytes(s);
      IEnumerable<char> c = b.Select(e => (char)e);
      string s2 = string.Join("", c);
      bool r = s2.Equals(s); // true
    }

    [TestMethod()]
    public void BundesLigaTableTest() {
      #region dictonary[0]
      string[] in0 = new[] {
        "6:0 FC Bayern Muenchen - Werder Bremen",
        "-:- Eintracht Frankfurt - Schalke 04",
        "-:- FC Augsburg - VfL Wolfsburg",
        "-:- Hamburger SV - FC Ingolstadt",
        "-:- 1. FC Koeln - SV Darmstadt",
        "-:- Borussia Dortmund - FSV Mainz 05",
        "-:- Borussia Moenchengladbach - Bayer Leverkusen",
        "-:- Hertha BSC Berlin - SC Freiburg",
        "-:- TSG 1899 Hoffenheim - RasenBall Leipzig"
      };
      string out0 =
        " 1. FC Bayern Muenchen            1  1  0  0  6:0  3\n" +
        " 2. 1. FC Koeln                   0  0  0  0  0:0  0\n" +
        " 2. Bayer Leverkusen              0  0  0  0  0:0  0\n" +
        " 2. Borussia Dortmund             0  0  0  0  0:0  0\n" +
        " 2. Borussia Moenchengladbach     0  0  0  0  0:0  0\n" +
        " 2. Eintracht Frankfurt           0  0  0  0  0:0  0\n" +
        " 2. FC Augsburg                   0  0  0  0  0:0  0\n" +
        " 2. FC Ingolstadt                 0  0  0  0  0:0  0\n" +
        " 2. FSV Mainz 05                  0  0  0  0  0:0  0\n" +
        " 2. Hamburger SV                  0  0  0  0  0:0  0\n" +
        " 2. Hertha BSC Berlin             0  0  0  0  0:0  0\n" +
        " 2. RasenBall Leipzig             0  0  0  0  0:0  0\n" +
        " 2. SC Freiburg                   0  0  0  0  0:0  0\n" +
        " 2. Schalke 04                    0  0  0  0  0:0  0\n" +
        " 2. SV Darmstadt                  0  0  0  0  0:0  0\n" +
        " 2. TSG 1899 Hoffenheim           0  0  0  0  0:0  0\n" +
        " 2. VfL Wolfsburg                 0  0  0  0  0:0  0\n" +
        "18. Werder Bremen                 1  0  0  1  0:6  0";
      #endregion
      #region dictonary[1]
      string[] in1 = new[] {
        "6:0 FC Bayern Muenchen - Werder Bremen",
        "1:0 Eintracht Frankfurt - Schalke 04",
        "0:2 FC Augsburg - VfL Wolfsburg",
        "1:1 Hamburger SV - FC Ingolstadt",
        "2:0 1. FC Koeln - SV Darmstadt",
        "2:1 Borussia Dortmund - FSV Mainz 05",
        "2:1 Borussia Moenchengladbach - Bayer Leverkusen",
        "-:- Hertha BSC Berlin - SC Freiburg",
        "-:- TSG 1899 Hoffenheim - RasenBall Leipzig"
      };
      string out1 =
        " 1. FC Bayern Muenchen            1  1  0  0  6:0  3\n" +
        " 2. 1. FC Koeln                   1  1  0  0  2:0  3\n" +
        " 2. VfL Wolfsburg                 1  1  0  0  2:0  3\n" +
        " 4. Borussia Dortmund             1  1  0  0  2:1  3\n" +
        " 4. Borussia Moenchengladbach     1  1  0  0  2:1  3\n" +
        " 6. Eintracht Frankfurt           1  1  0  0  1:0  3\n" +
        " 7. FC Ingolstadt                 1  0  1  0  1:1  1\n" +
        " 7. Hamburger SV                  1  0  1  0  1:1  1\n" +
        " 9. Hertha BSC Berlin             0  0  0  0  0:0  0\n" +
        " 9. RasenBall Leipzig             0  0  0  0  0:0  0\n" +
        " 9. SC Freiburg                   0  0  0  0  0:0  0\n" +
        " 9. TSG 1899 Hoffenheim           0  0  0  0  0:0  0\n" +
        "13. Bayer Leverkusen              1  0  0  1  1:2  0\n" +
        "13. FSV Mainz 05                  1  0  0  1  1:2  0\n" +
        "15. Schalke 04                    1  0  0  1  0:1  0\n" +
        "16. FC Augsburg                   1  0  0  1  0:2  0\n" +
        "16. SV Darmstadt                  1  0  0  1  0:2  0\n" +
        "18. Werder Bremen                 1  0  0  1  0:6  0";
      #endregion
      #region dictonary[2]
      string[] in2 = new[] {
        "6:0 FC Bayern Muenchen - Werder Bremen",
        "1:0 Eintracht Frankfurt - Schalke 04",
        "0:2 FC Augsburg - VfL Wolfsburg",
        "1:1 Hamburger SV - FC Ingolstadt",
        "2:0 1. FC Koeln - SV Darmstadt",
        "2:1 Borussia Dortmund - FSV Mainz 05",
        "2:1 Borussia Moenchengladbach - Bayer Leverkusen",
        "2:1 Hertha BSC Berlin - SC Freiburg",
        "2:2 TSG 1899 Hoffenheim - RasenBall Leipzig"
      };
      string out2 =
        " 1. FC Bayern Muenchen            1  1  0  0  6:0  3\n" +
      " 2. 1. FC Koeln                   1  1  0  0  2:0  3\n" +
      " 2. VfL Wolfsburg                 1  1  0  0  2:0  3\n" +
      " 4. Borussia Dortmund             1  1  0  0  2:1  3\n" +
      " 4. Borussia Moenchengladbach     1  1  0  0  2:1  3\n" +
      " 4. Hertha BSC Berlin             1  1  0  0  2:1  3\n" +
      " 7. Eintracht Frankfurt           1  1  0  0  1:0  3\n" +
      " 8. RasenBall Leipzig             1  0  1  0  2:2  1\n" +
      " 8. TSG 1899 Hoffenheim           1  0  1  0  2:2  1\n" +
      "10. FC Ingolstadt                 1  0  1  0  1:1  1\n" +
      "10. Hamburger SV                  1  0  1  0  1:1  1\n" +
      "12. Bayer Leverkusen              1  0  0  1  1:2  0\n" +
      "12. FSV Mainz 05                  1  0  0  1  1:2  0\n" +
      "12. SC Freiburg                   1  0  0  1  1:2  0\n" +
      "15. Schalke 04                    1  0  0  1  0:1  0\n" +
      "16. FC Augsburg                   1  0  0  1  0:2  0\n" +
      "16. SV Darmstadt                  1  0  0  1  0:2  0\n" +
      "18. Werder Bremen                 1  0  0  1  0:6  0";
      #endregion
      Dictionary<string[], string> d = new Dictionary<string[], string>() {
        {in0, out0 },
        {in1, out1 },
        {in2, out2 },
      };
      OneTypeDlg<string, string> dt = Kata.BundesLigaTable;
      TestOneTypeArgs(d, dt);
    }

    [TestMethod()]
    public void ListSquaredTest() {
      Tuple<long, long> t0 = new Tuple<long, long>(1, 250);
      Tuple<long, long> t1 = new Tuple<long, long>(42, 250);
      Tuple<long, long> t2 = new Tuple<long, long>(250, 500);
      Dictionary<Tuple<long, long>, string> d = new Dictionary<Tuple<long, long>, string>() {
        { t0, "[[1, 1], [42, 2500], [246, 84100]]"},
        { t1, "[[42, 2500], [246, 84100]]"},
        { t2, "[[287, 84100]]"},
      };
      OneTypeDlg<string, long> dlg = Kata.ListSquared;
    }
  }

}