using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Matrices
{
    /// <summary>
    /// Simple sqare matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : AbstractMatrix<T>
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
        public SquareMatrix(int size, T[,] arr) : base(size, arr)
        {
            if (size * size != arr.Length || size != arr.GetLength(0))
            {
                throw new ArgumentException();
            }
            this.arr = arr;
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
