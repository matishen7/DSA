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
// Creates three tables.
SQL sQL = new SQL(["one", "two", "three"], [2, 3, 1]);

// Adds a row to the table "two" with id 1. Returns True. 
sQL.Ins("two", ["first", "second", "third"]);

// Returns the value "third" from the third column 
// in the row with id 1 of the table "two".
sQL.Sel("two", 1, 3);

// Removes the first row of the table "two".
sQL.Rmv("two", 1);

// Returns "<null>" as the cell with id 1 
// has been removed from table "two".
sQL.Sel("two", 1, 2);

// Returns False as number of columns are not correct.
sQL.Ins("two", ["fourth", "fifth"]);

// Adds a row to the table "two" with id 2. Returns True.
sQL.Ins("two", ["fourth", "fifth", "sixth"]);
