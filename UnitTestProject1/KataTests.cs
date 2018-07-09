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
        { "Tymczak", "T522" }
      };
      foreach(var item in sourceResult) {
        string returned = Kata.Soundex(item.Key);
        Assert.AreEqual(item.Value, returned);
      }
      //Assert.Fail();
    }
  }
}