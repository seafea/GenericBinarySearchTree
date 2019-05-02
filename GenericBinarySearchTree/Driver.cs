using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearchTree
{
    using GenericBinarySearchTree.Models;

    public static class Driver
    {
        static public void Main(String[] args)
        {
            BinarySearchTree<int> testBST = new BinarySearchTree<int>();
            testBST.Insert(elementToInsert: 50);
            testBST.Insert(elementToInsert: 30);
            testBST.Insert(elementToInsert: 40);
            testBST.Insert(elementToInsert: 75);
            testBST.Insert(elementToInsert: 60);
            testBST.Insert(elementToInsert: 55);
            testBST.Insert(elementToInsert: 70);
            testBST.Insert(elementToInsert: 80);
            Console.WriteLine(testBST.ToString());
            Queue<BinaryNode<int>> queue = testBST.GetLevelOrderTraversal();
            Console.WriteLine("Height is " + testBST.GetHeight());
            Console.ReadLine();
        }
    }
}
