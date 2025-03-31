using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class SeatManager
    {
        private PriorityQueue<int, int> seats;

        public SeatManager(int n)
        {
            seats = new PriorityQueue<int, int>();
            for (int i = 1; i <= n; i++)
                seats.Enqueue(i, i);
        }

        public int Reserve()
        {
            return seats.Dequeue();
        }

        public void Unreserve(int seatNumber)
        {
            seats.Enqueue(seatNumber, seatNumber);
        }
    }
}
