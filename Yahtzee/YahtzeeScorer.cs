using System.Collections.Generic;
using System.Linq;

namespace YahtzeeScorer
{
    class Scorer
    {
        public int ScoreByNumber(int[] dice, int chosenNumber)
        {
            return dice.Length == 5 ? (from die in dice where die == chosenNumber select die).Sum() : 0;
        }

        public int ThreeOfAKind(int[] dice, int chosenNumber)
        {
            int diceCount = 0;
            foreach (int die in dice)
            {
                if (die == chosenNumber)
                {
                    diceCount++;
                }
            }
            return dice.Length == 5 && diceCount >= 3 ? chosenNumber * 3 : 0;
        }

        public int FourOfAKind(int[] dice, int chosenNumber)
        {
            int diceCount = 0;
            foreach (int die in dice)
            {
                if (die == chosenNumber)
                {
                    diceCount++;
                }
            }
            return dice.Length == 5 && diceCount >= 4 ? chosenNumber * 4 : 0;
        }

        public int FullHouse(int[] dice, int chosenNumber1, int chosenNumber2)
        {
            int chosenNumber1Count = 0;
            int chosenNumber2Count = 0;
            foreach (int die in dice)
            {
                int result = die == chosenNumber1 ? chosenNumber1Count++ : die == chosenNumber2 ? chosenNumber2Count++ : 0;
            }

            return dice.Length == 5 && ((chosenNumber1Count == 2 || chosenNumber1Count == 3) && (chosenNumber2Count == 2 || chosenNumber2Count == 3)) ? 25 : 0;
        }

        public int SmallStraight(int[] dice)
        {
            IEnumerable<int> query = from die in dice.Distinct().OrderBy(d => dice) select die;
            foreach (int die in query)
            {
                int result = query.Min() == die ? 99 : die - (from num in query where num == (die - 1) select num).Sum() == 1 ? 1 : 0;
                if (result == 99)
                {
                    continue;
                }
                if (result == 0)
                {
                    return 0;
                }
            }
            return query.Count() >= 4 && query.Count() < 6 ? 30 : 0;
        }

    }
}
