namespace CodeWars.Kata.Kyu.L7
{
    using System.Linq;

    public static class MinMax
    {
        [KataType(LevelTypes.Kyu, 7)]
        public static int[] GetMinMax(int[] lst)
        {
            return new int[] { lst.Min(), lst.Max() };
        }
    }
}
