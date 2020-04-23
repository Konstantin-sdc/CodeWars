namespace CodeWars.Kata.Kyu.L6
{
    using CodeWars;

    using System;
    using System.Linq;

    public static class SumFractions
    {
        /// <summary>Возвращает сокращенную сумму дробей в форме строки.</summary>
        /// <param name="args">
        /// Двумерный массив целых чисел, где первое в паре число это числитель, а второе знаменатель.
        /// </param>
        /// <returns>
        /// <para>Сокращенная дробь в виде [Numerator, Denumerator].</para>
        /// <para>Numerator, если Numerator % Denumerator == 0.</para>
        /// <para><see cref="null"/>, если массив ввода пуст.</para>
        /// </returns>
        [KataType(LevelTypes.Kyu, 6, "5517fcb0236c8826940003c9")]
#pragma warning disable CA1814 // Используйте массивы массивов вместо многомерных массивов
        public static string SumFracts(int[,] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            if (args.Length == 0)
            {
                return null;
            }
            var zeroLength = args.GetLength(0);
            var tArray = new int[zeroLength, 2];
            Array.Copy(args, tArray, args.Length);
            for (var i = 0; i < zeroLength; i++)
            {
                var mD = (int)KataBase.GetMaxCommonDivider(tArray[i, 0], tArray[i, 1]);
                tArray[i, 0] /= mD;
                tArray[i, 1] /= mD;
            }
            var nmr = 0;
            var dnmr = 1;
            for (var i = 0; i < zeroLength; i++)
            {
                dnmr *= tArray[i, 1];
            }
            for (var i = 0; i < zeroLength; i++)
            {
                var multiplier = dnmr / tArray[i, 1];
                tArray[i, 0] *= multiplier;
                nmr += tArray[i, 0];
            }
            if (nmr % dnmr == 0)
            {
                return $"{nmr / dnmr}";
            }
            var maxDvdr = KataBase.GetMaxCommonDivider(nmr, dnmr);
            return $"[{nmr / maxDvdr}, {dnmr / maxDvdr}]";
#pragma warning restore CA1814 // Используйте массивы массивов вместо многомерных массивов
        }

    }
}
