using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    /// <summary>
    /// Aggregate class Quene implementing the main operations with the queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueDemo<T>
    {
        #region fields
        /// <summary>
        /// Size of queue
        /// </summary>
        private int size = 20;

        /// <summary>
        /// Count elements in queue
        /// </summary>
        private int count;

        /// <summary>
        /// Default resize for queue
        /// </summary>
        private const int DefaultResize = 40;

        /// <summary>
        /// Aggregate array for data
        /// </summary>
        private T[] arr;
        #endregion

        #region property
        /// <summary>
        /// Count
        /// </summary>
        public int Count => count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public QueueDemo()
        {
            this.arr = new T[this.size];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of queue</param>
        public QueueDemo(int size)
        {
            this.arr = new T[size];
        }
        #endregion       

        #region private methods
        /// <summary>
        /// Check queue for emptiness
        /// </summary>
        /// <returns>Is the queue empty</returns>
        private bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// Check queue for full
        /// </summary>
        /// <returns>Is the queue full</returns>
        private bool IsFull()
        {
            return count == arr.Length;
        }

        /// <summary>
        /// Resize array
        /// </summary>
        private void Resize()
        {
            var newArray = new T[size + DefaultResize];
            for (int i = 0; i < this.arr.Length; i++)
            {
                newArray[i] = arr[i];
            }

            size += DefaultResize;
            this.arr = newArray;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Enqueue the element
        /// </summary>
        /// <param name="target">Element</param>
        public void Enqueue(T target)
        {
            if (IsFull())
            {
                Resize();
            }

            arr[count++] = target;
        }

        /// <summary>
        /// Dequeue first element
        /// </summary>
        /// <returns>Return first element</returns>
        public T Dequeue()
        {
            T result = arr[0];

            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[arr.Length - 1] = default(T);
            count--;

            return result;
        }

        /// <summary>
        /// Peek first element
        /// </summary>
        /// <returns>First element</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty!");
            }
            return arr[0];
        }

        /// <summary>
        /// Clear the queue
        /// </summary>
        public void Clear()
        {
            arr = default(T[]);
            count = 0;
        }

        /// <summary>
        /// Check for contains the element in queue
        /// </summary>
        /// <param name="target">Element</param>
        /// <returns>Is the element in queue</returns>
        public bool Contains(T target)
        {
            for (int i = 0; i < count; i++)
            {
                if (target.Equals(arr[i]))
                {
                    return true;
                }
            }            

            return false;
        }

        /// <summary>
        /// Clone the queue
        /// </summary>
        /// <returns></returns>
        public QueueDemo<T> Clone()
        {
            return new QueueDemo<T>();
        }   

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>Iterator</returns>
        public CustomIterator GetEnumerator()
        {
            return new CustomIterator(this);
        }

        /// <summary>
        /// Struct for iteration
        /// </summary>
        public struct CustomIterator
        {
            /// <summary>
            /// Queue
            /// </summary>
            private readonly QueueDemo<T> queue;

            /// <summary>
            /// Index
            /// </summary>
            private int currentIndex;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="queue">Queue</param>
            public CustomIterator(QueueDemo<T> queue)
            {
                this.currentIndex = -1;
                this.queue = queue;
            }

            /// <summary>
            /// Current element
            /// </summary>
            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue[currentIndex];
                }
            }

            /// <summary>
            /// Reset
            /// </summary>
            public void Reset()
            {
                currentIndex = -1;
            }

            /// <summary>
            /// Check can it go next
            /// </summary>
            /// <returns>Can it go next</returns>
            public bool MoveNext()
            {
                return ++currentIndex < queue.Count;
            }
        }
        #endregion
    }
}
