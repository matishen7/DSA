using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class MathAndGeometry
    {
        public static List<int> SpiralOrder(int[][] matrix)
        {
            var answer = new List<int>();
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            var visit = new HashSet<(int, int)>();
            int i = 0;
            int j = 0;
            int count = 0;
            while (count < rows * cols)
            {
                while (j < cols && !visit.Contains((i, j)))
                {
                    answer.Add(matrix[i][j]);
                    visit.Add((i, j));
                    count++;
                    j++;
                }
                j--;
                i++;
                while (i < rows && !visit.Contains((i, j)))
                {
                    answer.Add(matrix[i][j]);
                    visit.Add((i, j));
                    count++;
                    i++;
                }
                i--;
                j--;
                while (j >= 0 && !visit.Contains((i, j)))
                {
                    answer.Add(matrix[i][j]);
                    visit.Add((i, j));
                    count++; j--;
                }
                j++;
                i--;
                while (i >= 0 && !visit.Contains((i, j)))
                {
                    answer.Add(matrix[i][j]);
                    visit.Add((i, j));
                    count++; i--;
                }
                i++;
                j++;
            }
            return answer;
        }

        public static void SetZeroes(int[][] matrix)
        {
            var queue = new Queue<(int r, int c)>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    if (matrix[i][j] == 0) queue.Enqueue((i, j));
            }

            while (queue.Count > 0)
            {
                (int i, int j) = queue.Dequeue();
                for (int r = 0; r < matrix.Length; r++)
                    matrix[r][j] = 0;
                for (int c = 0; c < matrix[i].Length; c++)
                    matrix[i][c] = 0;
            }
        }

        private static void SetZeroHelper(int[][] matrix, int i, int j)
        {
            for (int r = 0; r < matrix.Length; r++)
                matrix[r][j] = 0;
            for (int c = 0; c < matrix[i].Length; c++)
                matrix[i][c] = 0;
        }

        public static bool IsHappy(int n)
        {
            var set = new HashSet<int>();
            while (n != 1)
            {
                int sum = 0;
                while (n > 0)
                {
                    int d = n % 10;
                    sum += d * d;
                    n /= 10;
                }
                if (set.Contains(sum)) return false;
                else set.Add(sum);
                n = sum;
            }

            return true;
        }

        public static int[] PlusOne(int[] digits)
        {
            var answer = new List<int>();
            int carry = 0;
            int d = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (i == digits.Length - 1)
                    d = carry + digits[i] + 1;
                else d = carry + digits[i];
                carry = (d >= 10) ? 1 : 0;
                answer.Add(d % 10);
            }
            if (carry != 0) answer.Add(carry);

            answer.Reverse();

            return answer.ToArray();
        }

        public static double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            double res = 1;

            for (int i = 0; i < Math.Abs(n); i++)
                res *= x;

            if (n > 0) return res;
            else return 1 / res;

        }

        public static string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0")) return "0";

            int p = 0;
            string sum = "0";
            int carry = 0;
            var list = new List<string>();
            for (int j = num2.Length - 1; j >= 0; j--)
            {
                StringBuilder b = new StringBuilder();
                carry = 0;
                for (int i = num1.Length - 1; i >= 0; i--)
                {
                    int d = (num1[i] - 48) * (num2[j] - 48) + carry;
                    carry = (d / 10);
                    d = (d % 10);
                    b.Insert(0, d);
                }
                if (carry != 0) b.Insert(0, carry);
                for (int k = 0; k < p; k++)
                    b.Append(0);
                p++;
                list.Add(b.ToString());
                sum = BigSum(sum, b.ToString());
            }

            return sum;
        }

        public static string BigSum(string number1, string number2)
        {
            if (number1.Length > number2.Length)
            {
                int k = number1.Length - number2.Length;
                for (int i = 0; i < k; i++)
                    number2 = "0" + number2;
            }
            else if (number2.Length > number1.Length)
            {
                int k = number2.Length - number1.Length;
                for (int i = 0; i < k; i++)
                    number1 = "0" + number1;
            }
            StringBuilder b = new StringBuilder();
            int carry = 0;
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int d = (number1[i] - 48) + (number2[i] - 48) + carry;
                carry = d / 10;
                d = d % 10;
                b.Insert(0, d);

            }
            if (carry > 0) b.Insert(0, carry);
            return b.ToString();
        }
    }
}
