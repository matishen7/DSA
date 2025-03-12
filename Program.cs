using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [5, 5, 5, 5, 5, null, 5];
//var root = TreeProblems.BuildTree(arr);
//TreeProblems.PrintBST(root);
RandomizedSet randomizedSet = new RandomizedSet();
randomizedSet.Insert(1); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
randomizedSet.Remove(2); // Returns false as 2 does not exist in the set.
randomizedSet.Insert(2); // Inserts 2 to the set, returns true. Set now contains [1,2].
randomizedSet.GetRandom(); // getRandom() should return either 1 or 2 randomly.
randomizedSet.Remove(1); // Removes 1 from the set, returns true. Set now contains [2].
randomizedSet.Insert(2); // 2 was already in the set, so return false.
randomizedSet.GetRandom(); // Since 2 is the only number in the set, getRandom() will always return 2.
//AmazonSolutions.HasSameDigits("3902");