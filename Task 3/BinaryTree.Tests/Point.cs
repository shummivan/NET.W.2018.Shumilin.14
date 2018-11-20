using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BinaryTree.Tests
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Sum()
        {
            return x + y;
        }
    }
}