using Neetcode150;
using Neetcode150._250;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;
int numberOfUsers = 3; IList<IList<string>> events =
[["MESSAGE", "1", "id0 id1"], ["MESSAGE", "5", "id2"], ["MESSAGE", "6", "ALL"], ["OFFLINE", "5", "2"]];
Console.WriteLine(Contests.CountMentions(numberOfUsers, events));
