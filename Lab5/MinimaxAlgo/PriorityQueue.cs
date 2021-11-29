using System;

namespace MinimaxAlgorithm
{
    class PriorityQueue<T>
    {
        private T[] _array;
        private int[] priorities;
        public int Count { get; private set; }
        private int capacity = 10;
        private int head;
        private int tail;

        public PriorityQueue()
        {
            _array = new T[capacity];
            priorities = new int[capacity];
            Count = 0;
            head = 0;
            tail = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(T newElement, int priority)
        {
            if (tail == capacity - 1)
            {
                T[] newQueue = new T[capacity * 2];
                int[] newPriority = new int[capacity * 2];
                Array.Copy(_array, head, newQueue, 0, tail - head + 1);
                Array.Copy(priorities, head, newPriority, 0, tail - head + 1);
                capacity *= 2;
                tail -= head;
                head = 0;
                _array = newQueue;
                priorities = newPriority;
            }
            Count++;
            for (int i = head; i <= tail; i++)
            {
                if (priority < priorities[i] || priorities[i] == 0)
                {
                    for (int j = tail + 1; j > i; j--)
                    {
                        _array[j] = _array[j - 1];
                        priorities[j] = priorities[j - 1];
                    }
                    _array[i] = newElement;
                    priorities[i] = priority;
                    break;
                }
            }
            tail++;
        }

        public (T, int) Top()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Count--;
            head++;
            return (_array[head - 1], priorities[head-1]);
        }

        public bool Contains(T item)
        {
            for (int i = head; i <= tail; i++)
            {
                if (item.Equals(_array[i])) return true;
            }
            return false;
        }
    }
}