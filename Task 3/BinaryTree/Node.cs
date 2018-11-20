using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T>
    {
        public T element;
        public Node<T> left;
        public Node<T> rigth;

        public Node(T element)
        {
            this.element = element;
        }
    }
}
