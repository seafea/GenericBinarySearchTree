using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearchTree.Models
{
    using System.ComponentModel.Design.Serialization;

    public class BinarySearchTree<T> where T : struct, IComparable
    {
        private BinaryNode<T> Root { get; set; }

        private BinaryNode<T> Pool { get; }

        private int PoolSize { get; }

        public BinarySearchTree()
        {
            this.Root = null;
            this.Pool = null;
            this.PoolSize = 0;
        }

        public BinarySearchTree(int poolSize)
        {
            this.Root = null;
            this.Pool = null;
            this.PoolSize = poolSize;
        }

        public bool IsEmpty()
        {
            if (this.Root == null)
            {
                return true;
            }
            return false;
        }

        public Nullable<T> Find(T elementToFind)
        {
            return Find(root: Root, elementToFind: elementToFind);
        }

        private Nullable<T> Find(BinaryNode<T> root, T elementToFind)
        {
            if (root == null)
            {
                return null;
            }
            int comparisonResult = root.CompareTo(element: elementToFind);
            if (comparisonResult == 0)
            {
                return ((Nullable<T>)root.Element);
            }
            else if (comparisonResult > 0)
            {
                return Find(root: root.LeftNode, elementToFind: elementToFind);
            }
            else if (comparisonResult < 0)
            {
                return Find(root: root.RightNode, elementToFind: elementToFind);
            }
            return default(T);
        }

        public bool Insert(T elementToInsert)
        {
            int tempNumberOfElements = this.GetNumberOfElements();
            Root = Insert(root: Root, elementToInsert: elementToInsert);
            if (tempNumberOfElements != this.GetNumberOfElements())
            {
                return true;
            }
            return false;
        }

        private BinaryNode<T> Insert(BinaryNode<T> root, T elementToInsert)
        {
            if (root == null)
            {
                return new BinaryNode<T>(element: elementToInsert, leftNode: null, rightNode: null);
            }
            int comparisonResult = root.CompareTo(elementToInsert);
            if (comparisonResult > 0)
            {
                root.LeftNode = Insert(root: root.LeftNode, elementToInsert: elementToInsert);
            }
            else if (comparisonResult < 0)
            {
                root.RightNode = Insert(root: root.RightNode, elementToInsert: elementToInsert);
            }
            else if (comparisonResult == 0)
            {
                return root;
            }
            return root;
        }

        public bool Remove(T elementToRemove)
        {
            int tempNumberOfElements = this.GetNumberOfElements();
            Root = Remove(root: Root, elementToRemove: elementToRemove);
            if (tempNumberOfElements != this.GetNumberOfElements())
            {
                return true;
            }
            return false;
        }

        private BinaryNode<T> Remove(BinaryNode<T> root, T elementToRemove)
        {
            if (root == null)
            {
                return root;
            }
            int comparisonResult = root.CompareTo(elementToRemove);
            if (comparisonResult == 0)
            {
                // found the element to remove.
                if (root.LeftNode == null && root.RightNode == null)
                {
                    // both children are null, so removal is simple.
                    root = null;
                }
                else if (root.LeftNode != null && root.RightNode != null)
                {
                    // There are two children here, so removal is a bit
                    // more complicated.
                    // checking to see if the right child's left node is null.
                    bool simplePullup = (root.RightNode.LeftNode == null);
                    if (!simplePullup)
                    {
                        BinaryNode<T> newRoot = DeleteRightMinimum(root: root.RightNode);
                        BinaryNode<T> tempLeft = root.LeftNode;
                        BinaryNode<T> tempRight = root.RightNode;
                        newRoot.LeftNode = tempLeft;
                        newRoot.RightNode = tempRight;
                        root = newRoot;
                    }
                    else
                    {
                        // Since the right child's left node is null, we can simply
                        // pull up the right child.
                        root = root.RightNode;
                    }
                }
                else if (root.LeftNode != null)
                {
                    // Only the Left Child Node exists.
                    root = root.LeftNode;
                }
                else if (root.RightNode != null)
                {
                    // Only the Right Child Node exists.
                    root = root.RightNode;
                }
            }
            else if (comparisonResult > 0)
            {
                // Look left.
                root.LeftNode = Remove(root: root.LeftNode, elementToRemove: elementToRemove);
            }
            else if (comparisonResult < 0)
            {
                // Look right.
                root.RightNode = Remove(root: root.RightNode, elementToRemove: elementToRemove);
            }
            return root;
        }

        /**
         * Helper function to deal with deletion of a node
         * that has more than one child.
         */
        private BinaryNode<T> DeleteRightMinimum(BinaryNode<T> root)
        {
            if (root.LeftNode != null)
            {
                if (root.LeftNode.LeftNode != null)
                {
                    return DeleteRightMinimum(root: root.LeftNode);
                }
                else
                {
                    BinaryNode<T> returnNode = root.LeftNode;
                    if (root.LeftNode.RightNode != null)
                    {
                        BinaryNode<T> nodeToPullUp = root.LeftNode.RightNode;
                        root.LeftNode = nodeToPullUp;
                    }
                    else
                    {
                        root.LeftNode = null;
                    }
                    return returnNode;
                }
            }
            else if (root.RightNode != null)
            {
                // Left node is null, but right node is not.
                root = root.RightNode;
                return root;
            }
            else
            {
                // Both child nodes are null.
                BinaryNode<T> tempBinaryNode =
                    new BinaryNode<T>(root.Element);
                root = null;
                return tempBinaryNode;
            }
        }

        public void CapWith(T elementToCapWith)
        {
            Root = CapWith(root: Root, elementToCapWith: elementToCapWith);
        }

        private BinaryNode<T> CapWith(BinaryNode<T> root, T elementToCapWith)
        {
            if (root != null)
            {
                int comparisonResult = root.CompareTo(element: elementToCapWith);
                {
                    if (comparisonResult > 0)
                    {
                        // elementtocapwith is less than than root.element.
                        // go left
                        root.LeftNode = CapWith(root: root.LeftNode, elementToCapWith: elementToCapWith);
                        // go right
                        root.RightNode = CapWith(root: root.RightNode, elementToCapWith: elementToCapWith);
                        // remove element
                        root = Remove(root: root, elementToRemove: root.Element);

                    }
                    else if (comparisonResult < 0)
                    {
                        // elementtocapwith is greater than root.element.
                        // go right
                        root.RightNode = CapWith(root: root.RightNode, elementToCapWith: elementToCapWith);
                    }
                    else if (comparisonResult == 0)
                    {
                        // elementtocapwith is equal to root.element.
                        // go right
                        root.RightNode = CapWith(root: root.RightNode, elementToCapWith: elementToCapWith);
                        // remove element
                        root = Remove(root: root, elementToRemove: root.Element);
                    }
                }
            }
            return root;
        }

        public bool Equals(Object other)
        {
            if (other == null)
            {
                return false;
            }
            var thisType = this.GetType();
            var otherType = other.GetType();
            if (!thisType.IsAssignableFrom(otherType) || !otherType.IsAssignableFrom(thisType))
            {
                // Objects are not the same type.
                return false;
            }
            BinarySearchTree<T> otherTree = (BinarySearchTree<T>)other;
            return EqualsHelper(thisTree: Root, otherTree: otherTree.Root);
        }

        private bool EqualsHelper(BinaryNode<T> thisTree, BinaryNode<T> otherTree)
        {
            if (thisTree == null && otherTree == null)
            {
                return true;
            }
            if (thisTree == null || otherTree == null)
            {
                return false;
            }
            bool equalsResult = thisTree.Equals(otherTree);
            if (equalsResult)
            {
                equalsResult = EqualsHelper(thisTree: thisTree.LeftNode, otherTree: otherTree.LeftNode);
            }
            if (equalsResult)
            {
                equalsResult = EqualsHelper(thisTree: thisTree.RightNode, otherTree: otherTree.RightNode);
            }
            return equalsResult;
        }

        public string ToString()
        {
            return Root.ToString(level: 0);
        }

        public bool IsFull()
        {
            return IsFullHelper(root: Root);
        }

        private bool IsFullHelper(BinaryNode<T> root)
        {
            bool result = true;
            if (root == null)
            {
                return true;
            }
            else
            {
                if ((root.LeftNode != null && root.RightNode == null)
                    || (root.LeftNode == null && root.RightNode != null))
                {
                    return false;
                }
                else
                {
                    result = IsFullHelper(root.LeftNode);
                    if (result)
                    {
                        result = IsFullHelper(root.RightNode);
                    }
                }
            }
            return result;
        }

        public bool IsComplete()
        {
            if (Root == null)
            {
                return true;
            }
            int maxHeight = this.GetHeight();
            return IsCompleteHelper(root: Root, currHeight: 0, maxHeight: maxHeight);
        }

        private bool IsCompleteHelper(BinaryNode<T> root, int currHeight, int maxHeight)
        {
            // Complete if all the levels except the last are completely full,
            // and the last level has all its nodes to the left side.
            if (root == null)
            {
                return true;
            }
            else
            {
                currHeight++;
                if (currHeight == maxHeight)
                {
                    if (!root.IsFull())
                    {
                        return false;
                    }
                }
                else if (currHeight == maxHeight - 1)
                {
                    if (!this.IsFull() && root.LeftNode == null)
                    {
                        return false;
                    }
                }
                bool result = true;
                result = IsCompleteHelper(root: root.LeftNode, currHeight: currHeight, maxHeight: maxHeight);
                if (result)
                {
                    result = IsCompleteHelper(root: root.RightNode, currHeight: currHeight, maxHeight: maxHeight);
                }
                return result;
            }
        }

        public int GetNumberOfElements()
        {
            return GetNumberOfElementsHelper(root: Root);
        }

        private int GetNumberOfElementsHelper(BinaryNode<T> root)
        {
            int result = 0;
            if (root != null)
            {
                result++;
                result += this.GetNumberOfElementsHelper(root: root.LeftNode);
                result += this.GetNumberOfElementsHelper(root: root.RightNode);
            }
            return result;
        }

        public BinaryNode<T> GetRootNode()
        {
            return Root;
        }

        public int GetHeight()
        {
            return GetHeightHelper(root: Root, height: 0, maxHeight: 0);
        }
        private int GetHeightHelper(BinaryNode<T> root, int height, int maxHeight)
        {
            if (root != null)
            {
                height++;
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
                maxHeight = this.GetHeightHelper(root: root.LeftNode, height: height, maxHeight: maxHeight);
                maxHeight = this.GetHeightHelper(root: root.RightNode, height: height, maxHeight: maxHeight);
            }
            return maxHeight;
        }
    }
}
