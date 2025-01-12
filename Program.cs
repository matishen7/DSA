using Neetcode150;
using static Neetcode150.NeedCode500;
MyStack stack  = new MyStack();
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
stack.Push(4);
Console.WriteLine(stack.Pop());
stack.Push(5);
Console.WriteLine(stack.Top());
Console.WriteLine(stack.Top());
Console.WriteLine(stack.Top());


