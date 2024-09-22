using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class DynamicArray
    {
        private int[] arr;
        int size = 0;

        public DynamicArray(int capacity)
        {
            arr = new int[capacity];
        }

        public int Get(int i)
        {
            return arr[i];
        }

        public void Set(int i, int n)
        {
            arr[i] = n;
        }

        public void PushBack(int n)
        {
            if (size >= GetCapacity())
                Resize();
            arr[size] = n;
            size++;
        }

        public int PopBack()
        {
            var last = arr[size - 1];
            arr[size - 1] = 0;
            size--;
            return last;
        }

        private void Resize()
        {
            int[] copy = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                copy[i] = arr[i];

            arr = new int[arr.Length * 2];
            for (int i = 0; i < copy.Length; i++)
                arr[i] = copy[i];
        }

        public int GetSize()
        {
            return size;
        }

        public int GetCapacity()
        {
            return arr.Length;
        }
    }
}
