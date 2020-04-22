using System;
using CodeWars;
namespace CodeWars.Kata.Kyu.L6
{
    public static class SumFractions
    {
        [KataType(LevelTypes.Kyu, 6, "5517fcb0236c8826940003c9")]
#pragma warning disable CA1814 // Используйте массивы массивов вместо многомерных массивов
        public static string SumFracts(int[,] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            var zeroLength = args.GetLength(0);
            var tArray = new int[zeroLength, 2];
#pragma warning restore CA1814 // Используйте массивы массивов вместо многомерных массивов
            return "";
        }

    }
}
