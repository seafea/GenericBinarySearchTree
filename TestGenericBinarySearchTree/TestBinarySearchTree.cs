using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenericBinarySearchTree
{
    using System.Runtime.Remoting;

    using GenericBinarySearchTree.Models;

    [TestFixture]
    public class TestBinarySearchTree
    {
        [Test]
        public void TestDefaultConstructor()
        {
            BinarySearchTree<int> testBST = new BinarySearchTree<int>();
            Assert.True(testBST.IsEmpty());
        }

        [Test]
        public void TestSecondConstructor()
        {
            BinarySearchTree<int> testBST = new BinarySearchTree<int>(poolSize: 10);
            Assert.True(testBST.IsEmpty());
        }

        [Test]
        public void TestInsert()
        {
            BinarySearchTree<int> testBST = new BinarySearchTree<int>();
            Assert.True(testBST.Insert(elementToInsert: 60));
            Assert.True(testBST.Insert(elementToInsert: 30));
            Assert.True(testBST.Insert(elementToInsert: 40));
            Assert.True(testBST.Insert(elementToInsert: 75));
            Assert.True(testBST.Insert(elementToInsert: 70));
            Assert.True(testBST.Insert(elementToInsert: 80));
            Assert.False(testBST.Insert(elementToInsert: 70));
            Assert.AreEqual(6, testBST.GetNumberOfElements());
        }

        [Test]
        public void TestFind()
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
            Assert.AreEqual(55, testBST.Find(elementToFind: 55));
            Assert.AreEqual(40, testBST.Find(elementToFind: 40));
            Assert.AreEqual(70, testBST.Find(elementToFind: 70));
            Assert.IsNull(testBST.Find(elementToFind: 100));
        }

        [Test]
        public void TestRemove()
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
            Assert.True(testBST.Remove(elementToRemove: 40));
            Assert.IsNull(testBST.GetRootNode().LeftNode.RightNode);
            Assert.False(testBST.Remove(elementToRemove: 100));
            Assert.AreEqual(7, testBST.GetNumberOfElements());

        }

        [Test]
        public void TestToString()
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
            string result = testBST.ToString();
            Assert.AreEqual("50\n 30\n  40\n 75\n  60\n   55\n   70\n  80\n", testBST.ToString());
        }

        [Test]
        public void TestIsFull()
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
            Assert.False(testBST.IsFull());
            BinarySearchTree<int> fullBST = new BinarySearchTree<int>();
            testBST.Insert(50);
            testBST.Insert(30);
            testBST.Insert(20);
            testBST.Insert(40);
            testBST.Insert(75);
            testBST.Insert(60);
            testBST.Insert(80);
            Assert.True(testBST.IsFull());
        }

        [Test]
        public void TestGetHeight()
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
            Assert.AreEqual(4, testBST.GetHeight());
            BinarySearchTree<int> emptyTree = new BinarySearchTree<int>();
            Assert.AreEqual(0, emptyTree.GetHeight());
        }

        [Test]
        public void TestIsComplete()
        {
            BinarySearchTree<int> testBST = new BinarySearchTree<int>();
            testBST.Insert(20);
            testBST.Insert(10);
            testBST.Insert(5);
            testBST.Insert(15);
            testBST.Insert(30);
            testBST.Insert(25);
            Assert.IsTrue(testBST.IsComplete());
            testBST.Remove(25);
            testBST.Insert(35);
            Assert.IsFalse(testBST.IsComplete());
            BinarySearchTree<int> emptyTree = new BinarySearchTree<int>();
            Assert.True(emptyTree.IsComplete());
        }
    }
}
