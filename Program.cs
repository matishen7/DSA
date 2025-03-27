using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [1, 3, 2, 5, null, null, 9, 6, null, 7];
//var root1 = TreeProblems.BuildTree(arr);
//TreeProblems.PrintBST(root1);

//var node5 = new ListNode(5);
//var node4 = new ListNode(4, node5);
//var node3 = new ListNode(3, node4);
//var node2 = new ListNode(2);
//var node1 = new ListNode(1, node2);

//Console.WriteLine(SolutionMarch.SwapNodes(node1, 2));


BrowserHistory browserHistory = new BrowserHistory("leetcode.com");
browserHistory.Visit("google.com");       // You are in "leetcode.com". Visit "google.com"
browserHistory.Visit("facebook.com");     // You are in "google.com". Visit "facebook.com"
browserHistory.Visit("youtube.com");      // You are in "facebook.com". Visit "youtube.com"
browserHistory.Back(1);                   // You are in "youtube.com", move back to "facebook.com" return "facebook.com"
browserHistory.Back(1);                   // You are in "facebook.com", move back to "google.com" return "google.com"
browserHistory.Forward(1);                // You are in "google.com", move forward to "facebook.com" return "facebook.com"
browserHistory.Visit("linkedin.com");     // You are in "facebook.com". Visit "linkedin.com"
browserHistory.Forward(2);                // You are in "linkedin.com", you cannot move forward any steps.
browserHistory.Back(2);                   // You are in "linkedin.com", move back two steps to "facebook.com" then to "google.com". return "google.com"
browserHistory.Back(7);                   // You are in "google.com", you can move back only one step to "leetcode.com". return "leetcode.com"
