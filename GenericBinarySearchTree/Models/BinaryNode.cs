using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearchTree.Models
{
    public class BinaryNode<T> where T : struct, IComparable
    {
        public T Element { get; set; }
        public BinaryNode<T> LeftNode { get; set; }
        public BinaryNode<T> RightNode { get; set; }
        public BinaryNode(T element)
        {
            Element = element;
        }

        public BinaryNode(T element, BinaryNode<T> leftNode, BinaryNode<T> rightNode)
        {
            Element = element;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public int CompareTo(T element)
        {
            return this.Element.CompareTo(element);
        }

        public bool Equals(BinaryNode<T> otherNode)
        {
            if (!this.Element.Equals(otherNode.Element))
            {
                return false;
            }
            return true;
        }

        public string ToString(int level)
        {
            string returnString = String.Empty;
            for (int i = 0; i < level; i++)
            {
                returnString += " ";
            }
            returnString += Element.ToString() + "\n";
            if (LeftNode != null)
            {
                returnString += LeftNode.ToString(level: level + 1);
            }
            if (RightNode != null)
            {
                returnString += RightNode.ToString(level: level + 1);
            }
            return returnString;
        }
    }
}
