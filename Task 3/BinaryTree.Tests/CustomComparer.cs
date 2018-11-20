using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Tests
{
    public class CustomComparer : IComparer<Point>, IComparer<string>
    {
        public int Compare(Point x, Point y)
        {
            if (x.x + y.y > y.x + y.y)
            {
                return 1;
            }
            if (x.x + y.y < y.x + y.y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }
            if (x.Length < y.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
