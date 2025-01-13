using Neetcode150._250;

MyCircularQueue myCircularQueue = new MyCircularQueue(3);
myCircularQueue.EnQueue(1);
myCircularQueue.EnQueue(2);
myCircularQueue.EnQueue(3);
myCircularQueue.EnQueue(4);
Console.WriteLine(myCircularQueue.Rear());     // return 3
Console.WriteLine(myCircularQueue.IsFull());   // return True
Console.WriteLine(myCircularQueue.DeQueue());  // return True
Console.WriteLine(myCircularQueue.DeQueue());  // return True
Console.WriteLine(myCircularQueue.DeQueue());  // return True
Console.WriteLine(myCircularQueue.DeQueue());  // return True
Console.WriteLine(myCircularQueue.EnQueue(4)); // return True
Console.WriteLine(myCircularQueue.Rear());
