using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Matrices
{
    /// <summary>
    /// Abstract matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractMatrix<T> : IEnumerable<T>
    {
        /// <summary>
        /// Size of matrix
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Square matrix
        /// </summary>
        public T[,] Arr{ get; }

        /// <summary>
        /// Event for changed element in matrix
        /// </summary>
        public event EventHandler MatrixWasChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="arr">Array</param>
        public AbstractMatrix(int size, T[,] arr)
        {
            Size = size;
            Arr = arr;
        }

        /// <summary>
        /// Get set value
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="j">j</param>
        /// <returns>Element of matrix[i, j]</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                return GetValue(i,j);
            }
            set
            {                
                InsertElement(i, j, value);
            }
        }

        /// <summary>
        /// Get value
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="j">j</param>
        /// <returns>Element of matrix[i, j]</returns>
        public abstract T GetValue(int i, int j);

        /// <summary>
        /// Insert value
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="j">j</param>
        /// <param name="target">Elemtnt</param>
        public abstract void InsertElement(int i, int j, T target);

        /// <summary>
        /// Invoke event on insert element
        /// </summary>
        /// <param name="i">i</param>
        /// <param name="j">j</param>
        protected void OnMatrixChanged(int i, int j)
        {
            MatrixWasChanged?.Invoke(this, new MatrixChangedEventArgs(i, j));
        }

        /// <summary>
        /// Custom get enumerator matrix
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator<T> GetEnumeratorMatrix();

        /// <summary>
        /// Realization IEnumerator
        /// </summary>
        /// <returns>Custom enumerator matrix</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumeratorMatrix();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
