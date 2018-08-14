using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests {

  public partial class KataTests {

    /// <summary>Делегат для вызова методов с несколькими аргументами одного типа</summary>
    /// <typeparam name="Tr">Возвращаемый тип</typeparam>
    /// <typeparam name="Ta">Тип аргумента</typeparam>
    /// <param name="s">Имя аргумента</param>
    /// <returns>Экземпляр делегата</returns>
    delegate Tr OneTypeDlg<Tr, Ta>(params Ta[] s);

    /// <summary>Делегат для вызова методов с одним аргументом</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="s">Имя аргумента</param>
    /// <returns>Экземпляр делегата</returns>
    delegate Tout OneArgDlg<Tout, Tin>(Tin s);

    /// <summary>Тест методов с одним аргументом и единичным возвращаемым значением</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    void TestOneTypeArgs<Tout, Tin>(IDictionary<Tin, Tout> dic, OneArgDlg<Tout, Tin> dlg) {
      foreach(var item in dic) {
        Tout returned = dlg.Invoke(item.Key);
        AssertCheck(item.Key, item.Value, returned);
      }
    }

    /// <summary>Тест методов с одним аргументом и возвращаемой коллекцией</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    void TestOneTypeArgs<Tout, Tin>(IDictionary<Tin, Tout[]> dic, OneArgDlg<Tout[], Tin> dlg) {
      foreach(var item in dic) {
        Tout[] returned = dlg.Invoke(item.Key);
        AssertCheck(item.Key, item.Value, returned);
      }
    }

    /// <summary>Тест методов с несколькими аргументами одного типа</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    void TestOneTypeArgs<Tout, Tin>(IDictionary<Tin[], Tout> dic, OneTypeDlg<Tout, Tin> dlg) {
      foreach(var item in dic) {
        Tout returned = dlg.Invoke(item.Key);
        AssertCheck(item.Key, item.Value, returned);
      }
    }

    /// <summary>Тестирование соответствия для одиночных элементов</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="input">ВХодящие данные</param>
    /// <param name="expected">Ожидаемый результат</param>
    /// <param name="returned">Фактический результат</param>
    void AssertCheck<Tout, Tin>(Tin input, Tout expected, Tout returned) {
      try { Assert.AreEqual(expected, returned); }
      catch(UnitTestAssertException) {
        ConsoleTraceListener traceListener = new ConsoleTraceListener();
        traceListener.WriteLine(ErrorMessage(input, expected, returned));
        throw new Exception();
      }
    }

    /// <summary>Тестирование соответствия для коллекций</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="input">ВХодящие данные</param>
    /// <param name="expected">Ожидаемый результат</param>
    /// <param name="returned">Фактический результат</param>
    void AssertCheck<Tout, Tin>(Tin input, Tout[] expected, Tout[] returned) {
      try { CollectionAssert.AreEqual(expected, returned); }
      catch(UnitTestAssertException) {
        ConsoleTraceListener traceListener = new ConsoleTraceListener();
        traceListener.WriteLine(ErrorMessage(input, expected, returned));
        throw new Exception();
      }
    }

    /// <summary>Возвращает сообщение об ошибке, собранное на основе входящих данных, ожидаемого возврата и фактического возврата</summary>
    /// <param name="input">Входящие данные</param>
    /// <param name="expected">Ожидаемые данные</param>
    /// <param name="returned">Возвращённые данные</param>
    /// <returns>Отформатированное сообщение</returns>
    string ErrorMessage<Tout, Tin>(Tin input, Tout expected, Tout returned) {
      return
$@"
Input: 
{GetString(input)} 

Expected: 
{GetString(expected)} 

Returned: 
{GetString(returned)}
";
    }

    /// <summary>Возвращает строку на основе переменной, с учётом является ли переменная коллекцией</summary>
    /// <typeparam name="T">Тип переменно</typeparam>
    /// <param name="a">Переменная</param>
    /// <returns></returns>
    string GetString<T>(T a) {
      return (typeof(T) is IEnumerable) ? string.Join(Environment.NewLine, a) : a.ToString();
    }

  }

}
