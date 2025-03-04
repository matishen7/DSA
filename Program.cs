using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

MovingAverage movingAverage = new MovingAverage(3);
Console.WriteLine(movingAverage.Next(1)); // return 1.0 = 1 / 1
Console.WriteLine(movingAverage.Next(10)); // return 5.5 = (1 + 10) / 2
Console.WriteLine(movingAverage.Next(3)); // return 4.66667 = (1 + 10 + 3) / 3
Console.WriteLine(movingAverage.Next(5)); // return 6.0 = (10 + 3 + 5) / 3
//Console.WriteLine(Meta.FindBuildings(heights));
