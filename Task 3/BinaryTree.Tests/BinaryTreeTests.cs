using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [TestCase(new int[] {1, 8, 3, 5, 9, 7, 4}, ExpectedResult = new int[] { 1, 8, 3, 5, 4, 7, 9 })]
        public int[] Preorder_ValidFormat_ValidResult(int[] arr)
        {
            BinaryTree<int> bt = new BinaryTree<int>();

            foreach (var item in arr)
            {
                bt.Add(item);
            }

            return bt.Preorder().ToArray();
        }

        [TestCase(new int[] { 1, 8, 3, 5, 9, 7, 4 }, ExpectedResult = new int[] { 1, 3, 4, 5, 7, 8, 9 })]
        public int[] Inorder_ValidFormat_ValidResult(int[] arr)
        {
            BinaryTree<int> bt = new BinaryTree<int>();

            foreach (var item in arr)
            {
                bt.Add(item);
            }

            return bt.Inorder().ToArray();
        }

        [TestCase(new int[] { 1, 8, 3, 5, 9, 7, 4 }, ExpectedResult = new int[] { 4, 7, 5, 3, 9, 8, 1 })]
        public int[] Postorder_ValidFormat_ValidResult(int[] arr)
        {
            BinaryTree<int> bt = new BinaryTree<int>();

            foreach (var item in arr)
            {
                bt.Add(item);
            }

            return bt.Postorder().ToArray();
        }

        [Test]
        public void String_CustomCompare_ValidResult()
        {
            string s1 = "a";
            string s2 = "aa";
            string s3 = "aaa";
            string s4 = "bbbb";
            string[] expected = { s1, s2, s3, s4 };

            CustomComparer comparer = new CustomComparer();
            BinaryTree<string> bt = new BinaryTree<string>(comparer.Compare);

            bt.Add(s1);
            bt.Add(s2);
            bt.Add(s3);
            bt.Add(s4);

            string[] arr = bt.Inorder().ToArray();

            Assert.AreEqual(arr, expected);
        }

        [Test]
        public void String_DefaultCompare_ValidResult()
        {
            string s1 = "a";
            string s2 = "aa";
            string s3 = "aaa";
            string s4 = "bbbb";
            string[] expected = { s1, s2, s3, s4 };

            CustomComparer comparer = new CustomComparer();
            BinaryTree<string> bt = new BinaryTree<string>(comparer.Compare);

            bt.Add(s1);
            bt.Add(s2);
            bt.Add(s3);
            bt.Add(s4);

            string[] arr = bt.Inorder().ToArray();

            Assert.AreEqual(arr, expected);
        }

        [Test]
        public void Point_CustomCompare_ValidResult()
        {
            Point p = new Point(1, 2);
            Point p2 = new Point(5, 8);
            Point p3 = new Point(0, 0);
            Point p4 = new Point(5, 88);
            Point p5 = new Point(89, 888);
            Point[] expected = { p3, p, p2, p4, p5 };

            CustomComparer comparer = new CustomComparer();
            BinaryTree<Point> bt = new BinaryTree<Point>(comparer.Compare);

            bt.Add(p);
            bt.Add(p2);
            bt.Add(p3);
            bt.Add(p4);
            bt.Add(p5);

            Point[] arr2 = bt.Inorder().ToArray();

            Assert.AreEqual(arr2, expected);
        }
    }
}
