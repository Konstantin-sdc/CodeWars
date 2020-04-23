namespace CodeWars.Kata.Kyu.L5
{
    using System.Collections.Generic;

    public static partial class Bundesliga
    {
        /// <summary>Команда</summary>
        private class Kommando
        {
            /// <summary>Название команды</summary>
            public string Name;
            /// <summary>Матчей сыграно</summary>
            public int MatchCount;
            /// <summary>Голов забито</summary>
            public int GoalsOut;
            /// <summary>Голов получено</summary>
            public int GoalsIn;
            /// <summary>Матчей выиграно</summary>
            public int Wins;
            /// <summary>Матчей вничью</summary>
            public int Ties;
            /// <summary>Матчей проиграно</summary>
            public int Loses;
            /// <summary>Очков заработано</summary>
            public int Points => (Wins * 3) + Ties;

            /// <summary>Возвращает новыйэкземпляр класса <see cref="Kommando"/></summary>
            /// <param name="comName">Название команды</param>
            /// <param name="gOut">Голов забито</param>
            /// <param name="gIn">Голов получено</param>
            public Kommando(string comName, string gOut, string gIn)
            {
                Name = comName;
                var isGoals =
                  int.TryParse(gOut, out GoalsOut) &&
                  int.TryParse(gIn, out GoalsIn);
                if (!isGoals)
                {
                    return;
                }

                MatchCount = 1;
                if (GoalsOut > GoalsIn)
                {
                    Wins = 1;
                }

                if (GoalsOut < GoalsIn)
                {
                    Loses = 1;
                }

                if (GoalsOut == GoalsIn)
                {
                    Ties = 1;
                }
            }

            /// <summary>
            /// Если команда не найдена в спискае, — добавляет её в список.
            /// Если найдена — складывает результаты этой команды.
            /// </summary>
            /// <param name="lst">Список команд</param>
            public void AddToList(List<Kommando> lst)
            {
                Kommando fc0 = lst.Find(e => e.Name == Name);
                if (fc0 == null)
                {
                    lst.Add(this);
                }
                else
                {
                    fc0.GoalsIn += GoalsIn;
                    fc0.GoalsOut += GoalsOut;
                    fc0.Loses += Loses;
                    fc0.MatchCount += MatchCount;
                    fc0.Ties += Ties;
                    fc0.Wins += Wins;
                }
            }

            /// <summary>Возвращает результат проверки совпадения зачёта с другой командой</summary>
            /// <param name="k">Проверяемая команда</param>
            /// <returns>true, если резульаты совпадают</returns>
            public bool SameResult(Kommando k)
            {
                return
                  Points == k.Points &&
                  GoalsOut - GoalsIn == k.GoalsOut - k.GoalsIn &&
                  GoalsOut == k.GoalsOut
                  ;
            }
        }
    }
}
