
using Neetcode150;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

var rp = new RandomPointer();
var node1 = new DoubleNode(3);
node1.random = null;
var node2 = new DoubleNode(7);
node1.next = node2;
var node3 = new DoubleNode(4);
node2.next = node3;
var node4 = new DoubleNode(5);
node3.next = node4;

node2.random = node4;
node3.random = node1;
node4.random = node2;
rp.copyRandomList(node1);

