using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tests {

  [TestClass()]
  public class KataTests {

    [TestMethod()]
    public void SoundexTest() {
      Dictionary<string, string> sourceResult = new Dictionary<string, string>() {
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
      foreach(var item in sourceResult) {
        string returned = Kata.Soundex(item.Key);
        try {
          Assert.AreEqual(item.Value, returned);
        }
        catch(UnitTestAssertException) {
          throw new Exception($@"
            Input: {item.Key}, 
            Expected: {item.Value}, 
            Returned: {returned}"
          );
        }
      }
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
      var c = b.Select(e => (char)e);
      string s2 = string.Join("", c);
      bool r = s2.Equals(s); // true
    }
  }

}