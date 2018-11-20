using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// Simple binary tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T>
    {
        /// <summary>
        /// Root
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Comparision
        /// </summary>
        private Comparison<T> comparision;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryTree()
        {
            comparision = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Constructor with custom comparision
        /// </summary>
        /// <param name="comparision">Comparision</param>
        public BinaryTree(Comparison<T> comparision)
        {
            this.comparision = comparision;
        }

        /// <summary>
        /// Constructor with custom comparer
        /// </summary>
        /// <param name="comparer">Comparer</param>
        public BinaryTree(IComparer<T> comparer)
        {
            comparision = comparer.Compare;
        }

        /// <summary>
        /// Add element to tree
        /// </summary>
        /// <param name="element">Element</param>
        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            root = Add(root, element);
        }

        /// <summary>
        /// Preorder tree
        /// </summary>
        /// <returns>IEnumerable of elements</returns>
        public IEnumerable<T> Preorder()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }

            return Preorder(root);
        }

        /// <summary>
        /// Inorder tree
        /// </summary>
        /// <returns>IEnumerable of elements</returns>
        public IEnumerable<T> Inorder()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }

            return Inorder(root);
        }

        /// <summary>
        /// Postorder tree
        /// </summary>
        /// <returns>IEnumerable of elements</returns>
        public IEnumerable<T> Postorder()
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }

            return Postorder(root);
        }

        /// <summary>
        /// Check is contains element in tree 
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>is contains element in tree </returns>
        public bool Contains(T element)
        {
            if (root == null)
            {
                throw new NullReferenceException();
            }
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            return Contains(root, element);
        }

        /// <summary>
        /// Add element to tree
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="element">Element</param>
        /// <returns>Node</returns>
        private Node<T> Add(Node<T> node, T element)
        {
            if (node == null)
            {
                return new Node<T>(element);
            }

            if (comparision(node.element, element) > 0)
            {
                node.left = Add(node.left, element);
            }
            else
            {
                node.rigth = Add(node.rigth, element);
            }

            return node;
        }

        /// <summary>
        /// Preorder tree
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>IEnumerable of elements</returns>
        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.element;
            if (node.left != null)
            {
                foreach (var item in Preorder(node.left))
                {
                    yield return item;
                }
            }
            if (node.rigth != null)
            {
                foreach (var item in Preorder(node.rigth))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Inorder tree
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>IEnumerable of elements</returns>
        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.left != null)
            {
                foreach (var item in Inorder(node.left))
                {
                    yield return item;
                }
            }

            yield return node.element;

            if (node.rigth != null)
            {
                foreach (var item in Inorder(node.rigth))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Post order tree
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>IEnumerable of elements</returns>
        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.left != null)
            {
                foreach (var item in Postorder(node.left))
                {
                    yield return item;
                }
            }
            if (node.rigth != null)
            {
                foreach (var item in Postorder(node.rigth))
                {
                    yield return item;
                }
            }

            yield return node.element;
        }

        /// <summary>
        /// Check is contains element in tree 
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="element">Element</param>
        /// <returns>is contains element in tree </returns>
        private bool Contains(Node<T> node, T element)
        {
            if (comparision(node.element, element) == 0)
            {
                return true;
            }
            else if (comparision(node.element, element) < 0)
            {
                return Contains(node.rigth, element);
            }
            else if (comparision(node.element, element) > 0)
            {
                return Contains(node.left, element);
            }

            return false;
        }
    }
}
