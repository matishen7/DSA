using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150._250
{
    internal class DPProblems
    {
        public static bool StoneGame(int[] piles)
        {
            var memo = new Dictionary<(int,int), bool>();
            bool result = StoneGameDfs(0, piles.Length - 1, piles, true, 0, 0, memo);
            return result;
        }

        public static bool StoneGameDfs(int left, int right, int[] piles, bool turn, int alice, int bob, Dictionary<(int, int), bool> memo)
        {
            if (left > right)
            {
                return alice > bob;
            }

            if (memo.ContainsKey((left, right))) return memo[(left, right)];

            // alice turn
            if (turn)
            {
                bool first = StoneGameDfs(left + 1, right, piles, false, alice + piles[left], bob, memo);
                bool last = StoneGameDfs(left, right - 1, piles, false, alice + piles[right], bob, memo);
                memo[(left, right)] = (first || last);
                return (first || last);
            }
            //bob turn
            else
            {
                bool first = StoneGameDfs(left + 1, right, piles, true, alice, bob + piles[left], memo);
                bool last = StoneGameDfs(left, right - 1, piles, true, alice , bob + piles[right], memo);
                memo[(left, right)] = (first || last);
                return (first || last);
            }
        }
    }
}
