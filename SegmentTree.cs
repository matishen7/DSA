using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{

    public class NumArray
    {
        private SegmentTree _tree;
        public NumArray(int[] nums)
        {
            _tree = SegmentTree.build(nums, 0, nums.Length - 1);
        }

        public void Update(int index, int val)
        {
            _tree.update(index, val);
        }

        public int SumRange(int left, int right)
        {
            return _tree.rangeQuery(left, right);
        }
    }

    public class SegmentTree
    {
        int sum;
        SegmentTree? left;
        SegmentTree? right;
        int L;
        int R;

        public SegmentTree(int total, int L, int R)
        {
            this.sum = total;
            this.left = null;
            this.right = null;
            this.L = L;
            this.R = R;
        }

        public static SegmentTree build(int[] nums, int L, int R)
        {
            if (L == R)
            {
                return new SegmentTree(nums[L], L, R);
            }

            int M = (L + R) / 2;
            SegmentTree root = new SegmentTree(0, L, R);
            root.left = build(nums, L, M);
            root.right = build(nums, M + 1, R);
            root.sum = root.left.sum + root.right.sum;
            return root;
        }

        public void update(int index, int val)
        {
            if (this.L == this.R)
            {
                this.sum = val;
                return;
            }

            int M = (this.L + this.R) / 2;
            if (index > M)
            {
                this.right.update(index, val);
            }
            else
            {
                this.left.update(index, val);
            }
            this.sum = this.left.sum + this.right.sum;
        }

        public int rangeQuery(int L, int R)
        {
            if (L == this.L && R == this.R)
            {
                return this.sum;
            }

            int M = (this.L + this.R) / 2;
            if (L > M)
            {
                return this.right.rangeQuery(L, R);
            }
            else if (R <= M)
            {
                return this.left.rangeQuery(L, R);
            }
            else
            {
                return (this.left.rangeQuery(L, M) +
                        this.right.rangeQuery(M + 1, R));
            }
        }
    }
}
