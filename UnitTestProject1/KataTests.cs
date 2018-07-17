﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
      throw new NotImplementedException();
    }

    [TestMethod()]
    public void FromBase64Test() {

    }

    [TestMethod()]
    public void GetBytesTest() {
      string s = "ABCD";
      byte[] sBytes = Encoding.Default.GetBytes(s);
      char[] chars = s.ToCharArray();
      byte[] cBytes = Encoding.Default.GetBytes(chars);
    }

  }
}