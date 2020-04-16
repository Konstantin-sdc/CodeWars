using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L5 {
    public partial class Bundesliga {
        [KataType(LevelTypes.Kyu, 5, "57c178e16662d0d932000120")]
        public static string BundesLigaTable(string[] results) {
            var kList = new List<Kommando>();
            foreach (var item in results) {
                var score = item.Split(new char[] { ' ' }).First();
                var goals = score.Split(':');
                var kommands = item.Remove(0, score.Length + 1)
                  .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var k0 = new Kommando(kommands[0], goals[0], goals[1]);
                var k1 = new Kommando(kommands[1], goals[1], goals[0]);
                k0.AddToList(kList);
                k1.AddToList(kList);
            }
            kList = kList
              .OrderByDescending(k => k.Points)
              .ThenByDescending(k => k.GoalsOut - k.GoalsIn)
              .ThenByDescending(k => k.GoalsOut)
              .ThenBy(k => k.Name.ToLower())
              .ToList();
            var komResults = new List<string>();
            for (int i = 0, number = 1; i < kList.Count; i++) {
                Kommando k = kList[i];
                Kommando kPr = (i - 1 >= 0) ? kList[i - 1] : k;
                if (!k.SameResult(kPr)) {
                    number = i + 1;
                }

                var komStr = string.Join("  ",
                  number.ToString().PadLeft(2) + ".",
                  k.Name.PadRight(30) + k.MatchCount.ToString(),
                  k.Wins.ToString(),
                  k.Ties.ToString(),
                  k.Loses.ToString(),
                  k.GoalsOut.ToString() + ":" + k.GoalsIn.ToString(),
                  k.Points
                  );
                komResults.Add(komStr);
            }
            return string.Join("\n", komResults).Replace(".  ", ". ");
        }
    }
}
