using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleQueue
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        #region Fields and Properties
        private T[] array;
        private int arraySize;
        private int headIndex, taleIndex;
        private int queueLength;

        public int QueueLength
        {
            get { return queueLength; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (no params)
        /// </summary>
        public CircularQueue()
        {
            arraySize = 16;
            array = new T[arraySize];
            headIndex = taleIndex = queueLength = 0;
        }

        /// <summary>
        /// Constructor with initial array input
        /// </summary>
        /// <param name="initArray">initial array</param>
        public CircularQueue(params T[] initArray): this()
        {
            if (initArray == null)
                throw new ArgumentNullException(nameof(initArray) + " is null");
            foreach (var str in initArray)
            {
                Enqueue(str);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Tells if queue is empty
        /// </summary>
        /// <returns>Returns true if queue is empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return queueLength == 0;
        }

        /// <summary>
        /// Enqueues new member to the end of queue
        /// </summary>
        /// <param name="input">input param to be enqueued</param>
        public void Enqueue(T input)
        {
            if (queueLength == arraySize)
            {
                T[] temp = new T[2 * arraySize];
                int index = 0;
                do
                {
                    temp[index] = array[headIndex];
                    headIndex = NextIndex(headIndex);
                    index++;
                } while (headIndex != taleIndex);
                headIndex = 0;
                taleIndex = arraySize;
                arraySize *= 2;
                array = temp;
            }
            queueLength++;
            array[taleIndex] = input;
            taleIndex = NextIndex(taleIndex);
        }

        /// <summary>
        /// Dequeues member from queue's head
        /// </summary>
        /// <returns>1st (head) member</returns>
        public T Dequeue()
        {
            if (queueLength == 0)
                throw new Exception("Queue is empty");
            T res = array[headIndex];
            headIndex = NextIndex(headIndex);
            queueLength--;
            return res;
        }

        /// <summary>
        /// Returns head member without dequeueing
        /// </summary>
        /// <returns>1st (head) member</returns>
        public T Peek()
        {
            if (queueLength != 0)
                return array[headIndex];
            throw new Exception("Queue is empty");
        }


        //Если я правильно понял, подобая реализация Contains используется во встроенном классе Queue<T>
        //public bool Contains(T item)
        //{
        //    IEqualityComparer comparer = EqualityComparer<T>.Default;
        //    foreach (T elem in this)
        //    {
        //        if (comparer.Equals(item, elem))
        //            return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Looks if such member is in the queue
        /// </summary>
        /// <param name="t">member to find</param>
        /// <returns>True - if such member is found, no otherwise</returns>
        public bool Contains(T t)
        {
            return array.Contains(t);
        }

        /// <summary>
        /// Clears queue
        /// </summary>
        public void Clear()
        {
            headIndex = taleIndex = queueLength = 0;
        }

        /// <summary>
        /// Returns this queue as an array
        /// </summary>
        /// <returns>Array of queue members</returns>
        public T[] ToArray()
        {
            T[] outArray = new T[queueLength];
            for(int i = 0, x = headIndex; i < queueLength; i++, x = NextIndex(x))
            {
                outArray[i] = array[x];
            }
            return outArray;
        }

        public override string ToString()
        {
            if (queueLength == 0) return "";
            StringBuilder sb = new StringBuilder();
            int i = headIndex;
            do
            {
                sb.AppendLine(array[i].ToString());
                i = NextIndex(i);
            } while (i != taleIndex);
            return sb.ToString();
        }

        /// <summary>
        /// Returns queue's enumerator
        /// </summary>
        /// <returns>queue's enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(ToArray());
        }

        /// <summary>
        /// Returns queue's enumerator as IEnumerator
        /// </summary>
        /// <returns>queue's enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Enumerator
        /// <summary>
        /// Enumerator for circular queue
        /// Warning! This enumerator realisation copies queue's array,
        /// so its version could not be equal with origin queue
        /// </summary>
        public class Enumerator : IEnumerator<T>
        {
            private T[] array;
            private int position = -1;

            public Enumerator(T[] list) 
            {
                if (list == null)
                    throw new ArgumentNullException(nameof(list) + " is null");
                array = list;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return array[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                position++;
                return (position < array.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Helps to get next index in circular array
        /// </summary>
        /// <param name="currentIndex">current index</param>
        /// <returns>next index</returns>
        private int NextIndex(int currentIndex)
        {
            return (currentIndex + 1 == arraySize) ? 0 : currentIndex + 1;
        }
        #endregion
    }
}
