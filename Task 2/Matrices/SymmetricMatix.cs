using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Matrices
{
    /// <summary>
    /// Simple symmetrical matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SymmetricMatix<T> : AbstractMatrix<T>
    {
        /// <summary>
        /// Square array
        /// </summary>
        private T[,] arr;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="arr">Arr</param>
        public SymmetricMatix(int size, T[,] arr) : base(size, arr)
        {
            if (size * size != arr.Length || size != arr.GetLength(0))
            {
                throw new ArgumentException();
            }
            if (IsSymmetric(arr))
            {
                this.arr = arr;
            }
        }

        /// <summary>
        /// Insert element
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="j">j</param>
        /// <param name="target">Element</param>
        public override void InsertElement(int i, int j, T target)
        {
            if (arr.GetLength(0) <= i || arr.GetLength(1) <= j)
            {
                throw new ArgumentOutOfRangeException();
            }

            OnMatrixChanged(i, j);
            arr[i, j] = target;
            arr[j, i] = target;
        }

        /// <summary>
        /// Custom enumerator
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<T> GetEnumeratorMatrix()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    yield return arr[i, j];
                }
            }
        }


        /// <summary>
        /// Check is the metrix symmetrical
        /// </summary>
        /// <param name="arr">Arr</param>
        /// <returns>Is the matrix diagonal</returns>
        private bool IsSymmetric(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!arr[i, j].Equals(arr[j, i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get value matrix[i, j]
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="j">j</param>
        /// <returns>Element</returns>
        public override T GetValue(int i, int j)
        {
            return arr[i, j];
        }
    }
}
