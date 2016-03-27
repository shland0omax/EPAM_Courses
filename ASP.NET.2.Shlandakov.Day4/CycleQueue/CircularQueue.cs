using System;
using System.Collections;
using System.Collections.Generic;
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
        private bool IsSynced = false;

        /// <summary>
        /// Length of queue
        /// </summary>
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
                    NextIndex(ref headIndex);
                    index++;
                } while (headIndex != taleIndex);
                headIndex = 0;
                taleIndex = arraySize;
                arraySize *= 2;
                array = temp;
            }
            queueLength++;
            array[taleIndex] = input;
            NextIndex(ref taleIndex);
            IsSynced = false;
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
            NextIndex(ref headIndex);
            queueLength--;
            IsSynced = false;
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

        /// <summary>
        /// Looks if equal item is in queue
        /// </summary>
        /// <param name="item">object to be compared</param>
        /// <returns>true, if equal item found, false otherwise</returns>
        public bool Contains(T item)
        {
            IEqualityComparer comparer = EqualityComparer<T>.Default;
            foreach (T elem in this)
            {
                if (comparer.Equals(item, elem))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Clears queue
        /// </summary>
        public void Clear()
        {
            headIndex = taleIndex = queueLength = 0;
            IsSynced = false;
        }

        /// <summary>
        /// Returns this queue as an array
        /// </summary>
        /// <returns>Array of queue members</returns>
        public T[] ToArray()
        {
            T[] outArray = new T[queueLength];
            for(int i = 0, x = headIndex; i < queueLength; i++, NextIndex(ref x))
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
                NextIndex(ref i);
            } while (i != taleIndex);
            return sb.ToString();
        }

        /// <summary>
        /// Returns queue's enumerator
        /// </summary>
        /// <returns>queue's enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            IsSynced = true;
            for(int i = 0, j = headIndex; i < queueLength; ++i, NextIndex(ref j))
            {
                if (!IsSynced) throw new InvalidOperationException("Trying enumerate changed version!");
                yield return array[j];
            }
            yield break;
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

        #region Private Methods
        /// <summary>
        /// Helps to get next index in circular array
        /// </summary>
        /// <param name="currentIndex">current index</param>
        /// <returns>next index</returns>
        private void NextIndex(ref int currentIndex)
        {
            currentIndex = (currentIndex + 1 == arraySize) ? 0 : currentIndex + 1;
        }
        #endregion
    }
}
