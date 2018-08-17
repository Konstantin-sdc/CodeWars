﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests {

  public static class TestBox {

    /// <summary>Тест методов с одним аргументом и единичным возвращаемым значением</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    public static void OneTypeArgs<Tout, Tin>(IDictionary<Tin, Tout> dic, Func<Tin, Tout> dlg) {
      ParseDictonary(dic, dlg);
    }

    /// <summary>Тест методов с одним аргументом и возвращаемой коллекцией</summary>
    /// <typeparam name="Tout">Тип содержимого возвращаемой коллекции</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    public static void OneTypeArgs<Tout, Tin>(IDictionary<Tin, IEnumerable<Tout>> dic, Func<Tin, IEnumerable<Tout>> dlg) {
      ParseDictonary(dic, dlg);
    }

    /// <summary>Проход метода делегата по словарю с проверкой соответствия фактических и ожидаемых результатов</summary>
    /// <typeparam name="Tin">Тип аргументов метода делегата</typeparam>
    /// <typeparam name="Tout">Тип возвращаемых значений</typeparam>
    /// <param name="dictionary">Словарь</param>
    /// <param name="dlg">Делегат</param>
    static void ParseDictonary<Tin, Tout>(IDictionary<Tin, Tout> dictionary, Func<Tin, Tout> dlg) {
      foreach(var item in dictionary) {
        Tout returned = dlg.Invoke(item.Key);
        AssertCheck(item.Key, item.Value, returned);
      }
    }

    /// <summary>Проход метода делегата по словарю с проверкой соответствия фактических и ожидаемых результатов</summary>
    /// <typeparam name="Tin">Тип аргументов метода делегата</typeparam>
    /// <typeparam name="Tout">Тип содержимого возвращаемой коллекции</typeparam>
    /// <param name="dictionary">Словарь</param>
    /// <param name="dlg">Делегат</param>
    static void ParseDictonary<Tin, Tout>(IDictionary<Tin, IEnumerable<Tout>> dictionary, Func<Tin, IEnumerable<Tout>> dlg) {
      foreach(var item in dictionary) {
        IEnumerable<Tout> returned = dlg.Invoke(item.Key);
        AssertCheck(item.Key, item.Value, returned);
      }
    }

    /// <summary>Тестирование соответствия для одиночных элементов</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="input">ВХодящие данные</param>
    /// <param name="expected">Ожидаемый результат</param>
    /// <param name="returned">Фактический результат</param>
    static void AssertCheck<Tout, Tin>(Tin input, Tout expected, Tout returned) {
      string message = ErrorMessage(input, expected, returned);
      try { Assert.AreEqual(expected, returned); }
      catch(AssertFailedException) { AssertCatch(message); }
    }

    /// <summary>Тестирование соответствия для коллекций</summary>
    /// <typeparam name="Tout">Тип содержимого возвращаемой коллекции</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="input">ВХодящие данные</param>
    /// <param name="expected">Ожидаемый результат</param>
    /// <param name="returned">Фактический результат</param>
    static void AssertCheck<Tout, Tin>(Tin input, IEnumerable<Tout> expected, IEnumerable<Tout> returned) {
      string message = ErrorMessage(input, expected, returned);
      try { CollectionAssert.AreEqual((List<Tout>)expected, (List<Tout>)returned); }
      catch(AssertFailedException) { AssertCatch(message); }
    }

    /// <summary>Обработка catch для AssertCheck</summary>
    /// <param name="message">Сообщение</param>
    static void AssertCatch(string message) {
      ConsoleTraceListener traceListener = new ConsoleTraceListener();
      traceListener.WriteLine(message);
      throw new AssertFailedException(message);
    }

    static readonly string _messageTemlate = 
$@"
Input: 
{0} 

Expected: 
{1} 

Returned: 
{2}
";

    /// <summary>Возвращает сообщение об ошибке, собранное на основе входящих данных, ожидаемого возврата и фактического возврата</summary>
    /// <param name="input">Входящие данные</param>
    /// <param name="expected">Ожидаемые данные</param>
    /// <param name="returned">Возвращённые данные</param>
    /// <returns>Отформатированное сообщение</returns>
    static string ErrorMessage<Tout, Tin>(Tin input, Tout expected, Tout returned) {
      string exp = expected.ToString();
      string ret = ret = returned.ToString();
      return string.Format(_messageTemlate, input.ToString(), exp, ret);
    }

    /// <summary>Возвращает сообщение об ошибке, собранное на основе входящих данных, ожидаемого возврата и фактического возврата</summary>
    /// <param name="input">Входящие данные</param>
    /// <param name="expected">Ожидаемые данные</param>
    /// <param name="returned">Возвращённые данные</param>
    /// <returns>Отформатированное сообщение</returns>
    static string ErrorMessage<Tout, Tin>(Tin input, IEnumerable<Tout> expected, IEnumerable<Tout> returned) {
      string exp = string.Join(Environment.NewLine, expected);
      string ret = string.Join(Environment.NewLine, returned);
      return string.Format(_messageTemlate, input.ToString(), exp, ret);
    }

  }

}
