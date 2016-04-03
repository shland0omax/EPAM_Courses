using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleQueue
{
    /// <summary>
    /// Represents cycle queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularQueue<T> : IEnumerable<T> where T: IEquatable<T>
    {
        #region Fields and Properties
        private T[] array;
        private int arraySize;
        private int headIndex, taleIndex;
        private int queueLength;
        private bool isSynced;

        /// <summary>
        /// Length of queue
        /// </summary>
        public int QueueLength => queueLength;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (no params)
        /// </summary>
        public CircularQueue()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with initial array input
        /// </summary>
        /// <param name="initArray">initial array</param>
        public CircularQueue(params T[] initArray): this((IEnumerable<T>)initArray)
        {
        }

        /// <summary>
        /// Constructor for Enumerable parameters
        /// </summary>
        /// <param name="initEnumerable">input Enumerable</param>
        public CircularQueue(IEnumerable<T> initEnumerable)
        {
            if (initEnumerable == null) throw new ArgumentNullException(nameof(initEnumerable) + " is null");
            arraySize = 16;
            IEnumerable<T> list = initEnumerable as List<T> ?? initEnumerable.ToList();
            int length = list.Count();
            while (arraySize < length) arraySize *= 2;

            Initialize(arraySize);

            foreach (var elem in list)
            {
                Enqueue(elem);
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
            isSynced = false;
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
            isSynced = false;
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
            if (item == null)
                return this.Any(elem => (object)elem == null);
            return this.Any(elem => elem.Equals(item));
        }

        /// <summary>
        /// Clears queue
        /// </summary>
        public void Clear()
        {
            headIndex = taleIndex = queueLength = 0;
            isSynced = false;
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
            isSynced = true;
            for(int i = 0, j = headIndex; i < queueLength; ++i, NextIndex(ref j))
            {
                if (!isSynced) throw new InvalidOperationException("Trying enumerate changed version!");
                yield return array[j];
            }
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

        private void Initialize(int initLength = 16)
        {
            arraySize = initLength;
            array = new T[arraySize];
            headIndex = taleIndex = queueLength = 0;
        }
        #endregion
    }
}
