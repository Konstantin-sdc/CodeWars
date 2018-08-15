using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests {

  public partial class KataTests {

    /// <summary>Тест методов с одним аргументом и единичным возвращаемым значением</summary>
    /// <typeparam name="Tout">Возвращаемый тип</typeparam>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    void TestOneTypeArgs<Tout, Tin>(IDictionary<Tin, Tout> dic, Func<Tin, Tout> dlg) {
      ParseDictonary(dic, dlg);
    }

    /// <summary>Тест методов с одним аргументом и возвращаемой коллекцией</summary>
    /// <typeparam name="Tin">Тип аргумента</typeparam>
    /// <param name="dic">Словарь</param>
    /// <param name="dlg">Делегат тестируемого метода</param>
    void TestOneTypeArgs<Tin>(IDictionary<Tin, ICollection> dic, Func<Tin, ICollection> dlg) {
      ParseDictonary(dic, dlg);      
    }

    /// <summary>Проход метода делегата по словарю с проверкой соответствия фактических и ожидаемых результатов</summary>
    /// <typeparam name="Tin">Тип аргументов метода делегата</typeparam>
    /// <typeparam name="Tout">Тип возвращаемых занчений</typeparam>
    /// <param name="dictionary">Словарь</param>
    /// <param name="dlg">Делегат</param>
    void ParseDictonary<Tin, Tout>(IDictionary<Tin, Tout> dictionary, Func<Tin, Tout> dlg) {
      foreach(var item in dictionary) {
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
      string message = ErrorMessage(input, expected, returned);
      try { AssertCall(expected, returned); }
      catch(AssertFailedException) { AssertCatch(message); }
    }

    /// <summary>
    /// Вызывает <see cref="CollectionAssert.AreEqual"/> 
    /// или <see cref="Assert.AreEqual"/> в зависсимости от того, 
    /// являются ли аргументы коллекциями
    /// </summary>
    /// <typeparam name="T">Тип аргумента</typeparam>
    /// <param name="expected">Ожидаемое значение</param>
    /// <param name="actual">Фактическое значение</param>
    void AssertCall<T>(T expected, T actual) {
      ICollection colExp = (ICollection)expected;
      ICollection colAct = (ICollection)actual;
      if(typeof(T) is ICollection) CollectionAssert.AreEqual(colExp, colAct);
      else Assert.AreEqual(expected, actual);
    }

    /// <summary>Обработка catch для AssertCheck</summary>
    /// <param name="message">Сообщение</param>
    void AssertCatch(string message) {
      ConsoleTraceListener traceListener = new ConsoleTraceListener();
      traceListener.WriteLine(message);
      throw new AssertFailedException(message);
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
