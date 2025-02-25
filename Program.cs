using Neetcode150;
using static Neetcode150.Meta;

int[] nums1 = [1, 0, 0, 2, 3];
var vector = new SparseVector(nums1);
int[] nums2 = [0, 3, 0, 4, 0];
Console.WriteLine(vector.dotProduct(nums2));
