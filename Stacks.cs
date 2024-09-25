using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal static class Stacks
    {
        public static bool IsValid(string s)
        {
            if (s.Length == 0) return true;
            else if (s.Length == 1) return false;
            var stack = new Stack<char>() { };
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                    stack.Push(s[i]);
                else
                {
                    if (stack.Count == 0) stack.Push(s[i]);
                    else
                    {
                        var last = stack.Peek();
                        if (s[i] == ']' && last == '[') stack.Pop();
                        else if (s[i] == '}' && last == '{') stack.Pop();
                        else if (s[i] == ')' && last == '(') stack.Pop();
                        else stack.Push(s[i]);
                    }
                }
            }
            return stack.Count == 0;
        }

        public class MinStack
        {
            private List<int> arr;
            private Stack<int> minStack;
            private int size = 0;

            public MinStack()
            {
                arr = new List<int>();
                minStack = new Stack<int>();
            }

            public void Push(int val)
            {
                arr.Add(val);
                if (minStack.Count == 0) minStack.Push(val);
                else
                {
                    int minSoFar = minStack.Peek();
                    if (val < minSoFar) minStack.Push(val);
                    else minStack.Push(minSoFar);
                }
            }

            public void Pop()
            {
                var last = arr.ElementAt(arr.Count - 1);
                arr.RemoveAt(arr.Count - 1);
                minStack.Pop();
            }

            public int Top()
            {
                return arr[arr.Count - 1];
            }

            public int GetMin()
            {
                return minStack.Peek();
            }

        }
        public static int EvalRPN(string[] tokens)
        {
            int i = 0;
            var stack = new Stack<int>();
            while (i < tokens.Length)
            {
                if (tokens[i].Equals("+"))
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(a + b);
                }
                else if (tokens[i].Equals("-"))
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b - a);
                }

                else if (tokens[i].Equals("*"))
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b * a);
                }
                else if (tokens[i].Equals("/"))
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(b / a);
                }
                else
                {
                    int.TryParse(tokens[i], out var n);
                    stack.Push(n);
                }
                i++;
            }
            return stack.Peek();
        }

        public static int[] NextGreaterElement(int[] nums)
        {
            int[] ans = new int[nums.Length];
            var mono = new Stack<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (mono.Count > 0 && mono.Peek() <= nums[i])
                    mono.Pop();

                if (mono.Count == 0)
                    ans[i] = -1;
                else ans[i] = mono.Peek();

                mono.Push(nums[i]);

            }

            return ans;
        }

        public static int[] DailyTemperatures(int[] temperatures)
        {
            var dic = new Dictionary<int, int>();
            int[] ans = new int[temperatures.Length];
            var mono = new Stack<Temperature>();
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                while (mono.Count > 0 && mono.Peek().temperature <= temperatures[i])
                {
                    mono.Pop();
                }
                if (mono.Count == 0)
                    ans[i] = 0;
                else ans[i] = mono.Peek().index - i;


                mono.Push(new Temperature() { temperature = temperatures[i], index = i });

            }

            return ans;
        }

        private class Temperature
        {
            public int temperature;
            public int index;
        }

        
    }
}
