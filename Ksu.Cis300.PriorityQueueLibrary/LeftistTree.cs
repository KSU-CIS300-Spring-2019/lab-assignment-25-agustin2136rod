/* LeftistTree.cs
 * Author: Rod Howell 
 Edited by: Agustin Rodriguez
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.PriorityQueueLibrary
{
    /// <summary>
    /// An immutable generic binary tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public partial class LeftistTree<T> : ITree
    {
        /// <summary>
        /// gives length of shortest distance to first 
        /// empty child
        /// </summary>
        private int _nullPathLength;

        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public LeftistTree<T> LeftChild { get; }

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public LeftistTree<T> RightChild { get; }

        public object Root => throw new NotImplementedException();

        public ITree[] Children => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        public LeftistTree(T data, LeftistTree<T> left, LeftistTree<T> right)
        {
            Data = data;
            int smallerLeft = NullPathLength(left);
            int smallerRight = NullPathLength(right);
            if (smallerRight < smallerLeft)
            {
                RightChild = right;
                LeftChild = left;
            }
            else
            {
                RightChild = left;
                LeftChild = right;
            }
            _nullPathLength = 1 + NullPathLength(RightChild);
        }

        /// <summary>
        /// gets an int of smallest length from root to closest empty child
        /// </summary>
        /// <param name="t"></param> tree we are looking in
        /// <returns></returns>returns the length
        public static int NullPathLength(LeftistTree<T> t)
        {
            if(t == null)
            {
                return 0;
            }
            else
            {
                return t._nullPathLength;
            }
        }
    }
}
