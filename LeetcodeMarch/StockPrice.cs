using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class StockPrice
    {
        private SortedDictionary<int, int> dict;
        private int latest;


        public StockPrice()
        {
            dict = new SortedDictionary<int, int>();
        }

        public void Update(int timestamp, int price)
        {
            latest = Math.Max(timestamp, latest);
            if (dict.ContainsKey(timestamp))
            {
                dict.Remove(timestamp);
            }
            dict.Add(timestamp, price);
        }
        public int Current()
        {
            return dict[latest];
        }

        public int Maximum()
        {
            return dict.Values.Max();
                
        }

        public int Minimum()
        {
            return dict.Values.Min();
        }
    }


    /**
     * Your StockPrice object will be instantiated and called as such:
     * StockPrice obj = new StockPrice();
     * obj.Update(timestamp,price);
     * int param_2 = obj.Current();
     * int param_3 = obj.Maximum();
     * int param_4 = obj.Minimum();
     */
}
