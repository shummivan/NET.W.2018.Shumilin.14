using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Matrix.Matrices;

namespace Matrix
{
    public class MatrixSummator
    {
        /// <summary>
        /// Sum two matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">First abstract matrix</param>
        /// <param name="b">Second abstract matrix</param>
        /// <returns>Square matrix with sum first and second matrix</returns>
        public SquareMatrix<T> SumTwoMatrix<T>(AbstractMatrix<T> a, AbstractMatrix<T> b)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(a.Size, a.Arr);
            try
            {
                for (int i = 0; i < a.Size; i++)
                {
                    for (int j = 0; j < a.Size; j++)
                    {
                        result[i, j] = Add(a[i, j], b[i, j]);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new NotSupportedException("", ex);
            }
            return result;
        }

        /// <summary>
        /// Summ two element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static T Add<T>(T lhs, T rhs)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "elem1"),
                                paramB = Expression.Parameter(typeof(T), "elem2");
            BinaryExpression body = Expression.Add(paramA, paramB);
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            return add(lhs, rhs);
        }
    }
}
