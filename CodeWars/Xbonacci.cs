﻿namespace CodeWars {
  public class Xbonacci {

    /// <summary>Возвращает Трибоначи для первых <paramref name="n"/> элементов числовой последовательности</summary>
    /// <param name="signature">3 числа, определяющие сигнатуру последовательности</param>
    /// <param name="n">Количество чисел, для которых следует вернуть последовательность Трибоначи</param>
    /// <returns>Итоговая последовательность Трибоначи</returns>
    public double[] Tribonacci(double[] signature, int n) {
      if(n < 1 || signature.Length != 3) return new double[1];
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