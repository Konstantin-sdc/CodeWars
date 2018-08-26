﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests {

  [TestClass()]
  public class KataTests {

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
      Func<string, string> soundex = Kata.Soundex;
      TestBox.OneTypeArgs(inputResult, soundex);
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
      Func<string[], string> dt = Kata.BundesLigaTable;
      TestBox.OneTypeArgs(d, dt);
    }

    [TestMethod()]
    public void ListSquaredTest() {
      string a = Kata.ListSquared(728, 728);
    }

    [TestMethod()]
    public void GetDividersTest() {
      Dictionary<long, IEnumerable<long>> dic = new Dictionary<long, IEnumerable<long>>() {
        //{225, new List<long>(){ 1, 3, 5, 9, 15, 25, 45, 75, 225 } },
        {728, new List<long>() { 1, 2, 4, 7, 8, 13, 14, 26, 28, 52, 56, 91, 104, 182, 364, 728 } },
        //{1572, new List<long>() { 1, 2, 3, 4, 6, 12, 131, 262, 393, 524, 786, 1572 } },
      };
      Func<long, IEnumerable<long>> dlg = Kata.GetDividers;
      Dictionary<long, List<long>> dividers = new Dictionary<long, List<long>>() {
      };
      TestBox.OneTypeArgs(dic, dlg);
    }

    [TestMethod()]
    public void MultiplexTest() {
      IEnumerable<long> sq = new List<long>() { 1, 2, 3, 4, 5 };
      IEnumerable<long> r = Kata.Multiplex(2, sq, 15);
    }

    [TestMethod()]
    public void LimitFactorialTest() {
      IEnumerable<long[]> q = Kata.LimitFactorial(5, 10);
    }

    [TestMethod()]
    public void LookSayTest() {
      Dictionary<ulong, ulong> dic = new Dictionary<ulong, ulong>() {
        { 0, 10 },
        { 11, 21 },
        { 21, 1211 },
        { 1211, 111221 },
        { 2014, 12101114 },
        { 9000, 1930 },
        { 22322, 221322 },
        { 222222222222, 122 },
      };
      Func<ulong, ulong> dlg = Kata.LookSay;
      TestBox.OneTypeArgs(dic, dlg);
    }
  }

}