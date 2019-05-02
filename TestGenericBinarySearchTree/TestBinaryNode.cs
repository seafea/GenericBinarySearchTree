using NUnit.Framework;

namespace TestGenericBinarySearchTree
{

    using GenericBinarySearchTree.Models;

    public enum TestTypes
    {
        None,
        UnitTesting,
        IntegrationTesting,
        FlyByTheSeatOfYourPantsTesting
    }
    [TestFixture]
    public class TestBinaryNode
    {
        [Test]
        public void TestDefaultConstructor()
        {
            BinaryNode<int> testBinaryNode = new BinaryNode<int>(element: 10);
            Assert.IsNull(testBinaryNode.LeftNode);
            Assert.IsNull(testBinaryNode.RightNode);
            Assert.AreEqual(10, testBinaryNode.Element);
        }

        [Test]
        public void TestSecondConstructor()
        {
            BinaryNode<int> testLeftBinaryNode = new BinaryNode<int>(element: 10);
            BinaryNode<int> testRightBinaryNode = new BinaryNode<int>(element: 30);
            BinaryNode<int> testBinaryNode = new BinaryNode<int>(
                element: 20,
                leftNode: testLeftBinaryNode,
                rightNode: testRightBinaryNode);
            Assert.IsNull(testBinaryNode.LeftNode.LeftNode);
            Assert.IsNull(testBinaryNode.RightNode.RightNode);
            Assert.AreEqual(10, testBinaryNode.LeftNode.Element);
            Assert.AreEqual(20, testBinaryNode.Element);
        }

        [Test]
        public void TestCompareTo()
        {
            BinaryNode<int> testBinaryNode = new BinaryNode<int>(element: 20);
            BinaryNode<int> testLowerBinaryNode = new BinaryNode<int>(element: 10);
            BinaryNode<int> testHigherBinaryNode = new BinaryNode<int>(element: 30);
            BinaryNode<int> testEqualBinaryNode = new BinaryNode<int>(element: 20);
            int comparisonEqual = testBinaryNode.CompareTo(element: testEqualBinaryNode.Element);
            int comparisonLower = testBinaryNode.CompareTo(element: testLowerBinaryNode.Element);
            int comparisonHigher = testBinaryNode.CompareTo(element: testHigherBinaryNode.Element);
            Assert.AreEqual(0, comparisonEqual);
            Assert.AreEqual(1, comparisonLower);
            Assert.AreEqual(-1, comparisonHigher);
        }

        [Test]
        public void TestEquals()
        {
            BinaryNode<int> testFirstLeftBinaryNode = new BinaryNode<int>(element: 10);
            BinaryNode<int> testFirstRightBinaryNode = new BinaryNode<int>(element: 30);
            BinaryNode<int> testFirstBinaryNode = new BinaryNode<int>(
                element: 20,
                leftNode: testFirstLeftBinaryNode,
                rightNode: testFirstRightBinaryNode);
            BinaryNode<int> testSecondLeftBinaryNode = new BinaryNode<int>(element: 10);
            BinaryNode<int> testSecondRightBinaryNode = new BinaryNode<int>(element: 30);
            BinaryNode<int> testSecondBinaryNode = new BinaryNode<int>(
                element: 20,
                leftNode: testSecondLeftBinaryNode,
                rightNode: testSecondRightBinaryNode);
            BinaryNode<int> testThirdBinaryNode = new BinaryNode<int>(element: 30);
            Assert.IsTrue(testFirstBinaryNode.Equals(otherNode: testSecondBinaryNode));
            Assert.IsFalse(testFirstBinaryNode.Equals(otherNode: testThirdBinaryNode));
        }
        [Test]
        public void TestToString()
        {
            BinaryNode<int> testLeftNode = new BinaryNode<int>(element: 10);
            BinaryNode<int> testRightNode = new BinaryNode<int>(element: 30);
            BinaryNode<int> testRootNode =
                new BinaryNode<int>(element: 20, leftNode: testLeftNode, rightNode: testRightNode);
            Assert.AreEqual("20\n 10\n 30\n", testRootNode.ToString(level: 0));
        }

        [Test]
        public void TestIsFull()
        {
            BinaryNode<int> rightNode = new BinaryNode<int>(30);
            BinaryNode<int> notFullNode = new BinaryNode<int>(element: 20, leftNode: null, rightNode: rightNode);
            Assert.False(notFullNode.IsFull());
            BinaryNode<int> fullRightNode = new BinaryNode<int>(element: 30);
            BinaryNode<int> fullLeftNode = new BinaryNode<int>(element: 10);
            BinaryNode<int> fullNode = new BinaryNode<int>(
                element: 20,
                leftNode: fullLeftNode,
                rightNode: fullRightNode);
            Assert.True(fullNode.IsFull());
        }
    }
}
